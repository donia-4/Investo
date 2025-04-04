using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investo.Migrations
{
    /// <inheritdoc />
    public partial class initialCoreCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CoreEntities");

            migrationBuilder.CreateTable(
                name: "Attachment",
                schema: "CoreEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "CoreEntities",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    InvestorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "CoreEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    BusinessOwnerUserId = table.Column<int>(type: "int", nullable: true),
                    InvestorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalSchema: "CoreEntities",
                        principalTable: "Attachment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "CoreEntities",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: false),
                    ReceiverUserType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                schema: "CoreEntities",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquityPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitShare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvestmentType = table.Column<int>(type: "int", nullable: false),
                    OfferTerms = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AdditionalServices = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    InvestorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    BusinessOwnerUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "CoreEntities",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectImageURL = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProjectVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundingExchange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNeeds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectVision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackagesInvestment = table.Column<bool>(type: "bit", nullable: false),
                    InvestmentNegotiation = table.Column<bool>(type: "bit", nullable: false),
                    ProjectStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvestorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "CoreEntities",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "CoreEntities",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfilePictureURL = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    KYCStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NationalIDDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    projectId = table.Column<int>(type: "int", nullable: true),
                    FullLegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NationalID = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RiskTolerance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentGoals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeographicFocus = table.Column<int>(type: "int", nullable: true),
                    MinInvestmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxInvestmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LiquidityPreferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageViews = table.Column<int>(type: "int", nullable: true),
                    IPAddressLogs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccreditationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetWorth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountDetails = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SourceOfFundsDocument = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    KYCAMLStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Projects_projectId",
                        column: x => x.projectId,
                        principalSchema: "CoreEntities",
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_InvestorUserId",
                schema: "CoreEntities",
                table: "Categories",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AttachmentId",
                schema: "CoreEntities",
                table: "Message",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_BusinessOwnerUserId",
                schema: "CoreEntities",
                table: "Message",
                column: "BusinessOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_InvestorUserId",
                schema: "CoreEntities",
                table: "Message",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ProjectId",
                schema: "CoreEntities",
                table: "Message",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverId",
                schema: "CoreEntities",
                table: "Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                schema: "CoreEntities",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverUserId",
                schema: "CoreEntities",
                table: "Notification",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BusinessOwnerUserId",
                schema: "CoreEntities",
                table: "Offers",
                column: "BusinessOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_InvestorId",
                schema: "CoreEntities",
                table: "Offers",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProjectId",
                schema: "CoreEntities",
                table: "Offers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                schema: "CoreEntities",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_InvestorUserId",
                schema: "CoreEntities",
                table: "Projects",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_projectId",
                schema: "CoreEntities",
                table: "Users",
                column: "projectId",
                unique: true,
                filter: "[projectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_InvestorUserId",
                schema: "CoreEntities",
                table: "Categories",
                column: "InvestorUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Projects_ProjectId",
                schema: "CoreEntities",
                table: "Message",
                column: "ProjectId",
                principalSchema: "CoreEntities",
                principalTable: "Projects",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_BusinessOwnerUserId",
                schema: "CoreEntities",
                table: "Message",
                column: "BusinessOwnerUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_InvestorUserId",
                schema: "CoreEntities",
                table: "Message",
                column: "InvestorUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_ReceiverId",
                schema: "CoreEntities",
                table: "Message",
                column: "ReceiverId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SenderId",
                schema: "CoreEntities",
                table: "Message",
                column: "SenderId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Users_ReceiverUserId",
                schema: "CoreEntities",
                table: "Notification",
                column: "ReceiverUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Projects_ProjectId",
                schema: "CoreEntities",
                table: "Offers",
                column: "ProjectId",
                principalSchema: "CoreEntities",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_BusinessOwnerUserId",
                schema: "CoreEntities",
                table: "Offers",
                column: "BusinessOwnerUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_InvestorId",
                schema: "CoreEntities",
                table: "Offers",
                column: "InvestorId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_InvestorUserId",
                schema: "CoreEntities",
                table: "Projects",
                column: "InvestorUserId",
                principalSchema: "CoreEntities",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_InvestorUserId",
                schema: "CoreEntities",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_InvestorUserId",
                schema: "CoreEntities",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Offers",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Attachment",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "CoreEntities");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "CoreEntities");
        }
    }
}
