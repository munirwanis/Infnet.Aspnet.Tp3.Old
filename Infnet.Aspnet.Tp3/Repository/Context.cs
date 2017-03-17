using System.IO;

namespace Infnet.Aspnet.Tp3.Repository
{
    public class Context
    {
        private string connString; // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrador\Desktop\Infnet.Aspnet.Tp3\Infnet.Aspnet.Tp3\App_Data\BookStore.mdf;Integrated Security=True";
        public IRepository BooksRepository { get; }
        public Context()
        {
            this.connString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory().Replace(@"bin", @"\App_Data\BookStore.mdf")};Integrated Security=True";
            this.BooksRepository = new BooksRepository(this.connString);
        }
    }
}