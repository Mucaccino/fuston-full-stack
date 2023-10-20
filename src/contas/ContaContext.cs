namespace fuston.contas;

using dotenv.net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ContaContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") == null) {
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {"../.env"}));
        }
        
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));
    }
}