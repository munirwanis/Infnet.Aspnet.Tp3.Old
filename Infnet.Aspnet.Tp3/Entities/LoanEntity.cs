using System;

namespace Infnet.Aspnet.Tp3.Entities
{
    public class LoanEntity : BaseEntity
    {
        public int Id { get; set; }

        public DateTime LoanDate { get; set; }
        
        public DateTime DevolutionDate { get; set; }

        public int BookId { get; set; }
    }
}