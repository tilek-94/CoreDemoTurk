using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad syad")]
        [Required(ErrorMessage ="Lutfen ad soyad giriniz")]
        public string nameSurname { get; set; }

        [Display(Name = "Ad syad")]
        [Required(ErrorMessage = "Lutfen sifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Sifer Tekrar")]
        [Compare("Password",ErrorMessage = "sifreler uyusmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail adresi")]
        [Required(ErrorMessage = "Lutfen mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanici Adi")]
        [Required(ErrorMessage = "Lutfen kullanici adinizi giriniz")]
        public string UserName { get; set; }
    }
}
