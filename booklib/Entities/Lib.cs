using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booklib.Entities
{
    [Table("Libs")]
    public class Lib 
    {
        public Guid UserId { get; set; } = new Guid();
        public User User { get; set; }
        
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        
        
        public DateTime GivenDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now.AddDays(15);
    }
}
