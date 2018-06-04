using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeExamples.Models
{
    public class ModelWithAnnotations
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Protected ID")]
        public string ProtectedID { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
