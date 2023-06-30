using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<ContactsViewModel> _createContactsViewModel;
        private readonly CreateViewModel<ForumViewModel> _createForumViewModel;
        private readonly CreateViewModel<AddPostViewModel> _createAddPostViewModel;

        public SimpleTraderViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel, CreateViewModel<ContactsViewModel> createContactsViewModel,
            CreateViewModel<ForumViewModel> createForumViewModel, CreateViewModel<AddPostViewModel> createAddPostViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createContactsViewModel = createContactsViewModel;
            _createForumViewModel = createForumViewModel;
            _createAddPostViewModel = createAddPostViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Contacts:
                    return _createContactsViewModel();
                case ViewType.Forum:
                    return _createForumViewModel();
                case ViewType.AddPost:
                    return _createAddPostViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
