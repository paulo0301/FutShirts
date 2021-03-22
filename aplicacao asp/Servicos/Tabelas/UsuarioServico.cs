using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Tabelas
{
    public class UsuarioServico
    {
        private UsuarioDAL usuarioDal = new UsuarioDAL();
        //Get Usuarios
        public IQueryable<Usuario> GetUsuariosByNome()
        {
            return usuarioDal.GetUsuariosByNome();
        }
        public IQueryable<Usuario> GetUsuariosByEmail()
        {
            return usuarioDal.GetUsuariosByEmail();
        }
        public IQueryable<Usuario> GetUsuariosByCpf()
        {
            return usuarioDal.GetUsuariosByCpf();
        }

        //Save Usuario
        public void SaveUsuario(Usuario usuario)
        {
            usuarioDal.SaveUsuario(usuario);
        }
    }
}
