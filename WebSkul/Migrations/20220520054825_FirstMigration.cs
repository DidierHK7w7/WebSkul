using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSkul.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationYear = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Working = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "City", "Country", "CreationYear", "Name", "SchoolType" },
                values: new object[] { "dfbef93c-220b-4f58-a12d-d444f811f483", "Groove Street", "San Andreas", "Los Santos", 2005, "Platzi School", 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Address", "Name", "SchoolId", "Working" },
                values: new object[,]
                {
                    { "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Groove Street", "501", "dfbef93c-220b-4f58-a12d-d444f811f483", 1 },
                    { "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Groove Street", "401", "dfbef93c-220b-4f58-a12d-d444f811f483", 1 },
                    { "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Groove Street", "301", "dfbef93c-220b-4f58-a12d-d444f811f483", 0 },
                    { "e4433ed8-5e29-4362-870b-482728e3081f", "Groove Street", "201", "dfbef93c-220b-4f58-a12d-d444f811f483", 0 },
                    { "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Groove Street", "101", "dfbef93c-220b-4f58-a12d-d444f811f483", 0 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { "00291cf2-daa8-4600-8b0d-81ac3f087a15", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Mike Yamabuki Dogg" },
                    { "0060f6a9-2f51-4335-bd2c-ecf50c64fe90", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Wu Lawrence Dogg" },
                    { "00ad70de-d4e6-401b-aa6e-679bd136a489", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "OG Hitori Smoke" },
                    { "012192df-9cbe-4c0e-8bd1-2095ddb8cf29", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Madd Lawrence Toreno" },
                    { "01520db3-aae4-4d3f-a41e-29e6441166ad", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Mike Hitori Toreno" },
                    { "01c2113a-e807-4188-b025-9b81d9cbbd9a", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Cesar Hikawa Smoke" },
                    { "01c53c85-64d6-4512-b108-4d08154cebdd", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Mike Ichigaya Johnson" },
                    { "01c59bc5-f57f-485f-b80e-2892ba6c8694", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Mike Yamabuki Loc" },
                    { "01cc1fbe-e7f0-4225-933b-1ccba5326a3c", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Wu Lawrence Dogg" },
                    { "01ec4396-9c28-49a2-8dda-822038475e9e", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Cesar Yamabuki Dogg" },
                    { "01eda820-97f2-416c-b781-bcf321ba196f", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Big Yamabuki Dogg" },
                    { "020e5e49-aaaa-4ab1-a024-fb443a74b2e8", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Carl Aoba Zi Mu" },
                    { "027e7e0d-4e16-4b84-9760-35e075f81880", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Wu Lawrence Loc" },
                    { "02a31bda-6afd-41de-9d99-104ec3490cfe", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Wu Aoba Dogg" },
                    { "02e44cf9-0dcb-49f2-a151-953143a78456", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Carl Hikawa Loc" },
                    { "030e7341-c0f6-4db7-b9c0-67f628e08f4a", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Wu Lawrence Zi Mu" },
                    { "0310fe2c-5477-409a-897a-fe8693f0aeb7", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Carl Hikawa Dogg" },
                    { "032cbb7e-9db2-421a-bc04-9cabb619e9bf", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Madd Hikawa Toreno" },
                    { "033aa716-21e6-40ba-9e2c-8a71dd961401", "e4433ed8-5e29-4362-870b-482728e3081f", "Mike Hitori Toreno" },
                    { "039e5ee7-bbdb-4a51-981a-ca0d008ae274", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "OG Hitori Toreno" },
                    { "03a40cce-ebf7-403c-be85-f92b03bb6df7", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "OG Hitori Johnson" },
                    { "03c73c5f-f040-414d-b2e3-4b2df26c117a", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Mike Hikawa Zi Mu" },
                    { "03cf0b7a-444a-4285-8597-e960f483fe04", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Carl Aoba Dogg" },
                    { "0406eb6b-913d-42af-b71f-10c3c1b91a83", "e4433ed8-5e29-4362-870b-482728e3081f", "Madd Yamabuki Loc" },
                    { "04613782-3b17-481d-9fe6-429f8d86ea06", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Big Aoba Smoke" },
                    { "04a50e5c-c983-45e4-9b65-8dc6895606b6", "e4433ed8-5e29-4362-870b-482728e3081f", "Madd Yamabuki Smoke" },
                    { "04a51fd5-6f4c-4bc1-bf93-1e755230af52", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Carl Aoba Loc" },
                    { "04aa2634-58df-47a9-8f2a-0508e1437bf3", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Madd Lawrence Zi Mu" },
                    { "04c5850a-3852-45e3-a77e-82cdb6d4b1ac", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "OG Lawrence Toreno" },
                    { "04ca7f6c-3b6f-41a2-960b-4ea85eca9f28", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Carl Ichigaya Johnson" },
                    { "04ed297f-89e9-4e48-8089-287100b1afd2", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Carl Hitori Loc" },
                    { "050c9e08-2d4f-45c8-8305-db5ce5c2f44c", "e4433ed8-5e29-4362-870b-482728e3081f", "Madd Lawrence Loc" },
                    { "050d28cd-ccfa-4fe9-8ad1-d100545b5839", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Wu Aoba Toreno" },
                    { "052a10b9-91e4-4d25-a9a7-c7f9fa60cab2", "e4433ed8-5e29-4362-870b-482728e3081f", "Carl Aoba Loc" },
                    { "060d9044-d970-4209-b720-3045f606e6f8", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Madd Lawrence Dogg" },
                    { "0635f4dc-194a-4143-93cd-91d5776e0fa5", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "OG Hitori Zi Mu" },
                    { "0639a485-c217-4105-985a-c6f498606024", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Wu Hitori Toreno" },
                    { "06449b40-706c-4cbe-a844-23ab052e79a7", "e4433ed8-5e29-4362-870b-482728e3081f", "Carl Mitake Johnson" },
                    { "06dcf749-259e-4c75-b1b2-26027101f9e4", "e4433ed8-5e29-4362-870b-482728e3081f", "Carl Aoba Toreno" },
                    { "073927d8-5918-4f61-a349-4d94f0e3e460", "e4433ed8-5e29-4362-870b-482728e3081f", "Madd Mitake Toreno" },
                    { "076fc439-72aa-4ef8-98d8-177425b3f3f3", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Carl Yamabuki Loc" },
                    { "0842f4be-4208-4363-84cf-7fd6d6fe16b4", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Madd Hikawa Toreno" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { "08497e09-418f-48cb-baec-b5f260e23715", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Mike Aoba Johnson" },
                    { "09b1d2cc-9404-4560-98da-883c052ffc0e", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Mike Hikawa Zi Mu" },
                    { "09db8ef1-5cf0-4725-a6df-8d0079c4fff8", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "OG Hitori Zi Mu" },
                    { "0b0ec2e4-8146-48d2-862a-e6de1a75cc11", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "OG Ichigaya Zi Mu" },
                    { "0b40af11-c1e1-43cf-bf11-3cfd15d400e4", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Wu Hikawa Johnson" },
                    { "0d013268-33e0-4b58-9924-7ad1400a4d19", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Big Hitori Smoke" },
                    { "0df2361d-680e-46f5-9d79-507ae83e13e9", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Cesar Hikawa Loc" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { "02c15d7e-680d-4ece-81a5-68438dd9f981", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Web apps development" },
                    { "07e44316-4103-4194-99b8-2a9c9b09d06d", "e4433ed8-5e29-4362-870b-482728e3081f", "Music" },
                    { "092bfb54-f18e-4d67-bec3-3fe2d6da2903", "e4433ed8-5e29-4362-870b-482728e3081f", "English" },
                    { "134e7cec-534c-4606-8d0d-650539b39820", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Web apps development" },
                    { "1bceb667-a2b5-44ec-89ee-1d5e89452f53", "e4433ed8-5e29-4362-870b-482728e3081f", "Web apps development" },
                    { "1e697cae-5c65-4ca2-9e0c-178472a318b8", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Math" },
                    { "266f2fdf-80ef-444d-a5c0-0890737e6075", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Math" },
                    { "2c1b218f-fef1-4ffe-8161-dee58e623d02", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Web apps development" },
                    { "2f29498c-f33f-45af-95dd-866a9fa3b3e3", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Videogames" },
                    { "38b87867-8fee-4474-93a5-9d93fc6580e5", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Videogames" },
                    { "5865cddf-5b11-40f2-aad2-9d886e53583d", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Music" },
                    { "680825c1-c6e8-4fac-9b4c-2ebbade212a4", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Math" },
                    { "74cd0019-84e5-4f0e-919e-5b4912c60412", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "Music" },
                    { "91aab658-308b-4e01-9d92-b42dc3d8900c", "8bf2bc27-97ed-481c-8b84-cb03dd2dd9f2", "English" },
                    { "a0fbfc2f-8760-487e-a5da-bd7c1084ed4c", "e4433ed8-5e29-4362-870b-482728e3081f", "Videogames" },
                    { "a37c37f1-6199-4570-b46d-f840f5b2045c", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Videogames" },
                    { "ae8f2da4-d80a-4b72-8ef0-b170a94ae3ca", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Music" },
                    { "cde296e1-46d6-4f34-8690-b9f8d2dc5832", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "Videogames" },
                    { "da6c5f50-b244-4371-9e4d-62401c35ebe0", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "English" },
                    { "da9e8ed7-b9b8-40af-9fe6-5a6ac67921e8", "e4433ed8-5e29-4362-870b-482728e3081f", "Math" },
                    { "dab301b6-80b5-41ae-a966-5be63a847c9d", "7dd213e2-d805-4108-bf7e-8461b3afa6d2", "English" },
                    { "e548b5ee-4595-4530-a559-40d446d1aab3", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "Math" },
                    { "eafbb9c3-0c57-4c49-977c-477a7165e87d", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Music" },
                    { "f142d1c5-5434-4fe9-9f7a-ed65a2738337", "edb1d8f4-0f2c-4a97-b803-23457b057ee0", "Web apps development" },
                    { "f3215bb2-22a8-4f22-bc31-04e1fde9e636", "ae5b35f6-d485-4387-98e1-747efd0b7c66", "English" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
