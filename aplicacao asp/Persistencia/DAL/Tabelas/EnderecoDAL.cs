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
    public class EnderecoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Endereco> GetEnderecosByLogradouro()
        {
            return context.Enderecos.Include(e => e.Usuario).OrderBy(e => e.Logradouro);
        }
        public Endereco GetEnderecosById(long? Id)
        {
            return context.Enderecos.Where(e => e.Id == Id).First();
        }
        public IQueryable<Endereco> GetEnderecosByIdUsuario(long? IdUsuario)
        {
            return context.Enderecos.Where(e => e.UsuarioId == IdUsuario).Include(e => e.Usuario).OrderBy(e => e.Id);
        }
        public void SaveEndereco(Endereco endereco)
        {
            try
            {
                if (endereco.Id == null)
                {
                    context.Enderecos.Add(endereco);
                }
                else
                {
                    context.Entry(endereco).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var teste = ex.Message;
                var x = "13";
            }
        }

        public Endereco EliminarProdutoPorId(long id)
        {
            Endereco endereco = GetEnderecosById(id);
            context.Enderecos.Remove(endereco);
            context.SaveChanges();
            return endereco;
        }
    }
}
