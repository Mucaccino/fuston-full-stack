namespace fuston.contas;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ContaContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection"));
    }
}