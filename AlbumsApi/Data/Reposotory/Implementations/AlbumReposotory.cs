using AlbumsGraphQL.Data.Reposotory.Interfaces;
using AlbumsGraphQL.Models;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Data.DataContext;

namespace AlbumsGraphQL.Data.Reposotory.Implementations
{

    public class AlbumReposotory : IAlbumReposotory
    {

        private readonly AppDbContext _dbContext;

        public AlbumReposotory(IDbContextFactory<AppDbContext> dbContext)
        {
            _dbContext = dbContext.CreateDbContextAsync().Result;
        }

        public IQueryable<Album> GetAllAlbums(CancellationToken cancellationToken)
        {
            return _dbContext.Albums.AsQueryable();
        }

        public async Task<Album> AddAlbum(Album Album, CancellationToken cancellationToken)
        {
            await _dbContext.Albums.AddAsync(Album, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Album;
        }


        public async Task<bool> AlbumExists(string title, CancellationToken cancellationToken)
        {
            return await _dbContext.Albums
                 .AsNoTracking()
                 .AnyAsync(c => c.Title == title, cancellationToken);
        }


        public async Task<Album> GetAlbum(int AlbumId, CancellationToken cancellationToken)
        {
            return await _dbContext.Albums.FirstOrDefaultAsync(c => c.Id == AlbumId, cancellationToken);
        }


        public async Task<Album> UpdateAlbum(Album album, CancellationToken cancellationToken)
        {
            var Album = await _dbContext.Albums.FirstOrDefaultAsync(x => x.Id == album.Id, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Album;
        }


        public async Task<Album> RemoveAlbum(int AlbumId, CancellationToken cancellationToken)
        {
            var Album = await _dbContext.Albums.FirstOrDefaultAsync(c => c.Id == AlbumId);
            _dbContext.Albums.Remove(Album);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Album;
        }

        public IQueryable<Album> GetAlbumsByArtistId(int artistId)
        {
            return _dbContext.Albums
                .Where(x => x.ArtistId == artistId)
                .AsQueryable();
        }
    }
}
