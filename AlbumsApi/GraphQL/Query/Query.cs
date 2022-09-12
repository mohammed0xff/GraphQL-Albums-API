using AlbumsGraphQL.Data.Reposotory.Interfaces;
using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.GraphQL.Query
{
    public class Query
    {

        public IQueryable<Artist> GetArtist(
            [Service] IArtistReposotory reposotory,
            CancellationToken cancellationToken)
        {
            return reposotory.GetAllArtists(cancellationToken);
        }


        public IQueryable<Album> GetAlbum(
            [Service] IAlbumReposotory reposotory,
            CancellationToken cancellationToken
            )
        {
            return reposotory.GetAllAlbums(cancellationToken);
        }
    }
}
