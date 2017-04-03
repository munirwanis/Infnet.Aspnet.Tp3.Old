using Infnet.Aspnet.Tp3.Entities;

namespace Infnet.Aspnet.Tp3.Repository
{
    public class Context : IContext
    {
        private string connString; // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrador\Desktop\Infnet.Aspnet.Tp3\Infnet.Aspnet.Tp3\App_Data\BookStore.mdf;Integrated Security=True";
        public IRepository<BooksEntity> BooksRepository { get; }
        public Context(IRepository<BooksEntity> booksRepository)
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            this.connString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={baseDirectory}App_Data\BookStore.mdf;Integrated Security=True";
            this.BooksRepository = booksRepository;
        }
    }
}