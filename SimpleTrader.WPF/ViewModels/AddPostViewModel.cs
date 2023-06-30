using GameWorldWpf.Commands;
using GameWorldWpf.State.Forum.Interfaces;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System.Windows.Input;

namespace SimpleTrader.WPF.ViewModels
{
    public class AddPostViewModel : ViewModelBase
    {
        private string question;

        public string Question
        {
            get { return question; }
            set
            {
                question = value;

                OnPropertyChanged(nameof(Question));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand AskQuestionCommand { get; }

        public AddPostViewModel(IForumState forumState)
        {
            ErrorMessageViewModel = new MessageViewModel();

            AskQuestionCommand = new AddPostCommand(this, forumState);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}