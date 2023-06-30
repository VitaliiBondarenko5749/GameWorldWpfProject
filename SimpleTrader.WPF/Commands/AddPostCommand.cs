using GameWorldWpf.State.Forum.Interfaces;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GameWorldWpf.Commands
{
    public class AddPostCommand : AsyncCommandBase
    {
        private readonly AddPostViewModel addPostViewModel;
        private readonly IForumState forumState;

        public AddPostCommand(AddPostViewModel addPostViewModel, IForumState forumState)
        {
            this.addPostViewModel = addPostViewModel;
            this.forumState = forumState;

            addPostViewModel.PropertyChanged += AddPostViewModel_PropertyChanged;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await forumState.AddPostAsync(addPostViewModel.Question);
            }
            catch (Exception)
            {
                addPostViewModel.ErrorMessage = "Question was not added.";
            }
        }

        private void AddPostViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}