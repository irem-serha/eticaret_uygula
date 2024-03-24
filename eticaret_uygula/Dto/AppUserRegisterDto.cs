using System.ComponentModel.DataAnnotations;

namespace eticaret_uygula.Dto
{
    public class AppUserRegisterDto
    {
        [Display(Name ="Adınızı Giriniz")]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsiniz.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadınızı Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string LastName { get; set; }
        [Display(Name = "Kullanıcı Adını Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string UserName { get; set; }
        [Display(Name = "Şehrinizi Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string City { get; set; }
        [Display(Name = "Emaili Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numaranızı Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string Password { get; set; }
        [Display(Name = "Adınızı Giriniz")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz.")]
        public string ConfirmPassword { get; set; }
    }
}
