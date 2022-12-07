using booklib.Entities;

namespace booklib.Models
{
    public class LibViewModel
    {
        public User User { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        //public string BookType { get; set; }
        //public string BookSubject { get; set; }
        //public string Author { get; set; }

        public DateTime GivenDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(15);
    }
}
