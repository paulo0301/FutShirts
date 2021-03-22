using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using System.Data.Entity;
using Persistencia.Migrations;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(): base("Banco_FutShirt") {
            Database.SetInitializer<EFContext>(new
            MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}