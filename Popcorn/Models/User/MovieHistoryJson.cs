using RestSharp.Deserializers;

namespace Popcorn.Models.User
{
    public class MovieHistoryJson
    {
        [DeserializeAs(Name = "ImdbId")]
        public string ImdbId { get; set; }

        [DeserializeAs(Name = "Seen")]
        public bool Seen { get; set; }

        [DeserializeAs(Name = "Favorite")]
        public bool Favorite { get; set; }
    }
}