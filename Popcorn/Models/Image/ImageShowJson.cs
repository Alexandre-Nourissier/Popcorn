using RestSharp.Deserializers;

namespace Popcorn.Models.Image
{
    public class ImageShowJson
    {
        [DeserializeAs(Name = "poster")]
        public string Poster { get; set; }

        [DeserializeAs(Name = "fanart")]
        public string Fanart { get; set; }

        [DeserializeAs(Name = "banner")]
        public string Banner { get; set; }
    }
}