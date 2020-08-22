using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intralism_Bot_2020
{
    /// <summary>
    /// Class containing all the latest working Pointers that are neccessary for this bot to work perfectly fine. Check out <see href="https://github.com/DefaultO/Intralism-Patchables">Intralism-Patchables (Gíthub)</see> for the latest working ones (if I finally start to use that repository).
    /// </summary>
    public static class Patchables
    {
        public static int configVersion = 0;
        public static Pointer configVersionPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "68" }
        };

        public static int handCount = 0;
        public static Pointer handCountPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "6C" }
        };

        public static int fullevelPathLength = 0;
        public static Pointer fullLevelPathLengthPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "28", "10" }
        };

        public static string fullevelPathValue = "";
        public static Pointer fullLevelPathValuePointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "28", "14" }
        };

        public static int mapNameLength = 0;
        public static Pointer mapNameLengthPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "10", "10" }
        };

        public static string mapName = "";
        public static Pointer mapNamePointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "10", "14" }
        };

        public static float currentTime = 0f;
        public static Pointer currenTimePointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "458", "80", "15C" }
        };

        public static float musicTime = 0;
        public static Pointer musicTimePointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "7C" }
        };

        public static float speed = 0f;
        public static Pointer speedPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "38", "18", "70" }
        };

        public static float arcsDelay = 0f;
        public static Pointer arcsDelayPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "234" }
        };

        public static float playerDistance = 0f;
        public static Pointer playerDistancePointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "104" }
        };

        public static int currentEventID = 0;
        public static Pointer currentEventIDPointer = new Pointer
        {
            Module = "mono.dll",
            Offset = "0x00501AC8",
            Offsets = new string[] { "20", "7E8", "5F0", "38", "230" }
        };
    }

    /// <summary>
    /// Basic Pointer Structure fit to the memory.dll Library. Inspired by <see href="https://github.com/Azukee">Azuki's</see> Memory Class.
    /// </summary>
    public class Pointer
    {
        public string Module;
        public string Offset;
        public string[] Offsets;

        /// <summary>
        /// Return every part of the Pointer into a single String useable by the memory.dll Library.
        /// </summary>
        public string Get()
        {
            // mono.dll+0x00501AC8,20,458,80,15C
            string pointer = String.Format("{0}+{1}", this.Module, Offset);
            foreach (string offset in this.Offsets)
            {
                pointer = String.Format("{0},{1}", pointer, offset);
            }
            return pointer;
        }
    }
}
