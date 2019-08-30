﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SchoolOccurrences.School.Domain.Enums;
using SchoolOccurrences.School.Infra.Contexts.Entity;
using SchoolOccurrences.Shared.Commons.Enums;
using System;

namespace SchoolOccurrences.School.Infa.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20180424014539_ChangeSchoolAddressNumberColName")]
    partial class ChangeSchoolAddressNumberColName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Occurrence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OcrId");

                    b.Property<string>("Cause")
                        .IsRequired()
                        .HasColumnName("OcrCausa")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("OcrData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("OcrDescricao")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("OccurrenceStatus")
                        .HasColumnName("OcrSituacao")
                        .HasColumnType("int");

                    b.Property<int>("OccurrenceType")
                        .HasColumnName("OcrTipo")
                        .HasColumnType("int");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("OcrOcorrencia");
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ResId");

                    b.Property<string>("AlternativeTelephone")
                        .HasColumnName("ResTelefoneAlternativo")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ContactTelephone")
                        .HasColumnName("ResTelefoneContato")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("EFamilyType")
                        .HasColumnName("ResFamiliaridade")
                        .HasColumnType("int");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasColumnName("ResNome")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("StudentId");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnName("ResTelefonePrincipal")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("ResResponsavel");
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EscId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("EscNome")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("EscTelefone")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("EscEscola");
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EstId");

                    b.Property<DateTime>("AcademicYear")
                        .HasColumnName("EstAnoLetivo")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("EstDataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("CalledNumber")
                        .HasColumnName("EstNumeroChamada")
                        .HasColumnType("int");

                    b.Property<int>("ETypeOfEducation")
                        .HasColumnName("EstTipoEnsino")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnName("EstTurma")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnName("EstObservacao")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("SchoolId");

                    b.Property<int>("Serie")
                        .HasColumnName("EstSerie")
                        .HasColumnType("int");

                    b.Property<int>("Shifts");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("EstEstudante");
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Occurrence", b =>
                {
                    b.HasOne("SchoolOccurrences.School.Domain.Entities.Student", "Student")
                        .WithMany("Occurrence")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Parent", b =>
                {
                    b.HasOne("SchoolOccurrences.School.Domain.Entities.Student")
                        .WithMany("Parents")
                        .HasForeignKey("StudentId");

                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Document", "ResponsibleDocument", b1 =>
                        {
                            b1.Property<Guid?>("ParentId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("ResNumeroDocumento")
                                .HasColumnType("varchar(14)");

                            b1.Property<int>("Type")
                                .HasColumnName("ResTipoDocumento")
                                .HasColumnType("int");

                            b1.ToTable("ResResponsavel");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.Parent")
                                .WithOne("ResponsibleDocument")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Document", "ParentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ParentId");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("ResEmail")
                                .HasColumnType("varchar(14)");

                            b1.ToTable("ResResponsavel");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.Parent")
                                .WithOne("Email")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Email", "ParentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.School", b =>
                {
                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid?>("SchoolId");

                            b1.Property<int>("Abbr")
                                .HasColumnName("EscSiglaUf")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("EscCidade")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnName("EscPais")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnName("EscBairro")
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Number")
                                .HasColumnName("EscEnderecoNumero")
                                .HasColumnType("int");

                            b1.Property<string>("StateName")
                                .IsRequired()
                                .HasColumnName("EscUf")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("EscRua")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("EscCep")
                                .HasColumnType("varchar(9)");

                            b1.ToTable("EscEscola");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.School")
                                .WithOne("Address")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Address", "SchoolId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("SchoolId");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("EscNumeroDocumento")
                                .HasColumnType("varchar(14)");

                            b1.Property<int>("Type")
                                .HasColumnName("EscTipoDocumento")
                                .HasColumnType("int");

                            b1.ToTable("EscEscola");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.School")
                                .WithOne("Document")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Document", "SchoolId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SchoolOccurrences.School.Domain.Entities.Student", b =>
                {
                    b.HasOne("SchoolOccurrences.School.Domain.Entities.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId");

                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StudentId");

                            b1.Property<int>("Abbr")
                                .HasColumnName("EstSiglaUf")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("EstCidade")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnName("EstPais")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnName("EstBairro")
                                .HasColumnType("varchar(50)");

                            b1.Property<int>("Number")
                                .HasColumnName("EstTEnderecoNumero")
                                .HasColumnType("int");

                            b1.Property<string>("StateName")
                                .IsRequired()
                                .HasColumnName("EstUf")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("EstRua")
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("EstCep")
                                .HasColumnType("varchar(8)");

                            b1.ToTable("EstEstudante");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.Student")
                                .WithOne("Address")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Address", "StudentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SchoolOccurrences.School.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("StudentId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("EstNome")
                                .HasColumnType("varchar(60)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("EstSobreNome")
                                .HasColumnType("varchar(60)");

                            b1.ToTable("EstEstudante");

                            b1.HasOne("SchoolOccurrences.School.Domain.Entities.Student")
                                .WithOne("Name")
                                .HasForeignKey("SchoolOccurrences.School.Domain.ValueObjects.Name", "StudentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
