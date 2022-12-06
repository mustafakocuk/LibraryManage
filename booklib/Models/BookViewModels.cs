using booklib.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace booklib.Models
{
    public class BookModel
    {
        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string BookType { get; set; }

        public string BookSubject { get; set; }

        public string Author { get; set; }

        public int Stock { get; set; }

        public string? BookImageFileName { get; set; }

        public DateTime PublishingDate { get; set; }

        public string? Done { get; set; }
    }

    public class BookCreateModel
    {
        public string BookName { get; set; }

        public string BookType { get; set; }

        public string BookSubject { get; set; }

        public string Author { get; set; }

        public int Stock { get; set; }

        public string BookImageFileName { get; set; }

        public DateTime PublishingDate { get; set; }
    }

    public class BookEditModel
    {
        public string BookName { get; set; }

        public string BookType { get; set; }

        public string BookSubject { get; set; }

        public string Author { get; set; }

        public int Stock { get; set; }

        public string BookImageFileName { get; set; }

        public DateTime PublishingDate { get; set; }
    }

    public class BorrowBookModel
    {

        public Guid UserName { get; set; } 
        public string BookName { get; set; }

        public string BookType { get; set; }

        public string BookSubject { get; set; }

        public string Author { get; set; }
        public DateTime GivenDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(15);

    }
}
