namespace Core_Project.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PictureURL { get; set; }  //DOsya yolu tutar
        public IFormFile Picture { get; set; } //Dosyanın wwwroot içine kaydetmek için gerekli sunucuda çalışırken
    }
}
