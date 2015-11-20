using ControlReceitaDespesas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlReceitaDespesas.DAL
{
    public class RecDesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RecDesContext>
    {
        protected override void Seed(RecDesContext context)
        {
            var recdes = new List<RecDes>
            {
                new RecDes {Valor=Convert.ToDecimal(16.5), Categoria = "Receita", Data = Convert.ToDateTime("2015-01-01"), Observacao = "Necessario"   },
                new RecDes {Valor=Convert.ToDecimal(164.5), Categoria = "Despesa", Data = Convert.ToDateTime("2015-02-02"), Observacao = "Diversao"   },
                new RecDes {Valor=Convert.ToDecimal(176.5), Categoria = "Receita", Data = Convert.ToDateTime("2015-03-03"), Observacao = "Necessario"   }
            };

            recdes.ForEach(s => context.tbReceitasDespesas.Add(s));
            context.SaveChanges();
        }
    }
}