﻿// <auto-generated />
using System;
using DiskSpaceMonitor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiskSpaceMonitor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241209112757_CreateQuotasTable")]
    partial class CreateQuotasTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiskSpaceMonitor.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Disk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("FreeSpace")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<long>("TotalSpace")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Disks");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.FileMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiskId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("LastAccessedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiskId");

                    b.HasIndex("ServerId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GrowthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Quota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FreeSize")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("GrowthTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSize")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UsageSize")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Quotas");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastChecked")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.AuditLog", b =>
                {
                    b.HasOne("DiskSpaceMonitor.Models.FileMetadata", "File")
                        .WithMany("AuditLogs")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Disk", b =>
                {
                    b.HasOne("DiskSpaceMonitor.Models.Server", "Server")
                        .WithMany("Disks")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.FileMetadata", b =>
                {
                    b.HasOne("DiskSpaceMonitor.Models.Disk", "Disk")
                        .WithMany("Files")
                        .HasForeignKey("DiskId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DiskSpaceMonitor.Models.Server", "Server")
                        .WithMany("Files")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Disk");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Folder", b =>
                {
                    b.HasOne("DiskSpaceMonitor.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Quota", b =>
                {
                    b.HasOne("DiskSpaceMonitor.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Disk", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.FileMetadata", b =>
                {
                    b.Navigation("AuditLogs");
                });

            modelBuilder.Entity("DiskSpaceMonitor.Models.Server", b =>
                {
                    b.Navigation("Disks");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
