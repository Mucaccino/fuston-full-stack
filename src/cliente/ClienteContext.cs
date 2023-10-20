namespace fuston.cliente;

using Microsoft.EntityFrameworkCore;
using System;
using dotenv.net;

public class ClienteContext : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }

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
                    Documento = 01421586584,
                    Password = "Gt9Yc4AiIvmsC1QQbe2RZsCIqvoYlst2xbz0Fs8aHnw="
                },
                new Cliente
                {
                    ClienteId = 2,
                    Nome = "Cliente Teste",
                    Documento = 58666889640,
                    Password = "Gt9Yc4AiIvmsC1QQbe2RZsCIqvoYlst2xbz0Fs8aHnw="
                }
            );
    }
}