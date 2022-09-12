# GraphQL-Albums-API
Albums GraphQL API with GraphQL and HotChocolate 

# Albums GraphQL API with [GraphQL](https://github.com/graphql-dotnet/graphql-dotnet) and [HotChocolate](https://github.com/ChilliCream/hotchocolate)


# Entities
```c#
public class Artist
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<Album> Albums { get; set; }
}
```

```c#
public class Album
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
}
```
