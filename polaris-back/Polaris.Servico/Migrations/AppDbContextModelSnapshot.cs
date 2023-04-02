﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polaris.Servico.Context;

#nullable disable

namespace Polaris.Servico.Migrations
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

            modelBuilder.Entity("Polaris.Servico.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ServicoId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Polaris.Servico.Models.Terceirizado", b =>
                {
                    b.Property<int>("TerceirizadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("TerceirizadoId");

                    b.ToTable("Terceirizado");
                });

            modelBuilder.Entity("ServicoTerceirizado", b =>
                {
                    b.Property<int>("ServicosServicoId")
                        .HasColumnType("int");

                    b.Property<int>("TerceirizadosTerceirizadoId")
                        .HasColumnType("int");

                    b.HasKey("ServicosServicoId", "TerceirizadosTerceirizadoId");

                    b.HasIndex("TerceirizadosTerceirizadoId");

                    b.ToTable("ServicoTerceirizado");
                });

            modelBuilder.Entity("ServicoTerceirizado", b =>
                {
                    b.HasOne("Polaris.Servico.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polaris.Servico.Models.Terceirizado", null)
                        .WithMany()
                        .HasForeignKey("TerceirizadosTerceirizadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
