using RestSharp.Deserializers;
using System.Collections.Generic;

namespace Popcorn.Models.Shows
{
    public class ShowResponse
    {
        [DeserializeAs(Name = "totalShows")]
        public int TotalShows { get; set; }

        [DeserializeAs(Name = "shows")]
        public List<ShowJson> Shows { get; set; }
    }
}