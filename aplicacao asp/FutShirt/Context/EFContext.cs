using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FutShirt.Models;
using System.Data.Entity;

namespace FutShirt.Context
{
    public class EFContext : DbContext
    {
        public EFContext(): base("Banco_FutShirt") {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartaos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}