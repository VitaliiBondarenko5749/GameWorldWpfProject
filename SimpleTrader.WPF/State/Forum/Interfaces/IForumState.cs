using System;
using System.Threading.Tasks;

namespace GameWorldWpf.State.Forum.Interfaces
{
    public interface IForumState
    {
        Task AddPostAsync(string question);
    }
}