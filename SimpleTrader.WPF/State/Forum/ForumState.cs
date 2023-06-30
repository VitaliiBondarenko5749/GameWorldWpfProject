using GameWorldDomain.Services.Forum;
using GameWorldWpf.State.Forum.Interfaces;
using System.Threading.Tasks;

namespace GameWorldWpf.State.Forum
{
    class ForumState : IForumState
    {
        private readonly IForumService forumService;

        public ForumState(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public async Task AddPostAsync(string question)
        {
            await forumService.AddPostAsync(question);
        }
    }
}