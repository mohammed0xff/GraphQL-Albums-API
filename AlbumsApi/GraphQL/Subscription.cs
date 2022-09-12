using AlbumsGraphQL.Models;

namespace AlbumsGraphQL.GraphQL
{
    public class Subscription
    {
        [Topic]
        [Subscribe]
        public Artist OnArtistAdded([EventMessage] Artist artist) => artist;
    }
}
