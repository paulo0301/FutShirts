using Modelo.Produtos;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Produtos
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();
        public Produto GetProdutoById(long? id)
        {
            return context.Produtos.Where(e => e.Id == id).First();
        }
        public void SaveProduto(Produto produto)
        {
            if (produto.Id == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DesativarProduto(Produto produto)
        {
            if (produto.Id == null)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
