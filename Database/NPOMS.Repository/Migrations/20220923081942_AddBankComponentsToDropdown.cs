using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddBankComponentsToDropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "core",
                table: "DocumentTypes",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "AccountTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "SAVINGS", null, null, null },
                    { 2, "CURRENT", null, null, null },
                    { 3, "TRANSMISSION", null, null, null },
                    { 4, "Subscription Share", null, null, null },
                    { 5, "BOND", null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Banks",
                columns: new[] { "Id", "Code", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "632005", "ABSA Bank", null, null },
                    { 2, "470010", "Capitec Bank", null, null },
                    { 3, "250655", "First National Bank", null, null },
                    { 4, "198675", "NedBank", null, null },
                    { 5, "051001", "Standard Bank", null, null },
                    { 6, null, "International Bank", null, null },
                    { 7, "580105", "Investec Bank", null, null },
                    { 8, "460005", "Post Bank", null, null },
                    { 9, "000000", "Default", null, null },
                    { 10, null, "Bidvest", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 1, null, "All Branches", null, null },
                    { 2, 1, null, "Barrydale", null, null },
                    { 3, 1, null, "Beaufort West", null, null },
                    { 4, 1, null, "Bellville", null, null },
                    { 5, 1, null, "Bonnievale", null, null },
                    { 6, 1, null, "Brackenfell", null, null },
                    { 7, 1, null, "Bredasdorp", null, null },
                    { 8, 1, null, "Caledon", null, null },
                    { 9, 1, null, "Cape Gate", null, null },
                    { 10, 1, null, "Centurion", null, null },
                    { 11, 1, null, "Century City", null, null },
                    { 12, 1, null, "Ceres", null, null },
                    { 13, 1, null, "Citrusdal", null, null },
                    { 14, 1, null, "Clanwilliam", null, null },
                    { 15, 1, null, "Claremont", null, null },
                    { 16, 1, null, "De Doorns", null, null },
                    { 17, 1, null, "Durbanville", null, null },
                    { 18, 1, null, "George", null, null },
                    { 19, 1, null, "Helderberg", null, null },
                    { 20, 1, null, "Hermanus", null, null },
                    { 21, 1, null, "Kenilworth", null, null },
                    { 22, 1, null, "Kraaifontein", null, null },
                    { 23, 1, null, "Kuilsriver", null, null },
                    { 24, 1, null, "Malmesbury", null, null },
                    { 25, 1, null, "Montagu", null, null },
                    { 26, 1, null, "Mossel Bay", null, null },
                    { 27, 1, null, "Mountain Mill", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 28, 1, null, "Mowbray", null, null },
                    { 29, 1, null, "Oudtshoorn", null, null },
                    { 30, 1, null, "Paarl", null, null },
                    { 31, 1, null, "Parow", null, null },
                    { 32, 1, null, "Phillipi", null, null },
                    { 33, 1, null, "Plein Street", null, null },
                    { 34, 1, null, "Plettenberg Bay", null, null },
                    { 35, 1, null, "Porterville", null, null },
                    { 36, 1, null, "Promenade", null, null },
                    { 37, 1, null, "Riebeek Road", null, null },
                    { 38, 1, null, "Riviersonderend", null, null },
                    { 39, 1, null, "Robertson", null, null },
                    { 40, 1, null, "Santyger", null, null },
                    { 41, 1, null, "Somerset mall", null, null },
                    { 42, 1, null, "Stellenbosch", null, null },
                    { 43, 1, null, "Strand", null, null },
                    { 44, 1, null, "Swellendam", null, null },
                    { 45, 1, null, "Tulbagh", null, null },
                    { 46, 1, null, "Tyger Manor", null, null },
                    { 47, 1, null, "Uniondale", null, null },
                    { 48, 1, null, "Villiersdorp", null, null },
                    { 49, 1, null, "Vredendal", null, null },
                    { 50, 1, null, "Wellington", null, null },
                    { 51, 1, null, "Worcester", null, null },
                    { 52, 1, null, "Wynberg", null, null },
                    { 53, 1, null, "Zevenwacht", null, null },
                    { 54, 1, "631309", "Athlone", null, null },
                    { 55, 1, "505210", "Boston Street", null, null },
                    { 56, 1, "630126", "Durban City", null, null },
                    { 57, 1, "334708", "Prince Albert", null, null },
                    { 58, 1, "421109", "Rondebosch", null, null },
                    { 59, 1, "503107", "Stockenstroom Street", null, null },
                    { 60, 1, "334507", "Wolseley", null, null },
                    { 61, 1, null, "Knysna", null, null },
                    { 62, 1, null, "Cape Town Adderley Street", null, null },
                    { 63, 1, null, "KUILSRIVIER", null, null },
                    { 64, 1, null, "McTyre Street, Parow", null, null },
                    { 65, 1, null, "plettenburg", null, null },
                    { 66, 1, null, "RIEBEECKWEG KUILSRIVIER", null, null },
                    { 67, 1, null, "SOMERSET WEST", null, null },
                    { 68, 1, null, "TYGER MALL", null, null },
                    { 69, 1, null, "ZEVENWACHT MALL", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 70, 1, "632005", "Riversdal", null, null },
                    { 71, 1, "000000", "Default", null, null },
                    { 72, 2, null, "Bellville", null, null },
                    { 73, 2, null, "Khayelitsha KBD", null, null },
                    { 74, 2, "200712", "Villiersdorp", null, null },
                    { 75, 2, null, "All Branches", null, null },
                    { 76, 3, null, "Beaufort West", null, null },
                    { 77, 3, null, "Khayelitsha", null, null },
                    { 78, 3, null, "Langeberg Mall", null, null },
                    { 79, 3, null, "Lansdowne", null, null },
                    { 80, 3, null, "Mossel Bay", null, null },
                    { 81, 3, null, "N1 City", null, null },
                    { 82, 3, null, "Paarl", null, null },
                    { 83, 3, null, "Plumstead", null, null },
                    { 84, 3, null, "Promenade", null, null },
                    { 85, 3, null, "Symphony Walk", null, null },
                    { 86, 3, null, "Vangate Mall", null, null },
                    { 87, 3, null, "Vineyard", null, null },
                    { 88, 3, null, "Wellington", null, null },
                    { 89, 3, "200206", "Clanwilliam", null, null },
                    { 90, 3, "210554", "Commercial Account Services", null, null },
                    { 91, 3, "200406", "Garies", null, null },
                    { 92, 3, "201409", "Gugulethu", null, null },
                    { 93, 3, "260557", "Gugulethu Mall", null, null },
                    { 94, 3, "260557", "Gugulethu Square", null, null },
                    { 95, 3, "200809", "Heerengracth", null, null },
                    { 96, 3, "200113", "Heidelberg", null, null },
                    { 97, 3, "271344", "Helderberg", null, null },
                    { 98, 3, "200109", "Kenilworth", null, null },
                    { 99, 3, "200512", "MAIN STREET", null, null },
                    { 100, 3, "200209", "Maitland", null, null },
                    { 101, 3, "200507", "Malmesbury", null, null },
                    { 102, 3, "250040", "Mitchell Plain", null, null },
                    { 103, 3, "204709", "Montagu", null, null },
                    { 104, 3, "200111", "Moorreesburg", null, null },
                    { 105, 3, "250937", "Neelsie", null, null },
                    { 106, 3, "260209", "Pinelands", null, null },
                    { 107, 3, "261251", "Sandton Square", null, null },
                    { 108, 3, "201809", "Sea Point", null, null },
                    { 109, 3, "210229", "Sedgefield", null, null },
                    { 110, 3, "202309", "Simons Town", null, null },
                    { 111, 3, "202509", "Thibault Sqaure", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 112, 3, "201410", "Tygerberg", null, null },
                    { 113, 3, "210655", "Willowbridge", null, null },
                    { 114, 3, "210114", "York Street", null, null },
                    { 115, 3, "201409", "Adderley Street", null, null },
                    { 116, 3, null, "All Branches", null, null },
                    { 117, 3, "202409", "Athlone", null, null },
                    { 118, 3, "200409", "Blue Route", null, null },
                    { 119, 3, "200212", "Caledon", null, null },
                    { 120, 3, "201409", "Cape Town", null, null },
                    { 121, 3, "200107", "Ceres", null, null },
                    { 122, 3, "200109", "Claremont", null, null },
                    { 123, 3, "200207", "De Doorns", null, null },
                    { 124, 3, "200810", "Epping", null, null },
                    { 125, 3, "202309", "Fish Hoek", null, null },
                    { 126, 3, "210114", "george", null, null },
                    { 127, 3, "200312", "Grabouw", null, null },
                    { 128, 3, "203109", "Grassy Park", null, null },
                    { 129, 3, "200412", "Hermanus", null, null },
                    { 130, 3, "204009", "Hout Bay", null, null },
                    { 131, 3, null, "Klawer", null, null },
                    { 132, 3, "210214", "knysna", null, null },
                    { 133, 3, "201110", "Kuilsriver", null, null },
                    { 134, 3, "200213", "Ladismith", null, null },
                    { 135, 3, "210754", "Makhaza", null, null },
                    { 136, 3, "203309", "Milnerton", null, null },
                    { 137, 3, "204709", "Montague Gardens", null, null },
                    { 138, 3, "200309", "Mowbray", null, null },
                    { 139, 3, "202709", "Newlands", null, null },
                    { 140, 3, "210414", "Oudtshoorn", null, null },
                    { 141, 3, "200510", "Parow", null, null },
                    { 142, 3, "200211", "Piketberg", null, null },
                    { 143, 3, "210514", "Plettenberg Bay", null, null },
                    { 144, 3, "200413", "Robertson", null, null },
                    { 145, 3, "201509", "Rondebosch", null, null },
                    { 146, 3, "200411", "Saldanha", null, null },
                    { 147, 3, "200912", "Somerset mall", null, null },
                    { 148, 3, "200610", "Stellenbosch", null, null },
                    { 149, 3, "200612", "Strand", null, null },
                    { 150, 3, "200513", "Swellendam", null, null },
                    { 151, 3, "203809", "Table View", null, null },
                    { 152, 3, "202509", "Thibault Square", null, null },
                    { 153, 3, "200409", "Tokai", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 154, 3, "250040", "Town Centre Mitchell's Plain", null, null },
                    { 155, 3, "200307", "Tulbagh", null, null },
                    { 156, 3, "220323", "Tygervalley", null, null },
                    { 157, 3, "200712", "Villiersdorp", null, null },
                    { 158, 3, "200311", "Vredenburg", null, null },
                    { 159, 3, "200406", "Vredendal", null, null },
                    { 160, 3, "201909", "Woodstock", null, null },
                    { 161, 3, "200407", "Worcester", null, null },
                    { 162, 3, "202209", "Wynberg", null, null },
                    { 163, 3, "260214", "Zevenwacht", null, null },
                    { 164, 3, null, "Town Centre", null, null },
                    { 165, 3, null, "Durbanville", null, null },
                    { 166, 3, null, "250555", null, null },
                    { 167, 3, null, "Adderley Str. Cape Town", null, null },
                    { 168, 3, null, "Adderley Street Cape Town", null, null },
                    { 169, 3, null, "Adderley Street, Cape Town", null, null },
                    { 170, 3, null, "Adderley Street,Cape Town", null, null },
                    { 171, 3, null, "ADDERLY STREET", null, null },
                    { 172, 3, null, "BLUE ROUTE MALL", null, null },
                    { 173, 3, null, "BLUE ROUTE TOKAI", null, null },
                    { 174, 3, null, "EPPINDUST", null, null },
                    { 175, 3, null, "EPPINGDUST", null, null },
                    { 176, 3, null, "Eppingindust", null, null },
                    { 177, 3, null, "GRASSY PARK CAPE TOWN", null, null },
                    { 178, 3, null, "Grassy Park, Cape Town", null, null },
                    { 179, 3, null, "KLAWER SERVICE BRANCHE", null, null },
                    { 180, 3, null, "Kuilsrivier", null, null },
                    { 181, 3, null, "ladiesmith", null, null },
                    { 182, 3, null, "Makhaza Shopping Centre", null, null },
                    { 183, 3, null, "Mlnerton", null, null },
                    { 184, 3, null, "Mobray", null, null },
                    { 185, 3, null, "montague", null, null },
                    { 186, 3, null, "Mosselbay", null, null },
                    { 187, 3, null, "PAROW 002", null, null },
                    { 188, 3, null, "SALDAHNA", null, null },
                    { 189, 3, null, "SANDTON", null, null },
                    { 190, 3, null, "SANDTON SQUARE CRAIGHALL", null, null },
                    { 191, 3, null, "SOMERSET WEST", null, null },
                    { 192, 3, null, "Somerset West Mall", null, null },
                    { 193, 3, null, "Stellenbosch C.P", null, null },
                    { 194, 3, null, "Symphony", null, null },
                    { 195, 3, null, "TYGERVALIE", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 196, 3, null, "VANGATE", null, null },
                    { 197, 3, null, "Vangate Mall Athlone", null, null },
                    { 198, 3, null, "VILLIERSDORD", null, null },
                    { 199, 3, null, "villierssdorp", null, null },
                    { 200, 3, null, "Zevenwacht Mall", null, null },
                    { 201, 4, null, "Ceres", null, null },
                    { 202, 4, "198765", "Avonwood", null, null },
                    { 203, 4, "198765", "Beaufort West", null, null },
                    { 204, 4, "103210", "Bellville East", null, null },
                    { 205, 4, "103310", "Brackenfell", null, null },
                    { 206, 4, "149821", "BUSINESS WINELANDS", null, null },
                    { 207, 4, "441010", "Cape Commercial", null, null },
                    { 208, 4, "145209", "Cavendish Square", null, null },
                    { 209, 4, "167005", "Franschhoek", null, null },
                    { 210, 4, "101009", "Gardens", null, null },
                    { 211, 4, "100909", "Gardens Centre", null, null },
                    { 212, 4, "122005", "GRAHAMSTOWN", null, null },
                    { 213, 4, "103109", "Heerengracht", null, null },
                    { 214, 4, "441012", "Helderberg Commercial", null, null },
                    { 215, 4, "198765", "Inland Garden Route Paarl", null, null },
                    { 216, 4, "198760", "Kenilworth", null, null },
                    { 217, 4, "172305", "Khayaelitsha Mall", null, null },
                    { 218, 4, "155405", "Makhaza", null, null },
                    { 219, 4, "198765", "Mbekweni", null, null },
                    { 220, 4, "107909", "Mitchell Plain", null, null },
                    { 221, 4, "198765", "Montague Gardens", null, null },
                    { 222, 4, "128505", "Moorreesburg", null, null },
                    { 223, 4, "198765", "Nomzamo", null, null },
                    { 224, 4, "118602", "Northern Peninsula", null, null },
                    { 225, 4, "198765", "Paarl Mall", null, null },
                    { 226, 4, "115909", "Peoples Athlone", null, null },
                    { 227, 4, "107909", "Promenade", null, null },
                    { 228, 4, "198765", "Robertson", null, null },
                    { 229, 4, "106909", "Sea Point", null, null },
                    { 230, 4, "123209", "Southern Peninsula", null, null },
                    { 231, 4, "184705", "Stilbaai", null, null },
                    { 232, 4, "128505", "Swartland", null, null },
                    { 233, 4, "118602", "The Bridge", null, null },
                    { 234, 4, "198765", "Tokai", null, null },
                    { 235, 4, "103910", "Tygervalley", null, null },
                    { 236, 4, "128505", "Vredenburg", null, null },
                    { 237, 4, "198765", "Vredendal", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 238, 4, "102905", "Wellington", null, null },
                    { 239, 4, null, "All Branches", null, null },
                    { 240, 4, "193765", "Atlantis", null, null },
                    { 241, 4, "120405", "Belhar", null, null },
                    { 242, 4, "108110", "Bellville", null, null },
                    { 243, 4, "125142", "Bredasdorp", null, null },
                    { 244, 4, "196005", "Caledon", null, null },
                    { 245, 4, "100909", "Cape Town", null, null },
                    { 246, 4, "100989", "Cape Town Station", null, null },
                    { 247, 4, "153305", "Clanwilliam", null, null },
                    { 248, 4, "104609", "Claremont", null, null },
                    { 249, 4, "101109", "Constantia", null, null },
                    { 250, 4, "103710", "Durbanville", null, null },
                    { 251, 4, "153614", "Garden Route", null, null },
                    { 252, 4, "198765", "Garden Route Mall", null, null },
                    { 253, 4, "109114", "George", null, null },
                    { 254, 4, "134512", "Hermanus", null, null },
                    { 255, 4, "187505", "Inland Garden Route", null, null },
                    { 256, 4, "172305", "Khayelitsha", null, null },
                    { 257, 4, "172305", "Khayelitsha Mall", null, null },
                    { 258, 4, "108914", "Knysna", null, null },
                    { 259, 4, "112305", "Kraaifontein", null, null },
                    { 260, 4, "115310", "Kuilsriver", null, null },
                    { 261, 4, "154605", "Malmesbury", null, null },
                    { 262, 4, "144905", "Mitchells Plain", null, null },
                    { 263, 4, "144905", "Mitchell's Plain", null, null },
                    { 264, 4, "168905", "Mossel Bay", null, null },
                    { 265, 4, "110634", "Nonqubela", null, null },
                    { 266, 4, "175205", "Oudtshoorn", null, null },
                    { 267, 4, "102210", "Paarl", null, null },
                    { 268, 4, "114810", "Paarl Lady Grey St", null, null },
                    { 269, 4, "102510", "Parow", null, null },
                    { 270, 4, "107510", "Phillipi", null, null },
                    { 271, 4, "104709", "Pinelands", null, null },
                    { 272, 4, "107909", "Promenade Mall", null, null },
                    { 273, 4, "162645", "Riversdal", null, null },
                    { 274, 4, "104809", "Rondebosch", null, null },
                    { 275, 4, "114145", "Somerset mall", null, null },
                    { 276, 4, "107110", "Stellenbosch", null, null },
                    { 277, 4, "132105", "Swellendam", null, null },
                    { 278, 4, "144905", "Town Centre", null, null },
                    { 279, 4, "118602", "Tygerberg", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 280, 4, "149821", "Winelands Stellenbosch", null, null },
                    { 281, 4, "101507", "Worcester", null, null },
                    { 282, 4, "109114", "York Street", null, null },
                    { 283, 4, "147005", "Zomelust Estate Paarl", null, null },
                    { 284, 4, null, "147005", null, null },
                    { 285, 4, null, "ANTIANTIC", null, null },
                    { 286, 4, null, "ANTLANTIS", null, null },
                    { 287, 4, null, "Beaufort - West", null, null },
                    { 288, 4, null, "Bellville CBD", null, null },
                    { 289, 4, null, "BELLVILLE CDB", null, null },
                    { 290, 4, null, "caldeon", null, null },
                    { 291, 4, null, "CAVENDISH", null, null },
                    { 292, 4, null, "CHURCH SQUARE  KUILS RIVIER", null, null },
                    { 293, 4, null, "HELDERBERG KOMMERSIELE", null, null },
                    { 294, 4, null, "KAAP KOMMERSIEEL", null, null },
                    { 295, 4, null, "KUILSRIVIER", null, null },
                    { 296, 4, null, "Mitchells Plain Town Centre", null, null },
                    { 297, 4, null, "Mitchell's Plain, Promenade Mall", null, null },
                    { 298, 4, null, "Montaque Gardens", null, null },
                    { 299, 4, null, "Mosselbay", null, null },
                    { 300, 4, null, "PROMINADE", null, null },
                    { 301, 4, null, "Seapoint", null, null },
                    { 302, 4, null, "Somerset", null, null },
                    { 303, 4, null, "Somerset Wesr", null, null },
                    { 304, 4, null, "SOMERSET WEST", null, null },
                    { 305, 4, null, "TYGERBERG WINELANDS", null, null },
                    { 306, 4, null, "Winelands", null, null },
                    { 307, 4, "50212", "grabouw", null, null },
                    { 308, 5, "26609", "Athlone", null, null },
                    { 309, 5, "51001", "Bayside", null, null },
                    { 310, 5, "4805", "Braamfontein", null, null },
                    { 311, 5, "30310", "Brackenfell", null, null },
                    { 312, 5, "50011", "Citrusdal", null, null },
                    { 313, 5, "50106", "Clanwilliam", null, null },
                    { 314, 5, "31010", "Goodwood", null, null },
                    { 315, 5, "51108", "Lainsburg", null, null },
                    { 316, 5, "51001", "LYNNWOOD RIDGE", null, null },
                    { 317, 5, "6105", "Mellville", null, null },
                    { 318, 5, "6305", "Northcliff", null, null },
                    { 319, 5, "51001", "Parow West", null, null },
                    { 320, 5, "25309", "Plumstead", null, null },
                    { 321, 5, "25009", "Rondeboch", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 322, 5, "24109", "Sea Point", null, null },
                    { 323, 5, "33112", "Strand", null, null },
                    { 324, 5, "51001", "Thembalethu George", null, null },
                    { 325, 5, "20909", "Thibault Sqaure", null, null },
                    { 326, 5, "50307", "Tulbagh", null, null },
                    { 327, 5, null, "All Branches", null, null },
                    { 328, 5, "50008", "Beaufort West", null, null },
                    { 329, 5, "51001", "Bellville", null, null },
                    { 330, 5, "25609", "Blue Route", null, null },
                    { 331, 5, "50112", "Caledon", null, null },
                    { 332, 5, "50014", "Calitzdorp", null, null },
                    { 333, 5, "23910", "Cape Gate", null, null },
                    { 334, 5, "20009", "Cape Town", null, null },
                    { 335, 5, "50007", "Ceres", null, null },
                    { 336, 5, "25109", "Claremont", null, null },
                    { 337, 5, "25309", "Constantia", null, null },
                    { 338, 5, "50111", "Darling", null, null },
                    { 339, 5, "50107", "De Doorns", null, null },
                    { 340, 5, "50114", "De rust", null, null },
                    { 341, 5, "36009", "Fish Hoek", null, null },
                    { 342, 5, "25909", "Gatesville", null, null },
                    { 343, 5, "50214", "George", null, null },
                    { 344, 5, "50212", "Grabouw", null, null },
                    { 345, 5, "33012", "Helderberg", null, null },
                    { 346, 5, "50312", "Hermanus", null, null },
                    { 347, 5, "25909", "Khayelitsha", null, null },
                    { 348, 5, "50314", "Knysna", null, null },
                    { 349, 5, "26209", "Kromboom", null, null },
                    { 350, 5, "50611", "Laaiplek", null, null },
                    { 351, 5, "50113", "Ladismith", null, null },
                    { 352, 5, "50206", "Lamberts Bay", null, null },
                    { 353, 5, "50507", "Malmesbury", null, null },
                    { 354, 5, "26509", "Milnerton", null, null },
                    { 355, 5, "50213", "Montagu", null, null },
                    { 356, 5, "50414", "Mossel Bay", null, null },
                    { 357, 5, "24909", "Mowbray", null, null },
                    { 358, 5, "50514", "Oudtshoorn", null, null },
                    { 359, 5, "50210", "Paarl", null, null },
                    { 360, 5, "31110", "Parow", null, null },
                    { 361, 5, "50411", "Piketberg", null, null },
                    { 362, 5, "36309", "Pinelands", null, null },
                    { 363, 5, "50714", "Plettenberg Bay", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 364, 5, "50207", "Porterville", null, null },
                    { 365, 5, "26609", "Promenade", null, null },
                    { 366, 5, "50413", "Robertson", null, null },
                    { 367, 5, "25009", "Rondebosch", null, null },
                    { 368, 5, "33012", "Somerset mall", null, null },
                    { 369, 5, "50610", "Stellenbosch", null, null },
                    { 370, 5, "50513", "Swellendam", null, null },
                    { 371, 5, "102510", "Thibault Square", null, null },
                    { 372, 5, "50410", "Tyger Manor", null, null },
                    { 373, 5, "50215", "Uniondale", null, null },
                    { 374, 5, "25909", "Vangate Mall", null, null },
                    { 375, 5, "50511", "Vredenburg", null, null },
                    { 376, 5, "50706", "Vredendal", null, null },
                    { 377, 5, "50710", "Wellington", null, null },
                    { 378, 5, "50407", "Worcester", null, null },
                    { 379, 5, "25309", "Wynberg", null, null },
                    { 380, 5, null, "Beaufort- West", null, null },
                    { 381, 5, null, "Blue Route Centre", null, null },
                    { 382, 5, null, "BLUE ROUTE MALL, TOKAI", null, null },
                    { 383, 5, null, "Hyde Park", null, null },
                    { 384, 5, null, "Johannesburg", null, null },
                    { 385, 5, null, "Kroomboom", null, null },
                    { 386, 5, null, "LAMBERSBAAI", null, null },
                    { 387, 5, null, "LAMBERTSBAAI", null, null },
                    { 388, 5, null, "Lambertsbay", null, null },
                    { 389, 5, null, "MISGUND", null, null },
                    { 390, 5, null, "Mobray", null, null },
                    { 391, 5, null, "Mosselbaai", null, null },
                    { 392, 5, null, "Mosselbay", null, null },
                    { 393, 5, null, "Mowbray Cape Town", null, null },
                    { 394, 5, null, "Parow centre", null, null },
                    { 395, 5, null, "PORTVILLE", null, null },
                    { 396, 5, null, "Promenade 1", null, null },
                    { 397, 5, null, "Prominade", null, null },
                    { 398, 5, null, "PROMINADE 1", null, null },
                    { 399, 5, null, "Somerset West", null, null },
                    { 400, 5, null, "Thibaullt Square", null, null },
                    { 401, 5, null, "Tygar Manor", null, null },
                    { 402, 5, null, "TYGER MINOR", null, null },
                    { 403, 5, null, "tyger minor duplicate", null, null },
                    { 404, 5, null, "TYGERMINOR", null, null },
                    { 405, 5, null, "TYGOR MINOR", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Branches",
                columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 406, 5, null, "Universal Code", null, null },
                    { 407, 5, null, "Van Rhynsdorp", null, null },
                    { 408, 5, null, "VANGATE", null, null },
                    { 409, 6, null, "Walvis Bay", null, null },
                    { 410, 6, null, "All Branches", null, null },
                    { 411, 7, "450109", "Cape Town", null, null },
                    { 412, 7, "198765", "Oudtshoorn", null, null },
                    { 413, 7, null, "All Branches", null, null },
                    { 414, 8, null, "Bloemfontein", null, null },
                    { 415, 8, null, "LANGA", null, null },
                    { 416, 8, null, "Phillipi Post Office", null, null },
                    { 417, 8, "26209", "Kromboom", null, null },
                    { 418, 8, "51001", "Oudtshoorn", null, null },
                    { 419, 8, null, "All Branches", null, null },
                    { 420, 8, null, "Kroomboom", null, null },
                    { 421, 9, "000000", "Default", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Workplan");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Workplan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "dropdown");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "core",
                table: "DocumentTypes");
        }
    }
}
