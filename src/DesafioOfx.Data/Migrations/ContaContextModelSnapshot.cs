﻿// <auto-generated />
using System;
using DesafioOfx.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioOfx.Data.Migrations
{
    [DbContext(typeof(ContaContext))]
    partial class ContaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DesafioOfx.Domain.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Digito")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Digito")
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CodigoReferencia")
                        .HasColumnType("varchar(22)");

                    b.Property<string>("CodigoUnico")
                        .IsRequired()
                        .HasColumnType("varchar(34)");

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricacao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Protocolo")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoTransacao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Agencia", b =>
                {
                    b.HasOne("DesafioOfx.Domain.Banco", "Banco")
                        .WithMany("Agencias")
                        .HasForeignKey("BancoId")
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Conta", b =>
                {
                    b.HasOne("DesafioOfx.Domain.Agencia", "Agencia")
                        .WithMany("Contas")
                        .HasForeignKey("AgenciaId");

                    b.Navigation("Agencia");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Transacao", b =>
                {
                    b.HasOne("DesafioOfx.Domain.Conta", "Conta")
                        .WithMany("Transacaos")
                        .HasForeignKey("ContaId")
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Agencia", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Banco", b =>
                {
                    b.Navigation("Agencias");
                });

            modelBuilder.Entity("DesafioOfx.Domain.Conta", b =>
                {
                    b.Navigation("Transacaos");
                });
#pragma warning restore 612, 618
        }
    }
}
