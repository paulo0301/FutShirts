using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using Persistencia.Contexts;

namespace Persistencia.DAL.Tabelas
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();
        //GET Usuarios
        public IQueryable<Usuario> GetUsuariosByNome()
        {
            return context.Usuarios.OrderBy(u => u.Nome);
        }
        public IQueryable<Usuario> GetUsuariosByEmail()
        {
            return context.Usuarios.OrderBy(u => u.Email);
        }
        public IQueryable<Usuario> GetUsuariosByCpf()
        {
            return context.Usuarios.OrderBy(u => u.Cpf);
        }

        public long? GetLastUsuarioId()
        {
            return context.Usuarios.Max(u => u.Id);
        }

        //Save Usuarios
        public void SaveUsuario(Usuario usuario)
        {
            if (usuario.Id == null)
            {
                context.Usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
