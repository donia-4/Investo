using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investo.Migrations.RealTimeDb
{
    /// <inheritdoc />
    public partial class initialRealTimeServiceCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RealTime");

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenChatRequests",
                schema: "RealTime",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestorId = table.Column<int>(type: "int", nullable: false),
                    BusinessOwnerId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InitialMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsInvestorVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsProjectActive = table.Column<bool>(type: "bit", nullable: false),
                    PassedAutomatedScan = table.Column<bool>(type: "bit", nullable: false),
                    PolicyViolationReasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewedByAdminId = table.Column<int>(type: "int", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminComments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenChatRequests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalSchema: "RealTime",
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Offer", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RealTime",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "RealTime",
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
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Project_projectId",
                        column: x => x.projectId,
                        principalSchema: "RealTime",
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_InvestorUserId",
                schema: "RealTime",
                table: "Category",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AttachmentId",
                schema: "RealTime",
                table: "Messages",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BusinessOwnerUserId",
                schema: "RealTime",
                table: "Messages",
                column: "BusinessOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_InvestorUserId",
                schema: "RealTime",
                table: "Messages",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProjectId",
                schema: "RealTime",
                table: "Messages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                schema: "RealTime",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "RealTime",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverUserId",
                schema: "RealTime",
                table: "Notifications",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_BusinessOwnerUserId",
                schema: "RealTime",
                table: "Offer",
                column: "BusinessOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_InvestorId",
                schema: "RealTime",
                table: "Offer",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ProjectId",
                schema: "RealTime",
                table: "Offer",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryId",
                schema: "RealTime",
                table: "Project",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_InvestorUserId",
                schema: "RealTime",
                table: "Project",
                column: "InvestorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_projectId",
                schema: "RealTime",
                table: "User",
                column: "projectId",
                unique: true,
                filter: "[projectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_InvestorUserId",
                schema: "RealTime",
                table: "Category",
                column: "InvestorUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Project_ProjectId",
                schema: "RealTime",
                table: "Messages",
                column: "ProjectId",
                principalSchema: "RealTime",
                principalTable: "Project",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_BusinessOwnerUserId",
                schema: "RealTime",
                table: "Messages",
                column: "BusinessOwnerUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_InvestorUserId",
                schema: "RealTime",
                table: "Messages",
                column: "InvestorUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_ReceiverId",
                schema: "RealTime",
                table: "Messages",
                column: "ReceiverId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_SenderId",
                schema: "RealTime",
                table: "Messages",
                column: "SenderId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_User_ReceiverUserId",
                schema: "RealTime",
                table: "Notifications",
                column: "ReceiverUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Project_ProjectId",
                schema: "RealTime",
                table: "Offer",
                column: "ProjectId",
                principalSchema: "RealTime",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_User_BusinessOwnerUserId",
                schema: "RealTime",
                table: "Offer",
                column: "BusinessOwnerUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_User_InvestorId",
                schema: "RealTime",
                table: "Offer",
                column: "InvestorId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_InvestorUserId",
                schema: "RealTime",
                table: "Project",
                column: "InvestorUserId",
                principalSchema: "RealTime",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_InvestorUserId",
                schema: "RealTime",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_InvestorUserId",
                schema: "RealTime",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "OpenChatRequests",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "User",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "RealTime");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "RealTime");
        }
    }
}
