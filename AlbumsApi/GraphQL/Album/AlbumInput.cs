namespace AlbumsGraphQL.GraphQL.Albums
{
    public record AddAlbumInput(string Title, string Genre, int ArtistId);
    public record UpdateAlbumInput(int Id, string Title, string Genre, int ArtistId);
    public record RemoveAlbumInput(int Id);

}
