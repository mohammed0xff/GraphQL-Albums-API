namespace AlbumsGraphQL.GraphQL.Artists
{
    public record AddArtistInput(string Name, string Country);
    public record UpdateArtistInput(int Id, string Name, string Country);
    public record RemoveArtistInput(int Id);

}
