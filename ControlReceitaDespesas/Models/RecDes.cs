using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlReceitaDespesas.Models
{
    public class RecDes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RecDesID { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }

    }
}