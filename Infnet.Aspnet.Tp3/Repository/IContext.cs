using Infnet.Aspnet.Tp3.Entities;

namespace Infnet.Aspnet.Tp3.Repository
{
    public interface IContext
    {
        IRepository<BooksEntity> BooksRepository { get; }
    }
}
