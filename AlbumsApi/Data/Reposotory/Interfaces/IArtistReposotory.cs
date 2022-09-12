using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.Data.Reposotory.Interfaces
{
    public interface IArtistReposotory
    {
        IQueryable<Artist> GetAllArtists(CancellationToken cancellationToken);
        Task<Artist> GetArtist(int artistId, CancellationToken cancellationToken);
        Task<Artist> AddArtist(Artist artist, CancellationToken cancellationToken);
        Task<Artist> UpdateArtist(Artist artist, CancellationToken cancellationToken);
        Task<Artist> RemoveArtist(int artistId, CancellationToken cancellationToken);
        Task<bool> ArtistExists(string artistName, CancellationToken cancellationToken);
    }
}
