using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Luften kullanici adini girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Luften sifrenizni girin")]
        public string password { get; set; }
    }
}
