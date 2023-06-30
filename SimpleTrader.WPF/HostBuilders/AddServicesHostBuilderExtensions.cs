using GameWorldDAL.Services.Forum;
using GameWorldDAL.Services.Identity;
using GameWorldDomain.Services.Forum;
using GameWorldDomain.Services.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IIdentityService, IdentityService>();
                services.AddSingleton<IForumService, ForumService>();
            });

            return host;
        }
    }
}
