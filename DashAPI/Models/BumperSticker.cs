using System;
using Newtonsoft.Json;

namespace DashAPI.Models
{
    public class BumperSticker
    {
        [JsonProperty("dateEarned")]
        public DateTime TimeEarned { get; set; }
        public string VehicleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BumperStickerImageUrl { get; set; }
    }
}