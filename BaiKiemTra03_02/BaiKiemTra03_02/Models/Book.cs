using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime publication_year { get; set; } = DateTime.Now;
        [Required]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}
