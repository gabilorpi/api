using apibuscadores.Models;
using Microsoft.EntityFrameworkCore;

namespace apibuscadores.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<Hoteis> Hoteis { get; set; }
        public DbSet<Passagens> Passagens { get; set; }
        public DbSet<Reserva_Quarto> Reserva_Quarto { get; set; }
        public DbSet<Voo> Voo { get; set; }

    }
}
﻿

