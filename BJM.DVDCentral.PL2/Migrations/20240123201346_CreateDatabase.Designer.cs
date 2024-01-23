﻿// <auto-generated />
using System;
using BJM.DVDCentral.PL2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BJM.DVDCentral.PL2.Migrations
{
    [DbContext(typeof(DVDCentralEntities))]
    [Migration("20240123201346_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblCart");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"),
                            UserId = new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da")
                        },
                        new
                        {
                            Id = new Guid("fa70937e-80f0-4e30-b327-919b0ba45210"),
                            UserId = new Guid("65f96797-88bc-4379-94bb-56028850b5eb")
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("MovieId");

                    b.ToTable("tblCartItem");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31b88efd-946c-434a-a346-30ac0e769d57"),
                            CartId = new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"),
                            MovieId = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"),
                            Qty = 1
                        },
                        new
                        {
                            Id = new Guid("9974448c-07aa-4498-9871-47a541c60a0b"),
                            CartId = new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"),
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"),
                            Qty = 2
                        },
                        new
                        {
                            Id = new Guid("869577d3-ebe9-41eb-90fb-0f0b21a5ae42"),
                            CartId = new Guid("fa70937e-80f0-4e30-b327-919b0ba45210"),
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"),
                            Qty = 1
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id")
                        .HasName("PK_tblCustomer_Id");

                    b.ToTable("tblCustomer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("450f1945-5527-4c27-8ac1-8e4d3bf96fe8"),
                            Address = "453 Oak Street",
                            City = "Fond du Lac",
                            FirstName = "Steve",
                            LastName = "Marin",
                            Phone = "9205879797",
                            State = "WI",
                            UserId = new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da"),
                            ZIP = "54935"
                        },
                        new
                        {
                            Id = new Guid("4814a71d-1eef-4832-9fe4-9d7daa75d9d8"),
                            Address = "987 Willow Road",
                            City = "Slinger",
                            FirstName = "John",
                            LastName = "Doro",
                            Phone = "9202623345",
                            State = "WI",
                            UserId = new Guid("65f96797-88bc-4379-94bb-56028850b5eb"),
                            ZIP = "56495"
                        },
                        new
                        {
                            Id = new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"),
                            Address = "159 Johnson Avenue",
                            City = "Allenton",
                            FirstName = "Brian",
                            LastName = "Foote",
                            Phone = "9202623415",
                            State = "WI",
                            UserId = new Guid("dc528bbe-944a-4dac-9598-6b730917dc35"),
                            ZIP = "53142"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblDirector", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblDirector_Id");

                    b.ToTable("tblDirector", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"),
                            FirstName = "John",
                            LastName = "Avildsen"
                        },
                        new
                        {
                            Id = new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"),
                            FirstName = "Steven",
                            LastName = "Spielberg"
                        },
                        new
                        {
                            Id = new Guid("16ece54a-c9fe-49f5-b9ed-4a953180eb94"),
                            FirstName = "Rob",
                            LastName = "Reiner"
                        },
                        new
                        {
                            Id = new Guid("32e9f38c-010e-4bc3-b59d-fccc64ddec66"),
                            FirstName = "George",
                            LastName = "Lucas"
                        },
                        new
                        {
                            Id = new Guid("79638cc1-6a35-4587-a523-4b32b778e5d5"),
                            FirstName = "Clint",
                            LastName = "Eastwood"
                        },
                        new
                        {
                            Id = new Guid("a1c749a9-91cb-42d0-932e-7d94a560ec29"),
                            FirstName = "Other",
                            LastName = "Other"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblFormat", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblFormat_Id");

                    b.ToTable("tblFormat", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"),
                            Description = "VHS"
                        },
                        new
                        {
                            Id = new Guid("23142f21-ccb5-43a8-9926-166385a5361c"),
                            Description = "DVD"
                        },
                        new
                        {
                            Id = new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"),
                            Description = "Blu-Ray"
                        },
                        new
                        {
                            Id = new Guid("5c3907fd-19eb-4f66-9432-4855b562a4da"),
                            Description = "Other"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblGenre_Id");

                    b.ToTable("tblGenre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f63c99b8-b777-47bf-be7e-7c3068c3c6a1"),
                            Description = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("23d46ffb-f109-461c-bbbf-c21c10bd8c93"),
                            Description = "Action"
                        },
                        new
                        {
                            Id = new Guid("093c0324-05d4-4373-baec-03732ad0091e"),
                            Description = "Sci-Fi"
                        },
                        new
                        {
                            Id = new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"),
                            Description = "Horror"
                        },
                        new
                        {
                            Id = new Guid("8c531b01-61c3-47a1-aca6-f846db7204a5"),
                            Description = "Romance"
                        },
                        new
                        {
                            Id = new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"),
                            Description = "Documentary"
                        },
                        new
                        {
                            Id = new Guid("028d0d6f-51c3-4f86-a6e1-2f25ee1184f6"),
                            Description = "Musical"
                        },
                        new
                        {
                            Id = new Guid("d3be9760-ccb0-406f-b618-00d33d75f36d"),
                            Description = "Mystery"
                        },
                        new
                        {
                            Id = new Guid("9006166d-5132-4c9f-878c-5df9340b78f5"),
                            Description = "Western"
                        },
                        new
                        {
                            Id = new Guid("729b0d48-6c81-43ed-adc5-2e827bedfc0e"),
                            Description = "Other"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblMovie", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FormatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RatingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_tblMovie_Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("FormatId");

                    b.HasIndex("RatingId");

                    b.ToTable("tblMovie", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"),
                            Cost = 6.9900000000000002,
                            Description = "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.",
                            DirectorId = new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"),
                            FormatId = new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"),
                            ImagePath = "Rocky.jpg",
                            Quantity = 2,
                            RatingId = new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"),
                            Title = "Rocky"
                        },
                        new
                        {
                            Id = new Guid("08789a8c-fe0c-443d-8686-77f5096df5eb"),
                            Cost = 6.9900000000000002,
                            Description = "Other",
                            DirectorId = new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"),
                            FormatId = new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"),
                            ImagePath = "Rocky.jpg",
                            Quantity = 2,
                            RatingId = new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"),
                            Title = "Other"
                        },
                        new
                        {
                            Id = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"),
                            Cost = 8.9900000000000002,
                            Description = "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.",
                            DirectorId = new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"),
                            FormatId = new Guid("23142f21-ccb5-43a8-9926-166385a5361c"),
                            ImagePath = "Jaws1.jpg",
                            Quantity = 1,
                            RatingId = new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"),
                            Title = "Jaws"
                        },
                        new
                        {
                            Id = new Guid("53befc7f-23f1-4580-b972-cb714f488920"),
                            Cost = 12.5,
                            Description = "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.",
                            DirectorId = new Guid("16ece54a-c9fe-49f5-b9ed-4a953180eb94"),
                            FormatId = new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"),
                            ImagePath = "PrincessBride.jpg",
                            Quantity = 4,
                            RatingId = new Guid("9ccd0049-0e5a-42a7-86f3-246532b801ca"),
                            Title = "The Princess Bride"
                        },
                        new
                        {
                            Id = new Guid("e62fb400-5e0f-4291-8b06-89d885882214"),
                            Cost = 10.5,
                            Description = "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.",
                            DirectorId = new Guid("32e9f38c-010e-4bc3-b59d-fccc64ddec66"),
                            FormatId = new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"),
                            ImagePath = "IndianaJonesLastCrusade.jpg",
                            Quantity = 2,
                            RatingId = new Guid("7a6fed5e-352c-44a4-802a-328372cb4c91"),
                            Title = "Indiana Jones and the Last Crusade"
                        },
                        new
                        {
                            Id = new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f"),
                            Cost = 7.5,
                            Description = "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.",
                            DirectorId = new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"),
                            FormatId = new Guid("23142f21-ccb5-43a8-9926-166385a5361c"),
                            ImagePath = "StarWarsNewHope.jpg",
                            Quantity = 1,
                            RatingId = new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"),
                            Title = "Star Wars: Episode IV – A New Hope"
                        },
                        new
                        {
                            Id = new Guid("4e757b1c-a7c9-4c83-addd-1a0d1a25847c"),
                            Cost = 9.9900000000000002,
                            Description = "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.",
                            DirectorId = new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"),
                            FormatId = new Guid("23142f21-ccb5-43a8-9926-166385a5361c"),
                            ImagePath = "PaleRider.jpg",
                            Quantity = 1,
                            RatingId = new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"),
                            Title = "Pale Rider"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblMovieGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblMovieGenre_Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("tblMovieGenre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("36d6e229-81cc-4c57-8c68-53beddc92b42"),
                            GenreId = new Guid("093c0324-05d4-4373-baec-03732ad0091e"),
                            MovieId = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1")
                        },
                        new
                        {
                            Id = new Guid("ae4d320e-105c-40bc-8300-6b6d36b5f36d"),
                            GenreId = new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"),
                            MovieId = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1")
                        },
                        new
                        {
                            Id = new Guid("5c14f479-a9e8-4e8e-bfcd-5195107e3cdd"),
                            GenreId = new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"),
                            MovieId = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1")
                        },
                        new
                        {
                            Id = new Guid("d74d228f-032b-4e39-928e-f9942f1d2423"),
                            GenreId = new Guid("093c0324-05d4-4373-baec-03732ad0091e"),
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad")
                        },
                        new
                        {
                            Id = new Guid("0c10a020-6e3c-4f1a-b280-f86e65a99fed"),
                            GenreId = new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"),
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad")
                        },
                        new
                        {
                            Id = new Guid("46ef6601-f065-4f1a-ab7b-0c2c6bf5d8e2"),
                            GenreId = new Guid("f63c99b8-b777-47bf-be7e-7c3068c3c6a1"),
                            MovieId = new Guid("53befc7f-23f1-4580-b972-cb714f488920")
                        },
                        new
                        {
                            Id = new Guid("ad2f2eca-87cc-4824-ac85-39fecf80927e"),
                            GenreId = new Guid("23d46ffb-f109-461c-bbbf-c21c10bd8c93"),
                            MovieId = new Guid("53befc7f-23f1-4580-b972-cb714f488920")
                        },
                        new
                        {
                            Id = new Guid("31757b2a-6781-4908-8d3a-0a86e4fe8e41"),
                            GenreId = new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"),
                            MovieId = new Guid("53befc7f-23f1-4580-b972-cb714f488920")
                        },
                        new
                        {
                            Id = new Guid("ad610025-0bda-4cfc-963d-f766c1413cd0"),
                            GenreId = new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"),
                            MovieId = new Guid("e62fb400-5e0f-4291-8b06-89d885882214")
                        },
                        new
                        {
                            Id = new Guid("5ee2e309-6c91-46bc-b671-9ffe5346b859"),
                            GenreId = new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"),
                            MovieId = new Guid("e62fb400-5e0f-4291-8b06-89d885882214")
                        },
                        new
                        {
                            Id = new Guid("36952bf3-ef24-45f4-861d-bb07bcb894a6"),
                            GenreId = new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"),
                            MovieId = new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f")
                        },
                        new
                        {
                            Id = new Guid("5ec1a379-a3d3-40cb-a136-9648fe221bb7"),
                            GenreId = new Guid("028d0d6f-51c3-4f86-a6e1-2f25ee1184f6"),
                            MovieId = new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f")
                        },
                        new
                        {
                            Id = new Guid("3a55a021-8b5b-4c94-bc75-13914e18fe51"),
                            GenreId = new Guid("d3be9760-ccb0-406f-b618-00d33d75f36d"),
                            MovieId = new Guid("4e757b1c-a7c9-4c83-addd-1a0d1a25847c")
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblOrder_Id");

                    b.ToTable("tblOrder", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"),
                            CustomerId = new Guid("4814a71d-1eef-4832-9fe4-9d7daa75d9d8"),
                            OrderDate = new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShipDate = new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("65f96797-88bc-4379-94bb-56028850b5eb")
                        },
                        new
                        {
                            Id = new Guid("09600631-84c7-4129-bc33-366ae0087656"),
                            CustomerId = new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"),
                            OrderDate = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShipDate = new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("65f96797-88bc-4379-94bb-56028850b5eb")
                        },
                        new
                        {
                            Id = new Guid("56dc8827-dbf3-4bcd-b92d-34cb2fb458cb"),
                            CustomerId = new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"),
                            OrderDate = new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShipDate = new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("dc528bbe-944a-4dac-9598-6b730917dc35")
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblOrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_tblOrderItem_Id");

                    b.ToTable("tblOrderItem", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c929c4e-47c1-4754-bdc3-c100167a1722"),
                            Cost = 8.9900000000000002,
                            MovieId = new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"),
                            OrderId = new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("92216f8c-c67c-4a6a-9195-6f9f32cc8933"),
                            Cost = 9.9900000000000002,
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"),
                            OrderId = new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("17cc5db9-e76c-4e0e-807b-85c80c35274a"),
                            Cost = 10.99,
                            MovieId = new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"),
                            OrderId = new Guid("09600631-84c7-4129-bc33-366ae0087656"),
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblRating", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblRating_Id");

                    b.ToTable("tblRating", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"),
                            Description = "G"
                        },
                        new
                        {
                            Id = new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"),
                            Description = "PG-13"
                        },
                        new
                        {
                            Id = new Guid("9ccd0049-0e5a-42a7-86f3-246532b801ca"),
                            Description = "PG"
                        },
                        new
                        {
                            Id = new Guid("7a6fed5e-352c-44a4-802a-328372cb4c91"),
                            Description = "R"
                        },
                        new
                        {
                            Id = new Guid("d75b1a7c-9b31-45c8-9ecd-be4204a06106"),
                            Description = "Other"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(28)
                        .IsUnicode(false)
                        .HasColumnType("varchar(28)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id")
                        .HasName("PK_tblUser_Id");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da"),
                            FirstName = "Steve",
                            LastName = "Marin",
                            Password = "pYfdnNb8sO0FgS4H0MRSwLGOIME=",
                            UserName = "smarin"
                        },
                        new
                        {
                            Id = new Guid("65f96797-88bc-4379-94bb-56028850b5eb"),
                            FirstName = "John",
                            LastName = "Doro",
                            Password = "pYfdnNb8sO0FgS4H0MRSwLGOIME=",
                            UserName = "jdoro"
                        },
                        new
                        {
                            Id = new Guid("dc528bbe-944a-4dac-9598-6b730917dc35"),
                            FirstName = "Brian",
                            LastName = "Foote",
                            Password = "pYfdnNb8sO0FgS4H0MRSwLGOIME=",
                            UserName = "bfoote"
                        });
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblCart", b =>
                {
                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblCartItem", b =>
                {
                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblCart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblMovie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblMovie", b =>
                {
                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblDirector", "Director")
                        .WithMany("tblMovies")
                        .HasForeignKey("DirectorId")
                        .IsRequired()
                        .HasConstraintName("fk_tblMovie_DirectorId");

                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblFormat", "Format")
                        .WithMany("tblMovies")
                        .HasForeignKey("FormatId")
                        .IsRequired()
                        .HasConstraintName("fk_tblMovie_FormatId");

                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblRating", "Rating")
                        .WithMany("tblMovies")
                        .HasForeignKey("RatingId")
                        .IsRequired()
                        .HasConstraintName("fk_tblMovie_RatingId");

                    b.Navigation("Director");

                    b.Navigation("Format");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblMovieGenre", b =>
                {
                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblGenre", "Genre")
                        .WithMany("tblMovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tblMovieGenre_GenreId");

                    b.HasOne("BJM.DVDCentral.PL2.Entities.tblMovie", "Movie")
                        .WithMany("tblMovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tblMovieGenre_MovieId");

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblDirector", b =>
                {
                    b.Navigation("tblMovies");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblFormat", b =>
                {
                    b.Navigation("tblMovies");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblGenre", b =>
                {
                    b.Navigation("tblMovieGenres");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblMovie", b =>
                {
                    b.Navigation("tblMovieGenres");
                });

            modelBuilder.Entity("BJM.DVDCentral.PL2.Entities.tblRating", b =>
                {
                    b.Navigation("tblMovies");
                });
#pragma warning restore 612, 618
        }
    }
}