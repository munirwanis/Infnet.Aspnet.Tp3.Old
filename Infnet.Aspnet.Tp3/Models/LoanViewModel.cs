using Infnet.Aspnet.Tp3.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infnet.Aspnet.Tp3.Models
{
    [StartLessThanEnd(ErrorMessage = "Start Date must be before the end Date")]
    public class LoanViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomDateRange(7, ErrorMessage = "The LoanDate must not exceed 7 days from now")]
        public DateTime LoanDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomDateRange(7, ErrorMessage = "The DevolutionDate must not exceed 7 days from the LoanDate")]
        public DateTime DevolutionDate { get; set; }

        [Required]
        public int BookId { get; set; }

        public BookViewModel Book { get; set; }

        public List<BookViewModel> Books { get; set; }
    }
}