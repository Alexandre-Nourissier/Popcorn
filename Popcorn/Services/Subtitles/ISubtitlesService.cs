﻿using Popcorn.OSDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Popcorn.Services.Subtitles
{
    /// <summary>
    /// The subtitles service
    /// </summary>
    public interface ISubtitlesService
    {
        /// <summary>
        /// Get subtitles languages
        /// </summary>
        /// <returns>Languages</returns>
        Task<IEnumerable<Language>> GetSubLanguages();

        /// <summary>
        /// Search subtitles by imdb code and languages
        /// </summary>
        /// <param name="languages">Languages</param>
        /// <param name="imdbId">Imdb code</param>
        /// <param name="season">Season number</param>
        /// <param name="episode">Episode number</param>
        /// <returns></returns>
        Task<IList<Subtitle>> SearchSubtitlesFromImdb(string languages, string imdbId, int? season, int? episode);

        /// <summary>
        /// Download a subtitle to a path
        /// </summary>
        /// <param name="path">Path to download</param>
        /// <param name="subtitle">Subtitle to download</param>
        /// <returns>Downloaded subtitle path</returns>
        Task<string> DownloadSubtitleToPath(string path, Subtitle subtitle);
    }
}