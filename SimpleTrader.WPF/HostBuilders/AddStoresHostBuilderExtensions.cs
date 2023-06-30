using GameWorldWpf.State.Forum;
using GameWorldWpf.State.Forum.Interfaces;
using GameWorldWpf.State.Identity;
using GameWorldWpf.State.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticationState, AuthenticationState>();
                services.AddSingleton<IForumState, ForumState>();
            });

            return host;
        }
    }
}