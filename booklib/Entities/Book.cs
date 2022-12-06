using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booklib.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Kitap Adı zorunludur.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Kitap Türü zorunludur.")]
        public string BookType { get; set; }

        [Required(ErrorMessage = "Yazar Bilgisi zorunludur.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Konu zorunludur.")]
        public string BookSubject { get; set; }

        [Required(ErrorMessage = "Stok bilgisi zorunludur.")]
        public int Stock { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        
        [StringLength(255)]
        public string? BookImageFileName { get; set; }

        public DateTime AddBookDate { get; set; } = DateTime.Now;

        //public ICollection<Lib> Libs { get; set; }


    }
}
