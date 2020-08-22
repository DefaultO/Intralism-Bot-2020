using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Intralism_Bot_2020;

namespace Intralism_Bot_ReB_o_ot.Decryption
{
    /// <summary>Example Usage of the Decryption. By not opening the Bot through double-clicking it, etc, but by giving example.cs as an argument. It won't run the Bot, but the example.
    /// <para>Avoid using this Converter Code 1:1 for production builds. You will have to edit my code, to make it safe to use.</para>
	/// </summary>
    public static class Example
    {
        /// <summary> Decrypts the Events of the V3 Config in the Example Folder. This automatically gets the e (events) text out of the config. And yes, I suggest using Json instead of <see cref="File.ReadAllLines(string)"/>, etc., Azuki taught me that.
        /// </summary>
        public static DecryptedEvents GetDecryptedEvents()
        {
            try
            {
                string localePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                // Btw: You can also give a path like so: @"\Example\v3\config.txt"
                // Same end result. Only benefit could be some time savings.
                encryptedConfigPath = localePath + "\\example\\v3\\config.txt",
                configContent = File.ReadAllText(encryptedConfigPath);

                ConfigV3 deserializedConfig = JsonConvert.DeserializeObject<ConfigV3>(configContent);
                string encryptedEvents = deserializedConfig.e;

                string decryptedEvents = IntralismDecryption.Decrypt(encryptedEvents);
                DecryptedEvents deserializedDecryptedEvents = JsonConvert.DeserializeObject<DecryptedEvents>(decryptedEvents);

                return deserializedDecryptedEvents;
            }
            catch (Exception)
            {
                // Do Nothing.
                return new DecryptedEvents();
            }
        }

        /// <summary> The actual Converter. It does compile the v2 config and copies over the Music and Icon File. You will have to edit line 58 (and maybe 61) manually, either by giving it some User Input by <see cref="System.Console.ReadLine()"/> or hardcoding it.
        /// </summary>
        public static void DecryptedMapBuilder()
        {
            DecryptedEvents decryptedEvents = GetDecryptedEvents();

            string localePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
            // Btw: You can also give a path like so: @"\Example\v3\config.txt"
            // Same end result. Only benefit could be some time savings.
            encryptedConfigPath = localePath + "\\example\\v3\\config.txt",
            configContent = File.ReadAllText(encryptedConfigPath);

            ConfigV3 deserializedConfig = JsonConvert.DeserializeObject<ConfigV3>(configContent);
            ConfigV2 config = new ConfigV2();
            List<Event> events = new List<Event>();

            // We have to cheat a bit since Config 3 doesn't have those
            string id = "editor.MyFriend";
            int generationType = 2;
            int environmentType = 3;
            List<object> puzzleSequencesList = new List<object>();

            // Set everything we can.
            config.id = id;
            config.name = deserializedConfig.name;
            config.info = deserializedConfig.info;
            config.levelResources = deserializedConfig.levelResources;
            config.tags = deserializedConfig.tags;
            config.handCount = deserializedConfig.handCount;
            config.moreInfoURL = deserializedConfig.moreInfoURL;
            config.speed = deserializedConfig.speed;
            config.lives = deserializedConfig.lives;
            config.maxLives = deserializedConfig.maxLives;
            config.musicFile = deserializedConfig.musicFile;
            config.musicTime = deserializedConfig.musicTime;
            config.iconFile = deserializedConfig.iconFile;
            config.generationType = generationType;
            config.environmentType = environmentType;
            config.unlockConditions = deserializedConfig.unlockConditions;
            config.hidden = deserializedConfig.hidden;
            config.checkpoints = deserializedConfig.checkpoints;
            config.puzzleSequencesList = puzzleSequencesList;
            config.events = decryptedEvents.events;

            // Create new Folder and copy over the Song and Icon, then write the config.
            string destinationPath = localePath + @"\example\v3-to-v2", destinationConfigPath = localePath + @"\example\v3-to-v2\config.txt";
            if (!Directory.Exists(destinationPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(destinationPath);
            }

            string iconPath = localePath + @"\example\v3\icon.jpg", musicPath = localePath + @"\example\v3\music.ogg";
            if (!File.Exists(destinationPath + @"\icon.jpg"))
                File.Copy(iconPath, destinationPath + @"\icon.jpg");
            if (!File.Exists(destinationPath + @"\music.ogg"))
                File.Copy(musicPath, destinationPath + @"\music.ogg");
            File.WriteAllText(destinationConfigPath, Newtonsoft.Json.JsonConvert.SerializeObject(config));
        }
    }
}
