using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadını Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Resim Dosyası Giriniz")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Şifre Uyumlu Değil ")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Maili Giriniz")]
        public string Mail { get; set; }
    }
    
}
