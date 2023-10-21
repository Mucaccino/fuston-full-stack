namespace fuston.cliente;

using Microsoft.EntityFrameworkCore;
using System;
using dotenv.net;

public class ClienteContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") == null) {
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {"../../.env"}));
        }

        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 1,
                    Nome = "Murillo L Do Carmo",
                    Documento = "01421586584",
                    Password = "$2a$11$Na7BCqtllJJC.Wz.pCBbGu9ekLI99UfjjK3fRQ/pRCQ9Csl66t.Tq"
                },
                new Cliente
                {
                    ClienteId = 2,
                    Nome = "Cliente Teste",
                    Documento = "58666889640",
                    Password = "$2a$11$Na7BCqtllJJC.Wz.pCBbGu9ekLI99UfjjK3fRQ/pRCQ9Csl66t.Tq"
                }
            );
    }
}