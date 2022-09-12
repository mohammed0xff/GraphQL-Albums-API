using HotChocolate.Subscriptions;
using AlbumsGraphQL.Data.Reposotory.Interfaces;
using AlbumsGraphQL.GraphQL.Albums;
using AlbumsGraphQL.GraphQL.Artists;
using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.GraphQL.Mutations
{
    public class Mutation
    {
        public async Task<ArtistPayload> AddArtistAsync(AddArtistInput input,
            [Service] IArtistReposotory reposotory,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancelationToken
            )
        {
            var Artist = new Artist
            {
                Name = input.Name,
                Country = input.Country,
            };
            await reposotory.AddArtist(Artist, cancelationToken);
            await eventSender.SendAsync(nameof(Subscription.OnArtistAdded), Artist, cancelationToken);
            return new ArtistPayload(Artist);
        }


        public async Task<ArtistPayload> UpdateArtistAsync(UpdateArtistInput input,
        [Service] IArtistReposotory reposotory,
        CancellationToken cancelationToken
        )
        {
            var Artist = reposotory.GetArtist(input.Id, cancelationToken).Result;
            if (Artist != null)
            {
                Artist.Name = input.Name;
                Artist.Country = input.Country;
                await reposotory.UpdateArtist(Artist, cancelationToken);
            }
            return new ArtistPayload(Artist);
        }



        public async Task<ArtistPayload> RemoveArtistAsync(RemoveArtistInput input,
        [Service] IArtistReposotory reposotory,
        CancellationToken cancelationToken
        )
        {
            return new ArtistPayload(
                await reposotory.RemoveArtist(input.Id, cancelationToken)
                );
        }

        //
        //    Albums Mutations 
        //

        public async Task<AlbumPayload> AddAlbumAsync(AddAlbumInput input,
         [Service] IAlbumReposotory reposotory,
         CancellationToken cancelationToken
         )
        {
            var Album = new Models.Album
            {
                Title = input.Title,
                Genre = input.Genre,
                ArtistId = input.ArtistId
            };
            await reposotory.AddAlbum(Album, cancelationToken);
            return new AlbumPayload(Album);
        }

        public async Task<AlbumPayload> UpdateAlbumAsync(UpdateAlbumInput input,
        [Service] IAlbumReposotory reposotory,
        CancellationToken cancelationToken
        )
        {
            var Album = await reposotory.GetAlbum(input.Id, cancelationToken);
            if (Album != null)
            {
                Album.Title = input.Title;
                Album.Genre = input.Genre;
                Album.ArtistId = input.ArtistId;
                await reposotory.UpdateAlbum(Album, cancelationToken);
            }
            return new AlbumPayload(Album);
        }

        public async Task<AlbumPayload> RemoveAlbumAsync(RemoveAlbumInput input,
        [Service] IAlbumReposotory reposotory,
        CancellationToken cancelationToken
        )
        {
            return new AlbumPayload(
                await reposotory.RemoveAlbum(input.Id, cancelationToken)
            );
        }


    }

}


