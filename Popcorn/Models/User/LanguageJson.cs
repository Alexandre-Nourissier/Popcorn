using RestSharp.Deserializers;

namespace Popcorn.Models.User
{
    public class LanguageJson
    {
        [DeserializeAs(Name = "Culture")]
        public string Culture { get; set; }

        public string Name { get; set; }
    }
}