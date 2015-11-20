using ControlReceitaDespesas.Models;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlReceitaDespesas.DAL
{
    public class RecDesContext : DbContext
    {
        public RecDesContext()
            :base ("DbReceitasDespesas")
        {
        }

        public DbSet<RecDes> tbReceitasDespesas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}