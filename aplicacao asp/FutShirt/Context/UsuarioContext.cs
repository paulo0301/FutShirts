using FutShirt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FutShirt.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() : base("FutShirt") {
            //Database.SetInitializer<UsuarioContext>(
            //new DropCreateDatabaseIfModelChanges<UsuarioContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartaos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}