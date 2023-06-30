using GameWorldDAL.Repositories.Forum.Interfaces;
using GameWorldDAL.Services.Identity;
using GameWorldDomain.Models.Forum;
using GameWorldDomain.Services.Forum;

namespace GameWorldDAL.Services.Forum
{
    public class ForumService : IForumService
    {
        private readonly IUnitOfWork unitOfWork;

        public ForumService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddPostAsync(string question)
        {
            bool isGuid = Guid.TryParse(IdentityService.UserId, out Guid userId);

            if (!isGuid) 
            {
                throw new ArgumentException("Error during getting UserId.");
            }

            Post post = new()
            {
                Id = Guid.NewGuid(),
                Title = question,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            await unitOfWork.PostRepository.AddAsync(post);

            unitOfWork.Commit();
        }
    }
}