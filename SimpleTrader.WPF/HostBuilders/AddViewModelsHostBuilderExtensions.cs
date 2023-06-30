using GameWorldDomain.Services.Forum;
using GameWorldWpf.State.Forum.Interfaces;
using GameWorldWpf.State.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient(CreateHomeViewModel);
               
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<ContactsViewModel>>(services => () => CreateContactsViewModel(services));
                services.AddSingleton<CreateViewModel<ForumViewModel>>(services => () => CreateForumViewModel(services));
                services.AddSingleton<CreateViewModel<AddPostViewModel>>(services => () => CreateAddPostViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));
                
                services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<ContactsViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<ForumViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<AddPostViewModel>>();
            });

            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel();
        }

        private static ContactsViewModel CreateContactsViewModel(IServiceProvider services)
        {
            return new ContactsViewModel();
        }

        private static ForumViewModel CreateForumViewModel(IServiceProvider services)
        {
            return new ForumViewModel();
        }

        private static AddPostViewModel CreateAddPostViewModel(IServiceProvider services)
        {
            return new AddPostViewModel(services.GetRequiredService<IForumState>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        { 
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticationState>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticationState>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}