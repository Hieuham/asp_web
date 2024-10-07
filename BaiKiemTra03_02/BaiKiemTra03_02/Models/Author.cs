using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_02.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống Tên tác giả !")]
        [StringLength(10, ErrorMessage = "{0} độ dài phải từ {2} đến {1} kí tự", MinimumLength = 8)]
        [Display(Name = "Tác giả")]
        public string Name { get; set; }
        [Required]
        public string nationality { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày !")]
        [Display(Name = "Năm sinh")]
        public DateTime birth_year { get; set; } = DateTime.Now;

    }
}
