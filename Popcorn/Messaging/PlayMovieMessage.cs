﻿using GalaSoft.MvvmLight.Messaging;
using Popcorn.Models.Bandwidth;
using Popcorn.Models.Movie;
using System;

namespace Popcorn.Messaging
{
    /// <summary>
    /// Used to play a movie
    /// </summary>
    public class PlayMovieMessage : MessageBase
    {
        /// <summary>
        /// The buffered movie
        /// </summary>
        public readonly MovieJson Movie;

        /// <summary>
        /// The buffer progress
        /// </summary>
        public readonly Progress<double> BufferProgress;

        /// <summary>
        /// The download rate
        /// </summary>
        public readonly Progress<BandwidthRate> BandwidthRate;

        /// <summary>
        /// Initialize a new instance of PlayMovieMessage class
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="bufferProgress">The buffer progress</param>
        /// <param name="bandwidthRate">The bandwidth rate</param>
        public PlayMovieMessage(MovieJson movie, Progress<double> bufferProgress, Progress<BandwidthRate> bandwidthRate)
        {
            Movie = movie;
            BufferProgress = bufferProgress;
            BandwidthRate = bandwidthRate;
        }
    }
}