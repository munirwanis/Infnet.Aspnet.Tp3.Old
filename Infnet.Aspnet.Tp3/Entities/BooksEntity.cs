namespace Infnet.Aspnet.Tp3.Entities
{
    public class BooksEntity : BaseEntity
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}