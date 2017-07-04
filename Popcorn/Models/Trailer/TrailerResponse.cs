using RestSharp.Deserializers;

namespace Popcorn.Models.Trailer
{
    public class TrailerResponse
    {
        [DeserializeAs(Name = "trailer_url")]
        public string TrailerUrl { get; set; }
    }
}