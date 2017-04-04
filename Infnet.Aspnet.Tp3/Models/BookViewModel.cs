using System.ComponentModel.DataAnnotations;

namespace Infnet.Aspnet.Tp3.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "Max length is 255 caracters", MinimumLength = 2), Required]
        public string Author { get; set; }

        [StringLength(255, ErrorMessage = "Max length is 255 caracters", MinimumLength = 2), Required]
        public string Publisher { get; set; }

        [StringLength(255, ErrorMessage = "Max length is 255 caracters", MinimumLength = 2), Required]
        public string Title { get; set; }

        [Range(0, 2030, ErrorMessage = "The year is not valid"), Required]
        public int Year { get; set; }

        public bool Available { get; set; }
    }
}