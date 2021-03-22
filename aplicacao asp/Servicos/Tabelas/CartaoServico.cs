using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Tabelas
{
    public class CartaoServico
    {
        private CartaoDAL cartaoDal = new CartaoDAL();
        public IQueryable<Cartao> GetCartaoByTitular()
        {
            return cartaoDal.GetCartaoByTitular();
        }
    }
}
