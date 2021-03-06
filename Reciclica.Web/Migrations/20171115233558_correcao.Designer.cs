﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Reciclica.Web.Data;
using System;

namespace Reciclica.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171115233558_correcao")]
    partial class correcao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reciclica.Web.Empresas.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<string>("Cnpj");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<int>("Numero");

                    b.Property<string>("Telefone2");

                    b.Property<string>("Telefonne");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Reciclica.Web.Materiais.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Observacao");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Reciclica.Web.Pontos.Ponto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<int?>("EmpresaId");

                    b.Property<string>("Logradouro");

                    b.Property<int?>("MaterialId");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Ponto");
                });

            modelBuilder.Entity("Reciclica.Web.Pontos.Ponto", b =>
                {
                    b.HasOne("Reciclica.Web.Empresas.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.HasOne("Reciclica.Web.Materiais.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });
#pragma warning restore 612, 618
        }
    }
}
