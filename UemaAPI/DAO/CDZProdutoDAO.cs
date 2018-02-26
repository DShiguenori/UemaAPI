using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UemaAPI.Models;

namespace UemaAPI.DAO
{
    public class CDZProdutoDAO
    {

        private CDZContext context;

        public CDZProdutoDAO(CDZContext context)
        {
            this.context = context;
        }
        


        public void Adicionar(CDZProduto produto)
        {
            context.Produtos.Add(produto);

            context.SaveChanges();
        }

        public CDZProduto Selecionar(int ID)
        {
            return context.Produtos.Where(x => x.ID == ID).First();
        }

        public IList<CDZProduto> SelecionarTodos()
        {
            return context.Produtos.ToList();
        }

        public IList<CDZProduto> SelecionarConfirmados(bool confirmado)
        {
            return context.Produtos.Where(x => x.Confirmado == confirmado).ToList();
        }







    }
}