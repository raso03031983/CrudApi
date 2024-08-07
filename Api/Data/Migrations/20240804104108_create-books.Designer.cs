﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20240804104108_create-books")]
    partial class createbooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Context.Model.Assunto", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Cod");

                    b.ToTable("Assunto");
                });

            modelBuilder.Entity("Data.Context.Model.Autor", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Cod");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Data.Context.Model.Conta", b =>
                {
                    b.Property<Guid>("IdConta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("documento_cliente")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdConta");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("Data.Context.Model.Livro", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoPublicacao")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("Edicao")
                        .HasColumnType("int");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Cod");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Data.Context.Model.LivroAssunto", b =>
                {
                    b.Property<int>("AssuntoCod")
                        .HasColumnType("int");

                    b.Property<int>("LivroCod")
                        .HasColumnType("int");

                    b.HasIndex("AssuntoCod");

                    b.HasIndex("LivroCod");

                    b.ToTable("LivroAssunto");
                });

            modelBuilder.Entity("Data.Context.Model.LivroAutor", b =>
                {
                    b.Property<int?>("AssuntoCod")
                        .HasColumnType("int");

                    b.Property<int>("AutorCod")
                        .HasColumnType("int");

                    b.Property<int>("LivroCod")
                        .HasColumnType("int");

                    b.HasIndex("AssuntoCod");

                    b.HasIndex("LivroCod");

                    b.ToTable("LivroAutor");
                });

            modelBuilder.Entity("Data.Context.Model.TipoTransacao", b =>
                {
                    b.Property<int>("IdTipoTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("IdTipoTransacao");

                    b.ToTable("TipoTransacao");
                });

            modelBuilder.Entity("Data.Context.Model.Transacao", b =>
                {
                    b.Property<Guid>("IdTransacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdConta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdTipoTransacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdTransacao");

                    b.HasIndex("IdConta");

                    b.HasIndex("IdTipoTransacao");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("Data.Context.Model.LivroAssunto", b =>
                {
                    b.HasOne("Data.Context.Model.Assunto", "Assunto")
                        .WithMany()
                        .HasForeignKey("AssuntoCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Context.Model.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assunto");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Data.Context.Model.LivroAutor", b =>
                {
                    b.HasOne("Data.Context.Model.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AssuntoCod");

                    b.HasOne("Data.Context.Model.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Data.Context.Model.Transacao", b =>
                {
                    b.HasOne("Data.Context.Model.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Context.Model.TipoTransacao", "TipoTransacao")
                        .WithMany()
                        .HasForeignKey("IdTipoTransacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");

                    b.Navigation("TipoTransacao");
                });
#pragma warning restore 612, 618
        }
    }
}
