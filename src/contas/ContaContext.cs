namespace fuston.contas;

using dotenv.net;
using fuston.cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ContaContext : DbContext
{
    public DbSet<Agencia> Agencias { get; set; }
    public DbSet<Conta> Contas { get; set; }

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
        modelBuilder.Entity<Agencia>().HasData(
                new Agencia
                {
                    AgenciaId = 1,
                    Numero = "1010",
                }
            );

        modelBuilder.Entity<Conta>().HasData(
                new Conta
                {
                    ContaId = 1,
                    AgenciaId = 1,
                    Numero = "123456789",
                    ClienteId = 1,
                    Saldo = 1100,
                },
                new Conta
                {
                    ContaId = 2,
                    AgenciaId = 1,
                    Numero = "987654321",
                    ClienteId = 2,
                    Saldo = 2200,
                }
            );
    }
}