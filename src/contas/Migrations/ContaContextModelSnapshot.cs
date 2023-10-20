﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fuston.contas;

#nullable disable

namespace contas.Migrations
{
    [DbContext(typeof(ContaContext))]
    partial class ContaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fuston.contas.Agencia", b =>
                {
                    b.Property<int>("AgenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgenciaId"));

                    b.Property<float>("Numero")
                        .HasColumnType("real");

                    b.HasKey("AgenciaId");

                    b.ToTable("Agencias");

                    b.HasData(
                        new
                        {
                            AgenciaId = 1,
                            Numero = 1010f
                        });
                });

            modelBuilder.Entity("fuston.contas.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContaId"));

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<float>("Numero")
                        .HasColumnType("real");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.HasKey("ContaId");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contas");

                    b.HasData(
                        new
                        {
                            ContaId = 1,
                            AgenciaId = 1,
                            ClienteId = 1,
                            Numero = 123456790f,
                            Saldo = 1100f
                        },
                        new
                        {
                            ContaId = 2,
                            AgenciaId = 1,
                            ClienteId = 2,
                            Numero = 987654340f,
                            Saldo = 2200f
                        });
                });

            modelBuilder.Entity("fuston.contas.Conta", b =>
                {
                    b.HasOne("fuston.contas.Agencia", "Agencia")
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("fuston.cliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
