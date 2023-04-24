﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polaris.Conteiner.Context;

#nullable disable

namespace Polaris.Conteiner.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Polaris.Conteiner.Models.CategoriaConteiner", b =>
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

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("CategoriasConteineres");
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Conteiner", b =>
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

                    b.Property<DateTime>("Fabricacao")
                        .HasColumnType("datetime(6)");

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

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("TipoConteinerId");

                    b.ToTable("Conteiner");
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Endereco", b =>
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

            modelBuilder.Entity("Polaris.Conteiner.Models.PrestacaoDeServico", b =>
                {
                    b.Property<int>("PrestacaoDeServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ConteinerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataProcedimento")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PrestacaoDeServicoUuid")
                        .HasColumnType("char(36)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TerceirizadoId")
                        .HasColumnType("int");

                    b.HasKey("PrestacaoDeServicoId");

                    b.HasIndex("ConteinerId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("TerceirizadoId");

                    b.ToTable("PrestacaoDeServico");
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ServicoUuid")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ServicoId");

                    b.ToTable("Servicos", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Terceirizado", b =>
                {
                    b.Property<int>("TerceirizadoId")
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

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<Guid>("TerceirizadoUuid")
                        .HasColumnType("char(36)");

                    b.HasKey("TerceirizadoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Terceirizado", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.TipoConteiner", b =>
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

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("TiposConteineres");
                });

            modelBuilder.Entity("ServicoTerceirizado", b =>
                {
                    b.Property<int>("ServicosServicoId")
                        .HasColumnType("int");

                    b.Property<int>("TerceirizadosTerceirizadoId")
                        .HasColumnType("int");

                    b.HasKey("ServicosServicoId", "TerceirizadosTerceirizadoId");

                    b.HasIndex("TerceirizadosTerceirizadoId");

                    b.ToTable("ServicoTerceirizado", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Conteiner", b =>
                {
                    b.HasOne("Polaris.Conteiner.Models.CategoriaConteiner", "CategoriaConteiner")
                        .WithMany()
                        .HasForeignKey("CategoriaConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Conteiner.Models.TipoConteiner", "TipoConteiner")
                        .WithMany()
                        .HasForeignKey("TipoConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaConteiner");

                    b.Navigation("TipoConteiner");
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.PrestacaoDeServico", b =>
                {
                    b.HasOne("Polaris.Conteiner.Models.Conteiner", "Conteiner")
                        .WithMany()
                        .HasForeignKey("ConteinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Conteiner.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Conteiner.Models.Terceirizado", "Terceirizado")
                        .WithMany()
                        .HasForeignKey("TerceirizadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conteiner");

                    b.Navigation("Servico");

                    b.Navigation("Terceirizado");
                });

            modelBuilder.Entity("Polaris.Conteiner.Models.Terceirizado", b =>
                {
                    b.HasOne("Polaris.Conteiner.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ServicoTerceirizado", b =>
                {
                    b.HasOne("Polaris.Conteiner.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Conteiner.Models.Terceirizado", null)
                        .WithMany()
                        .HasForeignKey("TerceirizadosTerceirizadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
