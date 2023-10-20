namespace fuston.cliente;

using Microsoft.EntityFrameworkCore;
using System;
using dotenv.net;

public class TransacaoContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") == null) {
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {"../.env"}));
        }

        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));
    }
}