﻿using Popcorn.YTVideoProvider.Helpers;
using System;
using System.Threading.Tasks;

namespace Popcorn.YTVideoProvider
{
    public partial class YouTubeVideo : Video
    {
        private string uri;
        private bool encrypted;

        internal YouTubeVideo(string title,
            UnscrambledQuery query, string jsPlayer, bool manifestExist = false)
        {
            this.Title = title;
            this.uri = query.Uri;
            this.jsPlayer = jsPlayer;
            this.encrypted = query.IsEncrypted;
            if (manifestExist)
            {
                // Link contain "key/value"
                // separated by slash
                string x = uri.Substring(uri.IndexOf("itag/") + 5, 3);
                x = x.TrimEnd('/'); // In case format is 2-digit
                this.FormatCode = int.Parse(x);
            }
            else this.FormatCode = int.Parse(new Query(uri)["itag"]);
        }

        public override string Title { get; }
        public override WebSites WebSite => WebSites.YouTube;

        public override Task<string> GetUriAsync()
        {
            return GetUriAsync(() => new DelegatingClient());
        }

        public async Task<string> GetUriAsync(Func<DelegatingClient> makeClient)
        {
            if (encrypted)
            {
                uri = await
                    DecryptAsync(uri, makeClient)
                        .ConfigureAwait(false);
                encrypted = false;
            }

            return uri;
        }

        public int FormatCode { get; }
        public bool IsEncrypted => encrypted;
    }
}