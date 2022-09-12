using Data.DataContext;
using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.GraphQL.Albums
{
    public class AlbumType : ObjectType<Album>
    {
        protected override void Configure(IObjectTypeDescriptor<Album> descriptor)
        {
            descriptor.Description("Represents any Album");
            descriptor
                .Field(c => c.Artist)
                .ResolveWith<Resolvers>(c => c.GetArtist(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("this is the Artist to which the Album belongs.");
            
            base.Configure(descriptor);
        }
        private class Resolvers
        {
            public Artist? GetArtist(Album Album, [ScopedService] AppDbContext context)
            {
                return context.Artists.FirstOrDefault(p => p.Id == Album.ArtistId);
            }
        }

    }
}
