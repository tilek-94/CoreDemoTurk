using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Liften rol dai giriniz")]
        public string name { get; set; }
    }
}
