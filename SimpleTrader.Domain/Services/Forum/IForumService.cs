using GameWorldDomain.Models.Forum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameWorldDomain.Services.Forum
{
    public interface IForumService
    {
        Task AddPostAsync(string content);
    }
}