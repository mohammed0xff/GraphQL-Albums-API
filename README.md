# GraphQL-Albums-API

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
<br/>

## Sample query request
```graphql
query{
  artist{
    id
    name
    country
    albums{
      id
      title
      
    }
  }
}
```
## Response 
```json
{
  "data": {
    "artist": [
      {
        "id": 1,
        "name": "The Doors",
        "country": "USA",
        "albums": [
          {
            "id": 1,
            "title": "LA Woman"
          },
          {
            "id": 2,
            "title": "Strange Days"
          }
        ]
      },
      {
        "id": 2,
        "name": "Country Joe and the Fish",
        "country": "USA",
        "albums": [
          {
            "id": 3,
            "title": "Here We Are Again"
          },
          {
            "id": 4,
            "title": "Together"
          }
        ]
      },
      {
        "id": 3,
        "name": "Janis Joplin",
        "country": "USA",
        "albums": [
          {
            "id": 5,
            "title": "Pearl"
          }
        ]
      },
      {
        "id": 4,
        "name": "Pink Floyd",
        "country": "UK",
        "albums": [
          {
            "id": 6,
            "title": "The Dark Side of the Moon"
          },
          {
            "id": 7,
            "title": "The Division Bell"
          }
        ]
      }
    ]
  }
}
```

<br/>

## sample mutation request
```graphql
mutation {
    addAlbum (
        input: {
            artistId : 1
            genre : "Rock"
            title : "The Soft Parade"
        }
    )
    {
        album {
          id
          genre  
          title
        }
        
    }
}
```
## Response 

```json
{
  "data": {
    "addAlbum": {
      "album": {
        "id": 3,
        "genre": "Rock",
        "title": "The Soft Parade"
      }
    }
  }
}
```
<br/>

## How to run : 
#### 1. start SQL server 
```bash
docker compose up -d 
```
#### 2. Update database
```bash
dotnet ef database update
```
#### 3. restore n run
```bash 
dotnet restore && dotnet run
```

## License

[![Licence](https://img.shields.io/github/license/Ileriayo/markdown-badges?style=for-the-badge)](./LICENSE)

