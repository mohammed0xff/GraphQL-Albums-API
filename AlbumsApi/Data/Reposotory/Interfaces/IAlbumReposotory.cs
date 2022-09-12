using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.Data.Reposotory.Interfaces
{
    public interface IAlbumReposotory
    {
        IQueryable<Album> GetAllAlbums(CancellationToken cancellationToken);
        IQueryable<Album> GetAlbumsByArtistId(int artistId);
        Task<Album> GetAlbum(int albumId, CancellationToken cancellationToken);
        Task<Album> AddAlbum(Album album, CancellationToken cancellationToken);
        Task<Album> UpdateAlbum(Album album, CancellationToken cancellationToken);
        Task<Album> RemoveAlbum(int albumId, CancellationToken cancellationToken);
        Task<bool> AlbumExists(string title, CancellationToken cancellationToken);
    }
}
