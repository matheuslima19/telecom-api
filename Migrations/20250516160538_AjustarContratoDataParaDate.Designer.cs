﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TelecomApi.Migrations
{
    [DbContext(typeof(TelecomDbContext))]
    [Migration("20250516160538_AjustarContratoDataParaDate")]
    partial class AjustarContratoDataParaDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("date");

                    b.Property<string>("NomeFilial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OperadoraId")
                        .HasColumnType("integer");

                    b.Property<string>("PlanoContratado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorMensal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OperadoraId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Fatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContratoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorCobrado")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Faturas");
                });

            modelBuilder.Entity("Domain.Entities.Operadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContatoSuporte")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoServico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Operadoras");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.HasOne("Domain.Entities.Operadora", "Operadora")
                        .WithMany()
                        .HasForeignKey("OperadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operadora");
                });

            modelBuilder.Entity("Domain.Entities.Fatura", b =>
                {
                    b.HasOne("Domain.Entities.Contrato", "Contrato")
                        .WithMany()
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });
#pragma warning restore 612, 618
        }
    }
}
