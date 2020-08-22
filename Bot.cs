using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intralism_Bot_2020
{
    class Map
    {
        public static List<Event> events = new List<Event>();
    }

    class Bot
    {
        public static void OpenConfig()
        {
            try
            {
                string configPath = Patchables.fullevelPathValue + @"\config.txt";
                ConfigV2 deserializedConfigV2 = new ConfigV2();
                ConfigV3 deserializedConfigV3 = new ConfigV3();

                if (File.Exists(configPath))
                {
                    string configContent = File.ReadAllText(configPath);

                    if (Patchables.configVersion == 2)
                    {
                        deserializedConfigV2 = JsonConvert.DeserializeObject<ConfigV2>(configContent);
                        Map.events = deserializedConfigV2.events;
                    }
                    else if (Patchables.configVersion == 3)
                    {
                        deserializedConfigV3 = JsonConvert.DeserializeObject<ConfigV3>(configContent);

                        ConfigV3 deserializedConfig = JsonConvert.DeserializeObject<ConfigV3>(configContent);
                        string encryptedEvents = deserializedConfig.e;

                        string decryptedEvents = IntralismDecryption.Decrypt(encryptedEvents);
                        DecryptedEvents deserializedDecryptedEvents = JsonConvert.DeserializeObject<DecryptedEvents>(decryptedEvents);

                        Map.events = deserializedDecryptedEvents.events;
                    }

                    // I don't support multiple Key Layour yet -> Multiple hands
                    if (Patchables.handCount == 1)
                    {
                        Thread relaxThread = new Thread(RelaxThread);
                        relaxThread.Start();
                    }
                }
            }
            catch
            {
                // Do Nothing
            }
        }

        private static void RelaxThread()
        {
            

            for (int i = 0; i < Map.events.Count(); i++)
            {
                if (Map.events[i].data[0].ToString() == "SetSpeed")
                    continue;
                if (Map.events[i].ToString() == "MapEnd")
                    break;

                while (Patchables.currentTime >= Patchables.musicTime)
                {
                    i = 0;
                    Thread.Sleep(1);
                }

                bool right = false, down = false, left = false, up = false;

                if (Map.events[i].data[1].ToString().Contains("Right"))
                {
                    right = true;
                }
                if (Map.events[i].data[1].ToString().Contains("Up"))
                {
                    up = true;
                }
                if (Map.events[i].data[1].ToString().Contains("Down"))
                {
                    down = true;
                }
                if (Map.events[i].data[1].ToString().Contains("Left"))
                {
                    left = true;
                }

                while (Patchables.currentTime <= (float)Map.events[i].time)
                {
                    Thread.Sleep(1);
                }

                Press(right, down, left, up);
            }
        }

        private static void Press(bool right = false, bool down = false, bool left = false, bool up = false)
        {
            WindowsInput.InputSimulator wi = new WindowsInput.InputSimulator();
            if (right)
            {
                wi.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RIGHT);
            }
            if (down)
            {
                wi.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.DOWN);
            }
            if (left)
            {
                wi.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LEFT);
            }
            if (up)
            {
                wi.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.UP);
            }
            wi.Keyboard.Sleep(1);
            wi.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RIGHT);
            wi.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.DOWN);
            wi.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LEFT);
            wi.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.UP);
        }
    }
}
