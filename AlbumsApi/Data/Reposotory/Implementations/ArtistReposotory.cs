using AlbumsGraphQL.Data.Reposotory.Interfaces;
using AlbumsGraphQL.Models;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Data.DataContext;

namespace AlbumsGraphQL.Data.Reposotory.Implementations
{
    public class ArtistReposotory : IArtistReposotory
    {

        private readonly AppDbContext _dbContext;

        public ArtistReposotory(IDbContextFactory<AppDbContext> dbContext)
        {
            _dbContext = dbContext.CreateDbContextAsync().Result;
        }

        public IQueryable<Artist> GetAllArtists(CancellationToken cancellationToken)
        {
            var res = _dbContext.Artists
                .AsQueryable();
            return res;
        }

        public async Task<Artist> AddArtist(Artist Artist, CancellationToken cancellationToken)
        {
            await _dbContext.Artists.AddAsync(Artist, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Artist;

        }
        public async Task<bool> ArtistExists(string ArtistName, CancellationToken cancellationToken)
        {
            return await _dbContext.Artists
                 .AsNoTracking()
                 .AnyAsync(c => c.Name == ArtistName, cancellationToken);
        }

        public async Task<Artist> GetArtist(int ArtistId, CancellationToken cancellationToken)
        {
            return await _dbContext.Artists.FirstOrDefaultAsync(c => c.Id == ArtistId, cancellationToken);
        }

        public async Task<Artist> UpdateArtist(Artist artist, CancellationToken cancellationToken)
        {
            var Artist = await _dbContext.Artists.FirstOrDefaultAsync(x => x.Id == artist.Id, cancellationToken);
            _dbContext.Artists.Update(Artist);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Artist;
        }

        public async Task<Artist> RemoveArtist(int ArtistId, CancellationToken cancellationToken)
        {
            var Artist = await _dbContext.Artists.FirstOrDefaultAsync(c => c.Id == ArtistId);
            _dbContext.Artists.Remove(Artist);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Artist;
        }

    }
}
