using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoPrazoWeb.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        [EmailAddress]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
     
        public string Senha { get; set; }

       
    }
}