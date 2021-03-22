using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class EnderecoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Endereco> GetEnderecosByLogradouro()
        {
            return context.Enderecos.OrderBy(e => e.Logradouro);
        }
    }
}
