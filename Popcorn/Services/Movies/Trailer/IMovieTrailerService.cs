using Popcorn.Models.Movie;
using System.Threading;
using System.Threading.Tasks;

namespace Popcorn.Services.Movies.Trailer
{
    public interface IMovieTrailerService
    {
        Task LoadTrailerAsync(MovieJson movie, CancellationToken ct);
    }
}