using GameWorldDAL.Repositories.Forum.Interfaces;
using GameWorldDomain.Models.Forum;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GameWorldDAL.Repositories.Forum
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction) :
            base(sqlConnection, dbTransaction, "forum.Posts")
        { }
    }
}