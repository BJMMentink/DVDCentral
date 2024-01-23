using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BJM.DVDCentral.PL2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ZIP = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomer_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDirector",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDirector_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenre_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderItem_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRating_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(28)", unicode: false, maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMovie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovie_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblMovie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "tblDirector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_FormatId",
                        column: x => x.FormatId,
                        principalTable: "tblFormat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblMovie_RatingId",
                        column: x => x.RatingId,
                        principalTable: "tblRating",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMovieGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovieGenre_Id", x => x.Id);
                    table.ForeignKey(
                        name: "tblMovieGenre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "tblGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tblMovieGenre_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblCart_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCartItem_tblMovie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCustomer",
                columns: new[] { "Id", "Address", "City", "FirstName", "LastName", "Phone", "State", "UserId", "ZIP" },
                values: new object[,]
                {
                    { new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"), "159 Johnson Avenue", "Allenton", "Brian", "Foote", "9202623415", "WI", new Guid("dc528bbe-944a-4dac-9598-6b730917dc35"), "53142" },
                    { new Guid("450f1945-5527-4c27-8ac1-8e4d3bf96fe8"), "453 Oak Street", "Fond du Lac", "Steve", "Marin", "9205879797", "WI", new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da"), "54935" },
                    { new Guid("4814a71d-1eef-4832-9fe4-9d7daa75d9d8"), "987 Willow Road", "Slinger", "John", "Doro", "9202623345", "WI", new Guid("65f96797-88bc-4379-94bb-56028850b5eb"), "56495" }
                });

            migrationBuilder.InsertData(
                table: "tblDirector",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("16ece54a-c9fe-49f5-b9ed-4a953180eb94"), "Rob", "Reiner" },
                    { new Guid("32e9f38c-010e-4bc3-b59d-fccc64ddec66"), "George", "Lucas" },
                    { new Guid("79638cc1-6a35-4587-a523-4b32b778e5d5"), "Clint", "Eastwood" },
                    { new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"), "John", "Avildsen" },
                    { new Guid("a1c749a9-91cb-42d0-932e-7d94a560ec29"), "Other", "Other" },
                    { new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"), "Steven", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "tblFormat",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"), "VHS" },
                    { new Guid("23142f21-ccb5-43a8-9926-166385a5361c"), "DVD" },
                    { new Guid("5c3907fd-19eb-4f66-9432-4855b562a4da"), "Other" },
                    { new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"), "Blu-Ray" }
                });

            migrationBuilder.InsertData(
                table: "tblGenre",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"), "Horror" },
                    { new Guid("028d0d6f-51c3-4f86-a6e1-2f25ee1184f6"), "Musical" },
                    { new Guid("093c0324-05d4-4373-baec-03732ad0091e"), "Sci-Fi" },
                    { new Guid("23d46ffb-f109-461c-bbbf-c21c10bd8c93"), "Action" },
                    { new Guid("729b0d48-6c81-43ed-adc5-2e827bedfc0e"), "Other" },
                    { new Guid("8c531b01-61c3-47a1-aca6-f846db7204a5"), "Romance" },
                    { new Guid("9006166d-5132-4c9f-878c-5df9340b78f5"), "Western" },
                    { new Guid("d3be9760-ccb0-406f-b618-00d33d75f36d"), "Mystery" },
                    { new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"), "Documentary" },
                    { new Guid("f63c99b8-b777-47bf-be7e-7c3068c3c6a1"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "tblOrder",
                columns: new[] { "Id", "CustomerId", "OrderDate", "ShipDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("09600631-84c7-4129-bc33-366ae0087656"), new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"), new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("65f96797-88bc-4379-94bb-56028850b5eb") },
                    { new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"), new Guid("4814a71d-1eef-4832-9fe4-9d7daa75d9d8"), new DateTime(2017, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("65f96797-88bc-4379-94bb-56028850b5eb") },
                    { new Guid("56dc8827-dbf3-4bcd-b92d-34cb2fb458cb"), new Guid("313bd6c9-0d70-4d16-a5ae-279827af4220"), new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dc528bbe-944a-4dac-9598-6b730917dc35") }
                });

            migrationBuilder.InsertData(
                table: "tblOrderItem",
                columns: new[] { "Id", "Cost", "MovieId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0c929c4e-47c1-4754-bdc3-c100167a1722"), 8.9900000000000002, new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"), new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"), 0 },
                    { new Guid("17cc5db9-e76c-4e0e-807b-85c80c35274a"), 10.99, new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"), new Guid("09600631-84c7-4129-bc33-366ae0087656"), 0 },
                    { new Guid("92216f8c-c67c-4a6a-9195-6f9f32cc8933"), 9.9900000000000002, new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"), new Guid("18ae1071-2ed2-4097-993d-e91f5198668b"), 0 }
                });

            migrationBuilder.InsertData(
                table: "tblRating",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"), "PG-13" },
                    { new Guid("7a6fed5e-352c-44a4-802a-328372cb4c91"), "R" },
                    { new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"), "G" },
                    { new Guid("9ccd0049-0e5a-42a7-86f3-246532b801ca"), "PG" },
                    { new Guid("d75b1a7c-9b31-45c8-9ecd-be4204a06106"), "Other" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da"), "Steve", "Marin", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "smarin" },
                    { new Guid("65f96797-88bc-4379-94bb-56028850b5eb"), "John", "Doro", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "jdoro" },
                    { new Guid("dc528bbe-944a-4dac-9598-6b730917dc35"), "Brian", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "bfoote" }
                });

            migrationBuilder.InsertData(
                table: "tblCart",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"), new Guid("1cdc4b41-5132-4bd2-a8ed-75b385d8e3da") },
                    { new Guid("fa70937e-80f0-4e30-b327-919b0ba45210"), new Guid("65f96797-88bc-4379-94bb-56028850b5eb") }
                });

            migrationBuilder.InsertData(
                table: "tblMovie",
                columns: new[] { "Id", "Cost", "Description", "DirectorId", "FormatId", "ImagePath", "Quantity", "RatingId", "Title" },
                values: new object[,]
                {
                    { new Guid("08789a8c-fe0c-443d-8686-77f5096df5eb"), 6.9900000000000002, "Other", new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"), new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"), "Rocky.jpg", 2, new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"), "Other" },
                    { new Guid("4e757b1c-a7c9-4c83-addd-1a0d1a25847c"), 9.9900000000000002, "Pale Rider is a 1985 American Western film produced and directed by Clint Eastwood, who also stars in the lead role.", new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"), new Guid("23142f21-ccb5-43a8-9926-166385a5361c"), "PaleRider.jpg", 1, new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"), "Pale Rider" },
                    { new Guid("53befc7f-23f1-4580-b972-cb714f488920"), 12.5, "The Princess Bride is a 1987 American fantasy adventure comedy film directed and co-produced by Rob Reiner, starring Cary Elwes, Robin Wright, Mandy Patinkin, Chris Sarandon, Wallace Shawn, André the Giant, and Christopher Guest.", new Guid("16ece54a-c9fe-49f5-b9ed-4a953180eb94"), new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"), "PrincessBride.jpg", 4, new Guid("9ccd0049-0e5a-42a7-86f3-246532b801ca"), "The Princess Bride" },
                    { new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f"), 7.5, "Star Wars: Episode IV – A New Hope is a 1977 American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"), new Guid("23142f21-ccb5-43a8-9926-166385a5361c"), "StarWarsNewHope.jpg", 1, new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"), 6.9900000000000002, "Rocky is a 1976 American sports drama film directed by John G. Avildsen, written by and starring Sylvester Stallone.", new Guid("84938954-eef8-4ca3-bff5-4ef4e8c7c30a"), new Guid("045a1a6e-798a-4e26-95e6-f276a3108ef2"), "Rocky.jpg", 2, new Guid("7aedb592-ea8c-48f9-9354-8ddfe8999241"), "Rocky" },
                    { new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"), 8.9900000000000002, "Jaws is a 1975 American thriller film directed by Steven Spielberg and based on the Peter Benchley 1974 novel of the same name.", new Guid("f7ef962f-1cd2-481f-92f1-f4a367090dfc"), new Guid("23142f21-ccb5-43a8-9926-166385a5361c"), "Jaws1.jpg", 1, new Guid("11fc132f-b64f-41da-a60d-4c9799f9e13b"), "Jaws" },
                    { new Guid("e62fb400-5e0f-4291-8b06-89d885882214"), 10.5, "Indiana Jones and the Last Crusade is a 1989 American action-adventure film directed by Steven Spielberg, from a story co-written by executive producer George Lucas.", new Guid("32e9f38c-010e-4bc3-b59d-fccc64ddec66"), new Guid("dee5c9bc-89e0-4513-a481-8b1876144122"), "IndianaJonesLastCrusade.jpg", 2, new Guid("7a6fed5e-352c-44a4-802a-328372cb4c91"), "Indiana Jones and the Last Crusade" }
                });

            migrationBuilder.InsertData(
                table: "tblCartItem",
                columns: new[] { "Id", "CartId", "MovieId", "Qty" },
                values: new object[,]
                {
                    { new Guid("31b88efd-946c-434a-a346-30ac0e769d57"), new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"), new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1"), 1 },
                    { new Guid("869577d3-ebe9-41eb-90fb-0f0b21a5ae42"), new Guid("fa70937e-80f0-4e30-b327-919b0ba45210"), new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"), 1 },
                    { new Guid("9974448c-07aa-4498-9871-47a541c60a0b"), new Guid("1d94f217-6bb0-49c4-9449-3bdaeb0f1019"), new Guid("cf352713-7c8e-4810-b02c-2038abc1afad"), 2 }
                });

            migrationBuilder.InsertData(
                table: "tblMovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0c10a020-6e3c-4f1a-b280-f86e65a99fed"), new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"), new Guid("cf352713-7c8e-4810-b02c-2038abc1afad") },
                    { new Guid("31757b2a-6781-4908-8d3a-0a86e4fe8e41"), new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"), new Guid("53befc7f-23f1-4580-b972-cb714f488920") },
                    { new Guid("36952bf3-ef24-45f4-861d-bb07bcb894a6"), new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"), new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f") },
                    { new Guid("36d6e229-81cc-4c57-8c68-53beddc92b42"), new Guid("093c0324-05d4-4373-baec-03732ad0091e"), new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1") },
                    { new Guid("3a55a021-8b5b-4c94-bc75-13914e18fe51"), new Guid("d3be9760-ccb0-406f-b618-00d33d75f36d"), new Guid("4e757b1c-a7c9-4c83-addd-1a0d1a25847c") },
                    { new Guid("46ef6601-f065-4f1a-ab7b-0c2c6bf5d8e2"), new Guid("f63c99b8-b777-47bf-be7e-7c3068c3c6a1"), new Guid("53befc7f-23f1-4580-b972-cb714f488920") },
                    { new Guid("5c14f479-a9e8-4e8e-bfcd-5195107e3cdd"), new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"), new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1") },
                    { new Guid("5ec1a379-a3d3-40cb-a136-9648fe221bb7"), new Guid("028d0d6f-51c3-4f86-a6e1-2f25ee1184f6"), new Guid("5bb5a9d9-ac63-456b-adff-fda46a02485f") },
                    { new Guid("5ee2e309-6c91-46bc-b671-9ffe5346b859"), new Guid("ea18a2f9-4fc3-4c03-9e1d-b63bbfcc8553"), new Guid("e62fb400-5e0f-4291-8b06-89d885882214") },
                    { new Guid("ad2f2eca-87cc-4824-ac85-39fecf80927e"), new Guid("23d46ffb-f109-461c-bbbf-c21c10bd8c93"), new Guid("53befc7f-23f1-4580-b972-cb714f488920") },
                    { new Guid("ad610025-0bda-4cfc-963d-f766c1413cd0"), new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"), new Guid("e62fb400-5e0f-4291-8b06-89d885882214") },
                    { new Guid("ae4d320e-105c-40bc-8300-6b6d36b5f36d"), new Guid("019cb7bf-fd5c-4311-bf8b-b81e7a70796c"), new Guid("634d5d9b-3252-419f-b253-e28ea7b3b7d1") },
                    { new Guid("d74d228f-032b-4e39-928e-f9942f1d2423"), new Guid("093c0324-05d4-4373-baec-03732ad0091e"), new Guid("cf352713-7c8e-4810-b02c-2038abc1afad") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_CartId",
                table: "tblCartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartItem_MovieId",
                table: "tblCartItem",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_DirectorId",
                table: "tblMovie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_FormatId",
                table: "tblMovie",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovie_RatingId",
                table: "tblMovie",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_GenreId",
                table: "tblMovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovieGenre_MovieId",
                table: "tblMovieGenre",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartItem");

            migrationBuilder.DropTable(
                name: "tblCustomer");

            migrationBuilder.DropTable(
                name: "tblMovieGenre");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblOrderItem");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblGenre");

            migrationBuilder.DropTable(
                name: "tblMovie");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblDirector");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblRating");
        }
    }
}
