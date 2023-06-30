using GameWorldDAL.Repositories.Forum;
using GameWorldDAL.Repositories.Forum.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameWorldWpf.HostBuilders
{
    public static class AddRepositoriesHostBuilderExtension
    {
        public static IHostBuilder AddRepositories(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                // UnitOfWork
                services.AddSingleton<IUnitOfWork, UnitOfWork>();

                // Repositories
                services.AddSingleton<IPostRepository, PostRepository>();
            });

            return host;
        }
    }
}