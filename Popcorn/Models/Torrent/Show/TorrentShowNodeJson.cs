using RestSharp.Deserializers;

namespace Popcorn.Models.Torrent.Show
{
    public class TorrentShowNodeJson
    {
        [DeserializeAs(Name = "0")]
        public TorrentShowJson Torrent_0 { get; set; }

        [DeserializeAs(Name = "480p")]
        public TorrentShowJson Torrent_480p { get; set; }

        [DeserializeAs(Name = "720p")]
        public TorrentShowJson Torrent_720p { get; set; }

        [DeserializeAs(Name = "1080p")]
        public TorrentShowJson Torrent_1080p { get; set; }
    }
}