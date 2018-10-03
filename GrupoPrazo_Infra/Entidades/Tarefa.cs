using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoPrazo_Infra.Entidades
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        public String Descricao { get; set; }

        public Boolean  Estado { get; set; }

    }
}