﻿using GalaSoft.MvvmLight.Messaging;
using NLog;
using Popcorn.Helpers;
using Popcorn.Messaging;
using Popcorn.Models.Movie;
using Popcorn.Services.Movies.Movie;
using Popcorn.Utils.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Popcorn.Services.Movies.Trailer
{
    /// <summary>
    /// Manage trailer
    /// </summary>
    public sealed class MovieTrailerService : IMovieTrailerService
    {
        /// <summary>
        /// Logger of the class
        /// </summary>
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The service used to interact with movies
        /// </summary>
        private IMovieService MovieService { get; }

        /// <summary>
        /// Initializes a new instance of the TrailerViewModel class.
        /// </summary>
        /// <param name="movieService">Movie service</param>
        public MovieTrailerService(IMovieService movieService)
        {
            MovieService = movieService;
        }

        /// <summary>
        /// Load movie's trailer asynchronously
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="ct">Cancellation token</param>
        public async Task LoadTrailerAsync(MovieJson movie, CancellationToken ct)
        {
            try
            {
                var trailer = await MovieService.GetMovieTrailerAsync(movie, ct);
                if (!ct.IsCancellationRequested && string.IsNullOrEmpty(trailer))
                {
                    Logger.Error(
                        $"Failed loading movie's trailer: {movie.Title}");
                    Messenger.Default.Send(
                        new ManageExceptionMessage(
                            new PopcornException(
                                LocalizationProviderHelper.GetLocalizedValue<string>("TrailerNotAvailable"))));
                    Messenger.Default.Send(new StopPlayingTrailerMessage(Utils.MediaType.Movie));
                    return;
                }

                if (!ct.IsCancellationRequested)
                {
                    Logger.Debug(
                        $"Movie's trailer loaded: {movie.Title}");
                    Messenger.Default.Send(new PlayTrailerMessage(trailer, movie.Title, () =>
                        {
                            Messenger.Default.Send(new StopPlayingTrailerMessage(Utils.MediaType.Movie));
                        },
                        () =>
                        {
                            Messenger.Default.Send(new StopPlayingTrailerMessage(Utils.MediaType.Movie));
                        }, Utils.MediaType.Movie));
                }
            }
            catch (Exception exception) when (exception is TaskCanceledException)
            {
                Logger.Debug(
                    "GetMovieTrailerAsync cancelled.");
                Messenger.Default.Send(new StopPlayingTrailerMessage(Utils.MediaType.Movie));
            }
            catch (Exception exception)
            {
                Logger.Error(
                    $"GetMovieTrailerAsync: {exception.Message}");
                Messenger.Default.Send(
                    new ManageExceptionMessage(
                        new PopcornException(
                            LocalizationProviderHelper.GetLocalizedValue<string>(
                                "TrailerNotAvailable"))));
                Messenger.Default.Send(new StopPlayingTrailerMessage(Utils.MediaType.Movie));
            }
        }
    }
}