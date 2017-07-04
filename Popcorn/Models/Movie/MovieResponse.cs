using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Popcorn.Models.Movie
{
    public class MovieResponse
    {
        [DeserializeAs(Name = "totalMovies")]
        public int TotalMovies { get; set; }

        [DeserializeAs(Name = "movies")]
        public List<MovieJson> Movies { get; set; }
    }
}