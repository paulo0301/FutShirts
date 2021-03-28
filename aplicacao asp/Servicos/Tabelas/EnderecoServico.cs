using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Tabelas
{
    public class EnderecoServico
    {
        private EnderecoDAL enderecoDal = new EnderecoDAL();
        public IQueryable<Endereco> GetEnderecosByLogradouro()
        {
            return enderecoDal.GetEnderecosByLogradouro();
        }
        public IQueryable<Endereco> GetEnderecosByIdUsuario(long Id)
        {
            return enderecoDal.GetEnderecosByIdUsuario(Id);
        }
        public void SaveEndereco(Endereco endereco)
        {
            enderecoDal.SaveEndereco(endereco);
        }
    }
}
