using System.ComponentModel.DataAnnotations;

namespace booklib.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Readed { get; set; }
        public string? ReadingNow { get; set; }
        public string Role { get; set; } = "user";
        public string? Done { get; set; }
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin")]
        [StringLength(30, ErrorMessage = "kullanıcı adı 30 karekter olabilir en fazla")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; } = false;


        [Required(ErrorMessage = "Parola girin")]
        [MinLength(6, ErrorMessage = "En az 6 karekter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karekter olabilir")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Parola zorunludur")]
        [MinLength(6, ErrorMessage = "En az 6 karekter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karekter olabilir")]
        [Compare(nameof(Password), ErrorMessage = "Parolalar aynı değil.")]
        public string RePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";

    }

    public class EditUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin")]
        [StringLength(30, ErrorMessage = "kullanıcı adı 30 karekter olabilir en fazla")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";


    }
}
