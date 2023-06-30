using GameWorldDAL.Repositories.Forum.Interfaces;
using System.Data;


namespace GameWorldDAL.Repositories.Forum
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbTransaction transaction;

        public UnitOfWork(IPostRepository postRepository, IDbTransaction transaction)
        {
            PostRepository = postRepository;
            this.transaction = transaction;
        }

        public IPostRepository PostRepository { get; }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            transaction.Connection?.Close();
            transaction.Connection?.Dispose();
            transaction.Dispose();
        }
    }
}