﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyProject.Data;

#nullable disable

namespace StudyProject.Migrations
{
    [DbContext(typeof(KubernetesListingDbContext))]
    [Migration("20240124193414_AddKubernetesClusterConfig")]
    partial class AddKubernetesClusterConfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApiVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kind")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KubernetesClusterConfigs");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+Cluster", b =>
                {
                    b.Property<int>("ClusterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClusterId"));

                    b.Property<int?>("DetailsClusterDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("KubernetesClusterConfigId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClusterId");

                    b.HasIndex("DetailsClusterDetailsId");

                    b.HasIndex("KubernetesClusterConfigId");

                    b.ToTable("Cluster");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+ClusterDetails", b =>
                {
                    b.Property<int>("ClusterDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClusterDetailsId"));

                    b.Property<string>("CertificateAuthorityData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClusterDetailsId");

                    b.ToTable("ClusterDetails");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+Context", b =>
                {
                    b.Property<int>("ContextId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContextId"));

                    b.Property<int?>("DetailsContextDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("KubernetesClusterConfigId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContextId");

                    b.HasIndex("DetailsContextDetailsId");

                    b.HasIndex("KubernetesClusterConfigId");

                    b.ToTable("Context");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+ContextDetails", b =>
                {
                    b.Property<int>("ContextDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContextDetailsId"));

                    b.Property<string>("Cluster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContextDetailsId");

                    b.ToTable("ContextDetails");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("DetailsUserDetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("KubernetesClusterConfigId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("DetailsUserDetailsId");

                    b.HasIndex("KubernetesClusterConfigId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+UserDetails", b =>
                {
                    b.Property<int>("UserDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserDetailsId"));

                    b.Property<string>("ClientCertificateData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientKeyData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserDetailsId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+Cluster", b =>
                {
                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig+ClusterDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsClusterDetailsId");

                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig", null)
                        .WithMany("Clusters")
                        .HasForeignKey("KubernetesClusterConfigId");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+Context", b =>
                {
                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig+ContextDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsContextDetailsId");

                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig", null)
                        .WithMany("Contexts")
                        .HasForeignKey("KubernetesClusterConfigId");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig+User", b =>
                {
                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig+UserDetails", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsUserDetailsId");

                    b.HasOne("StudyProject.Data.Models.KubernetesClusterConfig", null)
                        .WithMany("Users")
                        .HasForeignKey("KubernetesClusterConfigId");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("StudyProject.Data.Models.KubernetesClusterConfig", b =>
                {
                    b.Navigation("Clusters");

                    b.Navigation("Contexts");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}