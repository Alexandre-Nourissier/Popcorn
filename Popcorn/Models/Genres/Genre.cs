using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Popcorn.Models.Genres
{
    public class GenreJson
    {
        [DeserializeAs(Name = "EnglishName")]
        public string EnglishName { get; set; }

        [DeserializeAs(Name = "Name")]
        public string Name { get; set; }
    }

    public class GenreResponse
    {
        [DeserializeAs(Name = "genres")]
        public List<GenreJson> Genres { get; set; }
    }
}