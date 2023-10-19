namespace fuston.cliente;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TransacaoContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection"));
    }
}