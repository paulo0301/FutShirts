using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CartaoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cartao> GetCartaoByTitular()
        {
            return context.Cartoes.OrderBy(b => b.Titular);
        }
        public Cartao GetCartaoById(long id)
        {
            return context.Cartoes.Where(c => c.Id == id).First();
        }
        public void SaveCartao(Cartao cartao)
        {
            if (cartao.Id == null)
            {
                context.Cartoes.Add(cartao);
            }
            else
            {
                context.Entry(cartao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Cartao DeleteCartao(long id)
        {
            Cartao produto = GetCartaoById(id);
            context.Cartoes.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}
