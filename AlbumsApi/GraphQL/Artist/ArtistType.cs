using Data.DataContext;
using HotChocolate;
using HotChocolate.Types;
using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.GraphQL.Artists
{
    public class ArtistType : ObjectType<Artist>
    {
        protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
        {
            descriptor.Description("Any Artist that has available Albums.");

            descriptor
                .Field(p => p.Albums)
                .ResolveWith<Resolvers>(p => p.GetAlbums(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("this is a list of available Albums for this Artist");
            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IQueryable<Album> GetAlbums([Parent] Artist Artist, [ScopedService] AppDbContext context)
            {
                return context.Albums.Where(x => x.Artist == Artist).AsQueryable();
            }
        }

    }
}
