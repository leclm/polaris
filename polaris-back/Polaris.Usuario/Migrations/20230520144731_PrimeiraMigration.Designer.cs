﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polaris.Usuario.Context;

#nullable disable

namespace Polaris.Usuario.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230520144731_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AluguelConteiner", b =>
                {
                    b.Property<int>("AlugueisAluguelId")
                        .HasColumnType("int");

                    b.Property<int>("ConteineresConteinerId")
                        .HasColumnType("int");

                    b.HasKey("AlugueisAluguelId", "ConteineresConteinerId");

                    b.HasIndex("ConteineresConteinerId");

                    b.ToTable("AluguelConteiner", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Aluguel", b =>
                {
                    b.Property<int>("AluguelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AluguelUuid")
                        .HasColumnType("char(36)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Desconto")
                        .HasColumnType("double");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoAluguel")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TipoLocacao")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotalAluguel")
                        .HasColumnType("double");

                    b.HasKey("AluguelId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Aluguel", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Usuario.Models.CategoriaConteiner", b =>
                {
                    b.Property<int>("CategoriaConteinerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("CategoriaConteinerUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoriaConteinerId");

                    b.ToTable("CategoriasConteineres", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ClienteUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("ClienteId");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.HasIndex("LoginId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Conteiner", b =>
                {
                    b.Property<int>("ConteinerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaConteinerId")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<Guid>("ConteinerUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Fabricacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("TipoConteinerId")
                        .HasColumnType("int");

                    b.HasKey("ConteinerId");

                    b.HasIndex("CategoriaConteinerId");

                    b.HasIndex("TipoConteinerId");

                    b.ToTable("Conteiner", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<Guid>("EnderecoUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Gerente", b =>
                {
                    b.Property<int>("GerenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<Guid>("GerenteUuid")
                        .HasColumnType("char(36)");

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("GerenteId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("LoginId");

                    b.HasIndex("Cnpj", "Empresa", "Email", "Telefone")
                        .IsUnique();

                    b.ToTable("Gerente");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("LoginUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("LoginId");

                    b.HasIndex("Usuario")
                        .IsUnique();

                    b.ToTable("Login");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.TipoConteiner", b =>
                {
                    b.Property<int>("TipoConteineroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Altura")
                        .HasColumnType("double");

                    b.Property<double>("Comprimento")
                        .HasColumnType("double");

                    b.Property<double>("Largura")
                        .HasColumnType("double");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("PesoMaximo")
                        .HasColumnType("double");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("TipoConteinerUuid")
                        .HasColumnType("char(36)");

                    b.Property<double>("ValorDiaria")
                        .HasColumnType("double");

                    b.Property<double>("ValorMensal")
                        .HasColumnType("double");

                    b.Property<double>("Volume")
                        .HasColumnType("double");

                    b.HasKey("TipoConteineroId");

                    b.ToTable("TiposConteineres", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("AluguelConteiner", b =>
                {
                    b.HasOne("Polaris.Usuario.Models.Aluguel", null)
                        .WithMany()
                        .HasForeignKey("AlugueisAluguelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Usuario.Models.Conteiner", null)
                        .WithMany()
                        .HasForeignKey("ConteineresConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Aluguel", b =>
                {
                    b.HasOne("Polaris.Usuario.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Usuario.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Cliente", b =>
                {
                    b.HasOne("Polaris.Usuario.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Usuario.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Conteiner", b =>
                {
                    b.HasOne("Polaris.Usuario.Models.CategoriaConteiner", "CategoriaConteiner")
                        .WithMany()
                        .HasForeignKey("CategoriaConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Usuario.Models.TipoConteiner", "TipoConteiner")
                        .WithMany()
                        .HasForeignKey("TipoConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaConteiner");

                    b.Navigation("TipoConteiner");
                });

            modelBuilder.Entity("Polaris.Usuario.Models.Gerente", b =>
                {
                    b.HasOne("Polaris.Usuario.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Usuario.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Login");
                });
#pragma warning restore 612, 618
        }
    }
}
