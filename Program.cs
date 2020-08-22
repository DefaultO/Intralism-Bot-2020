using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Memory;
using Console = Colorful.Console;

namespace Intralism_Bot_2020
{
    class Program
    {
        /// <summary>
        /// <para>This Method returns the MD5 Hash of the current Proccess this gets called out</para>
        /// Example: 46F91A02FF51B1C39A7651603D3F0BEB
        /// </summary>
        private static string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }

        /// <summary>
        /// This is only here if you are too lazy to write 'Console.WriteLine();' every time you want to have some space between two displayed strings
        /// </summary>
        /// <param name="amounts">Used to create X new empty lines. Default: 1</param>
        private static void NewLine(int amounts = 1)
        {
            for (int amount = 1; amount <= amounts; amount++)
                Console.WriteLine();
        }

        /// <summary>
        /// You want to write centered? Well, this function does it for you. 
        /// </summary>
        /// <param name="content">The content you want to write in the center of the Consoleline</param>
        /// <param name="newLine">If true use 'Console.WriteLine()' instead of 'Console.Write()'.</param>
        /// <param name="color">You want to use a Color? No Problem.</param>
        private static void WriteCentered(string content, bool newLine = true, Color color = new Color())
        {
            Console.SetCursorPosition((Console.WindowWidth - content.Length) / 2, Console.CursorTop);
            if (newLine)
            {
                if (color.IsEmpty)
                    Console.WriteLine(content);
                else
                    Console.WriteLine(content, color);
            }
            else
            {
                if (color.IsEmpty)
                    Console.Write(content);
                else
                    Console.Write(content, color);
            }
            
        }

        /// <summary>
        /// I wanted to keep the Code clean so I moved the Header Part to this method here.
        /// </summary>
        private static void DisplayHeader(string title, string buildVersion, string gameVersion, string md5Hash, Color titleForegroundColor, Color md5HashForegroundColor)
        {
            List<string> signature = new List<string>(new string[] {
                    "   _ _                                                                              ",
                    " _| | |_ _____ _____ _____ _____    _____ _____ _____ _____ _____ __    _____ _____ ",
                    "|_     _|_   _|   __|  _  |     |  |   __|  |  | __  |   __|   | |  |  |     |   __|",
                    "|_     _| | | |   __|     | | | |  |   __|     |    -|   __| | | |  |__|  |  |__   |",
                    "  |_|_|   |_| |_____|__|__|_|_|_|  |_____|__|__|__|__|_____|_|___|_____|_____|_____|",
                    "                                                                                    "
                });

            for (int signatureIndex = 0; signatureIndex < signature.Count; signatureIndex++)
            {
                WriteCentered(signature[signatureIndex], true, titleForegroundColor);
            }

            NewLine();
            WriteCentered(title);
            WriteCentered(String.Format(("{0} > {1}"), buildVersion, gameVersion));
            WriteCentered(String.Format("MD5:{0}", md5Hash), true, md5HashForegroundColor);
        }

        /// <summary>
        /// Get the process at index 0 of all processes named after the parameter 'pName'.
        /// </summary>
        /// <param name="pName">The Process Name you are looking for.</param>
        public static bool GetProcessesByName(string pName, out System.Diagnostics.Process process)
        {
            System.Diagnostics.Process[] pList = System.Diagnostics.Process.GetProcessesByName(pName);
            process = pList.Length > 0 ? pList[0] : null;
            return process != null;
        }

        /// <summary>
        /// Clear whole current Consoleline.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);

            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");

            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static Mem m = new Mem();
        static void Main(string[] args)
        {
            string title = "Intralism Bot - Private Build";
            string buildVersion = "Build: 16.07.2020";
            string gameVersion = "Game Version: v.5.5.2.0659 b.4815754";
            string md5Hash = GetMD5();

            // Change them based on the Game
            Color titleForegroundColor = Color.FromArgb(66, 66, 66);     // Original: 34, 31, 48
            Color md5HashForegroundColor = Color.FromArgb(255, 61, 64);  // Original: 50, 168, 82

            Console.CursorVisible = false;
            DisplayHeader(title, buildVersion, gameVersion, md5Hash, titleForegroundColor, md5HashForegroundColor);

            ConsoleSpinner spin = new ConsoleSpinner();
            NewLine(3);
            WriteCentered("Looking for Intralism.exe...", false);
            while (true)
            {
                System.Diagnostics.Process process;
                if (GetProcessesByName("Intralism", out process))
                {
                    ClearCurrentConsoleLine();
                    WriteCentered("Status: Running");
                    WriteCentered($"Intralism.exe [{process.Id}]");
                    break;
                }
                spin.Turn();
                Thread.Sleep(100);
            }
            if (m.OpenProcess("Intralism"))
            {
                Thread readMemory = new Thread(new ThreadStart(MemoryReader));
                readMemory.Start();
            }

            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void MemoryReader()
        {
            string oldPath = "", newPath = "";

            while (true)
            {
                // A lot of Errors here (since the fields only have a value when you are in a Map), we need to use try here.
                // I am too lazy to handle the Errors, a catch that does nothing should do the trick.
                try
                {
                    // Current Time
                    Patchables.currentTime = m.ReadFloat(Patchables.currenTimePointer.Get());

                    // Map Path / Config Location
                    // Actually doing it for the first time right and use the length pointer instead of hardcoding the length to 100
                    Patchables.fullevelPathLength = m.ReadInt(Patchables.fullLevelPathLengthPointer.Get());
                    byte[] fullLevelPathValueInBytes = m.ReadBytes(Patchables.fullLevelPathValuePointer.Get(), Patchables.fullevelPathLength * 2);
                    Patchables.fullevelPathValue = Encoding.Unicode.GetString(fullLevelPathValueInBytes);

                    Patchables.musicTime = m.ReadFloat(Patchables.musicTimePointer.Get());

                    Patchables.configVersion = m.ReadInt(Patchables.configVersionPointer.Get());

                    Patchables.handCount = m.ReadInt(Patchables.handCountPointer.Get());

                    Patchables.arcsDelay = m.ReadFloat(Patchables.arcsDelayPointer.Get());
                    // TODO: Read all the other Values we might need too

                    newPath = Patchables.fullevelPathValue;

                    if (oldPath != newPath)
                    {
                        oldPath = newPath;
                        Bot.OpenConfig();
                    }
                }
                catch
                {
                    // Do Nothing
                }
                finally
                {
                    TimeSpan time = TimeSpan.FromSeconds(Patchables.currentTime);
                    TimeSpan time2 = TimeSpan.FromSeconds(Patchables.musicTime);
                    Console.Title = $"Time: {time.ToString("hh':'mm':'ss")}/{time2.ToString("hh':'mm':'ss")} | Map: {Patchables.fullevelPathValue}";
                }
            }
        }
    }
}
