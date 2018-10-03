using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoPrazo_Infra.Entidades
{
    public class Usuario

    {
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Permissao { get; set; }

        [Required]
        public String Senha { get; set; }
    }
}