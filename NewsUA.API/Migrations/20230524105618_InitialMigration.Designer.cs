﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsUA.API.Data;

#nullable disable

namespace NewsUA.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230524105618_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewsUA.API.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EdittedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHot")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorName = "Author name 1",
                            Information = "Information 1",
                            IsHot = false,
                            Status = "InProcess",
                            SubTitle = "SubTitle 1",
                            Title = "Title 1",
                            Type = "Entertainment"
                        },
                        new
                        {
                            Id = 2,
                            AuthorName = "Author name 2",
                            Information = "Information 2",
                            IsHot = true,
                            Status = "InProcess",
                            SubTitle = "SubTitle 2",
                            Title = "Title 2",
                            Type = "Entertainment"
                        },
                        new
                        {
                            Id = 3,
                            AuthorName = "Author name 3",
                            Information = "Information 3",
                            IsHot = false,
                            Status = "InProcess",
                            SubTitle = "SubTitle 3",
                            Title = "Title 3",
                            Type = "Science"
                        },
                        new
                        {
                            Id = 4,
                            AuthorName = "Author name 4",
                            Information = "Information 4",
                            IsHot = true,
                            Status = "InProcess",
                            SubTitle = "SubTitle 4",
                            Title = "Title 4",
                            Type = "Sport"
                        },
                        new
                        {
                            Id = 5,
                            AuthorName = "Author name 5",
                            Information = "Information 5",
                            IsHot = false,
                            Status = "InProcess",
                            SubTitle = "SubTitle 5",
                            Title = "Title 5",
                            Type = "Technology"
                        });
                });

            modelBuilder.Entity("NewsUA.API.Models.NewsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewsTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "World"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Local"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Sport"
                        },
                        new
                        {
                            Id = 4,
                            Value = "Business"
                        },
                        new
                        {
                            Id = 5,
                            Value = "Technology"
                        },
                        new
                        {
                            Id = 6,
                            Value = "Science"
                        },
                        new
                        {
                            Id = 7,
                            Value = "Health"
                        },
                        new
                        {
                            Id = 8,
                            Value = "Entertainment"
                        });
                });

            modelBuilder.Entity("NewsUA.API.Models.ProcessStatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcessStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "InProcess"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Approved"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Editted"
                        });
                });

            modelBuilder.Entity("NewsUA.API.Models.TelegramBotSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TelegramBotSettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "botApiKey",
                            Value = "6083733825:AAG3K3fm9JfTpa7ed1JVPJJiie0_KAw23Do"
                        },
                        new
                        {
                            Id = 2,
                            Key = "chatId",
                            Value = "@some_channel_1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
