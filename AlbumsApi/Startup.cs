using Data.DataContext;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using AlbumsGraphQL.GraphQL;
using AlbumsGraphQL.GraphQL.Albums;
using AlbumsGraphQL.Data.Reposotory.Interfaces;
using AlbumsGraphQL.Data.Reposotory.Implementations;
using AlbumsGraphQL.GraphQL.Mutations;
using AlbumsGraphQL.GraphQL.Query;
using AlbumsGraphQL.GraphQL.Artists;

namespace AlbumsGraphQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            /* Why AddPooledDbContextFactory ?
             * 
             * Entity Framework Core does not support multiple parallel operations
             * being run on the same DbContext instance. This includes both parallel
             * execution of async queries and any explicit concurrent use from multiple
             * threads. Therefore, always await async calls immediately, or use separate
             * DbContext instances for operations that execute in parallel
             * 
             * for more info : https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.entityframeworkservicecollectionextensions.addpooleddbcontextfactory?view=efcore-6.0
            */
            services.AddPooledDbContextFactory<AppDbContext>(
                op => op.UseSqlServer(Configuration.GetConnectionString("LocalSQLServer"))
            );

            services.AddScoped<IAlbumReposotory, AlbumReposotory>();
            services.AddScoped<IArtistReposotory, ArtistReposotory>();
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<ArtistType>()
                .AddType<AlbumType>()
                .AddSubscriptionType<Subscription>()
                .AddProjections()
                .AddInMemorySubscriptions();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            }); 
            
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                Path = "/graphql-voyager",
            });

            app.UseRouter(builder =>
            {
                builder.MapGet("", context =>
                {
                    context.Response.Redirect("./graphql", permanent: false);
                    return Task.FromResult(0);
                });
            });

            AppDbInitializer.SeedData(app);
        }
    }
}
