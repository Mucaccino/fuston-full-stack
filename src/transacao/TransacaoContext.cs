namespace fuston.transacao;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class TransacaoContext : DbContext
{
    public DbSet<Transacao> Transacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection"));
    }
}