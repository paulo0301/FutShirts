using Modelo.Produtos;
using Persistencia.DAL.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Produtos
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDal = new ProdutoDAL();
        public Produto GetProdutoById(long? id)
        {
            return produtoDal.GetProdutoById(id);
        }
        public void SaveProduto(Produto produto)
        {
            produtoDal.SaveProduto(produto);
        }
        public void DesativarProduto(Produto produto)
        {
            produtoDal.DesativarProduto(produto);
        }
    }
}
