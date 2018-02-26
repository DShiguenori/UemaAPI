using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UemaAPI.Models;

namespace UemaAPI.DAO
{
    public class CDZContext: DbContext
    {
        public DbSet<CDZProduto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Impede que ao criar as tabelas, ele coloque no plural (estava tipo Movimentacao -> Movimentacaos, por exemplo)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //// Mapeamento da chave estrangeira Usuario da movimentacao
            //modelBuilder.Entity<Movimentacao>().HasRequired(x => x.Usuario);
            //modelBuilder.Entity<Movimentacao>().HasRequired(x => x.Conta);

            //modelBuilder.Entity<ContaCadastro>().HasRequired(x => x.Usuario);
            //modelBuilder.Entity<ContaCadastro>().HasRequired(x => x.Conta);
        }

    }
}