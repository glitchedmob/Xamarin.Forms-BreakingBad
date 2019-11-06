using System.Collections.Generic;
using Newtonsoft.Json;

namespace BreakingBad.Model
{
    public class Character
    {
        [JsonProperty("char_id")]
        public int CharId { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public List<string> Occupation { get; set; }
        public string Img { get; set; }
        public string Status { get; set; }
        public string Nickname { get; set; }
        public List<int> Appearance { get; set; }
        public string Portrayed { get; set; }
        public string Category { get; set; }
        [JsonProperty("better_call_saul_appearance")]
        public List<int> BetterCallSaulAppearance { get; set; }
    }
}