using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booklib.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Belirleyiniz.")]
        [StringLength(20,ErrorMessage ="Kullanıcı adı en fazla 20 karakterli olabilir.")]
        public string UserName { get; set; }

        public string? FullName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Belirleyiniz.")]
        [MaxLength(30, ErrorMessage = "Şifre için en fazla 30 karakter kullaınabilir.")]
        [MinLength(6, ErrorMessage = "Şifre için en az 6 karakter kullaınabilir.")]
        public string Password { get; set; }

        public string? ProfileImageFileName { get; set; }

        public string Role { get; set; } = "user";

        public string? Readed { get; set; }

        public string? ReadingNow { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool Penalty { get; set; } = false;

        public bool Locked { get; set; } = false;


        //public ICollection<Lib>Libs { get; set; }
    }
}
