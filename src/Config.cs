using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intralism_Bot_2020
{
    /// <summary>Class that I have generated using json2csharp by copy-pasting the whole V3 Example Config into the input. I started using that service, since I had to work with Web API Responses. Genuinely recommending it.
	/// <para>Visit <see href="https://json2csharp.com/">json2csharp.com</see> to save some time by being smarter.</para>
	/// </summary>
    public class ConfigV3
    {
        public int configVersion { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public List<object> levelResources { get; set; }
        public List<string> tags { get; set; }
        public int handCount { get; set; }
        public string moreInfoURL { get; set; }
        public double speed { get; set; }
        public int lives { get; set; }
        public int maxLives { get; set; }
        public string musicFile { get; set; }
        public double musicTime { get; set; }
        public string iconFile { get; set; }
        public int environmentType { get; set; }
        public List<object> unlockConditions { get; set; }
        public bool hidden { get; set; }
        public List<double> checkpoints { get; set; }
        public List<Event> events { get; set; }
        public string e { get; set; }
    }

    /// <summary>Class that I have generated using json2csharp by copy-pasting the whole V2 Example Config into the input. I started using that service, since I had to work with Web API Responses. Genuinely recommending it.
	/// <para>Visit <see href="https://json2csharp.com/">json2csharp.com</see> to save some time by being smarter.</para>
	/// </summary>
    public class ConfigV2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public List<object> levelResources { get; set; }
        public List<string> tags { get; set; }
        public int handCount { get; set; }
        public string moreInfoURL { get; set; }
        public double speed { get; set; }
        public int lives { get; set; }
        public int maxLives { get; set; }
        public string musicFile { get; set; }
        public double musicTime { get; set; }
        public string iconFile { get; set; }
        public int generationType { get; set; }
        public int environmentType { get; set; }
        public List<object> unlockConditions { get; set; }
        public bool hidden { get; set; }
        public List<double> checkpoints { get; set; }
        public List<object> puzzleSequencesList { get; set; }
        public List<Event> events { get; set; }
    }

    /// <summary>Class that I have generated using json2csharp by copy-pasting the whole V3 Example Config into the input. I started using that service, since I had to work with Web API Responses. Genuinely recommending it.
	/// <para>Visit <see href="https://json2csharp.com/">json2csharp.com</see> to save some time by being smarter.</para>
	/// </summary>
    public class Event
    {
        public double time { get; set; }
        public List<string> data { get; set; }
    }

    /// <summary>Class that I have generated using json2csharp by copy-pasting the decryptedEvents (line 22) string into the input. I started using that service, since I had to work with Web API Responses. Genuinely recommending it.
	/// <para>Visit <see href="https://json2csharp.com/">json2csharp.com</see> to save some time by being smarter.</para>
	/// </summary>
    public class DecryptedEvents
    {
        public int version { get; set; }
        public List<Event> events { get; set; }
    }
}
