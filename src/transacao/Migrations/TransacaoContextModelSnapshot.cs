﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fuston.transacao;

#nullable disable

namespace transacao.Migrations
{
    [DbContext(typeof(TransacaoContext))]
    partial class TransacaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fuston.contas.Conta", b =>
                {
                    b.Property<int>("TempId")
                        .HasColumnType("int");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("fuston.transacao.Transacao", b =>
                {
                    b.Property<int>("TransacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransacaoId"));

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("TransacaoId");

                    b.HasIndex("ContaId");

                    b.ToTable("Transacoes", (string)null);
                });

            modelBuilder.Entity("fuston.transacao.Transacao", b =>
                {
                    b.HasOne("fuston.contas.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .HasPrincipalKey("TempId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });
#pragma warning restore 612, 618
        }
    }
}
