using DesafioVaiVoa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVaiVoa
{
    public class AplicativoContext : DbContext
    {
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BancoVaiVoa;Trusted_Connection=true;");
        }
    }
}
