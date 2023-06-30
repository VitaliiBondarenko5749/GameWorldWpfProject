namespace GameWorldDAL.Repositories.Forum.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }

        void Commit();
        new void Dispose();
    }
}