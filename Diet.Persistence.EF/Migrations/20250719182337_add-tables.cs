using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DurationAge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurationAge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodStuff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStuff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowToUse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Low = table.Column<int>(type: "int", nullable: false),
                    Medium = table.Column<int>(type: "int", nullable: false),
                    High = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplementGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ZarinPalAuthority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZarinPalRefNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food_Drug_Intraction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Drug_Intraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Drug_Intraction_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_Drug_Intraction_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food_Food_Intraction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodFistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodSecondId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Food_Intraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Food_Intraction_Food_FoodFistId",
                        column: x => x.FoodFistId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Food_Food_Intraction_Food_FoodSecondId",
                        column: x => x.FoodSecondId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationDisease_WhiteList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationDisease_WhiteList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationDisease_WhiteList_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationDisease_WhiteList_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationDurationAge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationAgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationDurationAge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationDurationAge_DurationAge_DurationAgeId",
                        column: x => x.DurationAgeId,
                        principalTable: "DurationAge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationDurationAge_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationLifeCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecommendationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LifeCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationLifeCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationLifeCourse_LifeCourse_LifeCourseId",
                        column: x => x.LifeCourseId,
                        principalTable: "LifeCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationLifeCourse_Recommendation_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowToUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplementGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplement_SupplementGroup_SupplementGroupId",
                        column: x => x.SupplementGroupId,
                        principalTable: "SupplementGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BodyActivity = table.Column<int>(type: "int", nullable: false),
                    IsSport = table.Column<bool>(type: "bit", nullable: false),
                    SportActivity = table.Column<int>(type: "int", nullable: false),
                    ChangeWeightType = table.Column<int>(type: "int", nullable: false),
                    WeightChangeAmount = table.Column<int>(type: "int", nullable: true),
                    ExerciseTime = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseDay = table.Column<int>(type: "int", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BodyForm = table.Column<int>(type: "int", nullable: false),
                    LifeCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Case_LifeCourse_LifeCourseId",
                        column: x => x.LifeCourseId,
                        principalTable: "LifeCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplementDisease_WhiteList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementDisease_WhiteList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplementDisease_WhiteList_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplementDisease_WhiteList_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplementDurationAge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationAgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementDurationAge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplementDurationAge_DurationAge_DurationAgeId",
                        column: x => x.DurationAgeId,
                        principalTable: "DurationAge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplementDurationAge_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplementLifeCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LifeCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementLifeCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplementLifeCourse_LifeCourse_LifeCourseId",
                        column: x => x.LifeCourseId,
                        principalTable: "LifeCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplementLifeCourse_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseDisease",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDisease", x => new { x.CaseId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_CaseDisease_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseDisease_Disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Disease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseDrug",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDrug", x => new { x.CaseId, x.DrugId });
                    table.ForeignKey(
                        name: "FK_CaseDrug_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseDrug_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseFoodStuff",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodStuffAllergyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFoodStuff", x => new { x.CaseId, x.FoodStuffAllergyId });
                    table.ForeignKey(
                        name: "FK_CaseFoodStuff_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseFoodStuff_FoodStuff_FoodStuffAllergyId",
                        column: x => x.FoodStuffAllergyId,
                        principalTable: "FoodStuff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseSupplement",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseSupplement", x => new { x.CaseId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_CaseSupplement_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseSupplement_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMessage_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketMessage_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_FoodId",
                table: "Case",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_LifeCourseId",
                table: "Case",
                column: "LifeCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_SportId",
                table: "Case",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_TransactionId",
                table: "Case",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDisease_DiseaseId",
                table: "CaseDisease",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDrug_DrugId",
                table: "CaseDrug",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFoodStuff_FoodStuffAllergyId",
                table: "CaseFoodStuff",
                column: "FoodStuffAllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseSupplement_SupplementId",
                table: "CaseSupplement",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Drug_Intraction_DrugId",
                table: "Food_Drug_Intraction",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Drug_Intraction_FoodId",
                table: "Food_Drug_Intraction",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Food_Intraction_FoodFistId",
                table: "Food_Food_Intraction",
                column: "FoodFistId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Food_Intraction_FoodSecondId",
                table: "Food_Food_Intraction",
                column: "FoodSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationDisease_WhiteList_DiseaseId",
                table: "RecommendationDisease_WhiteList",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationDisease_WhiteList_RecommendationId",
                table: "RecommendationDisease_WhiteList",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationDurationAge_DurationAgeId",
                table: "RecommendationDurationAge",
                column: "DurationAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationDurationAge_RecommendationId",
                table: "RecommendationDurationAge",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationLifeCourse_LifeCourseId",
                table: "RecommendationLifeCourse",
                column: "LifeCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationLifeCourse_RecommendationId",
                table: "RecommendationLifeCourse",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_SupplementGroupId",
                table: "Supplement",
                column: "SupplementGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementDisease_WhiteList_DiseaseId",
                table: "SupplementDisease_WhiteList",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementDisease_WhiteList_SupplementId",
                table: "SupplementDisease_WhiteList",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementDurationAge_DurationAgeId",
                table: "SupplementDurationAge",
                column: "DurationAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementDurationAge_SupplementId",
                table: "SupplementDurationAge",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementLifeCourse_LifeCourseId",
                table: "SupplementLifeCourse",
                column: "LifeCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementLifeCourse_SupplementId",
                table: "SupplementLifeCourse",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CaseId",
                table: "Ticket",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_FromUserId",
                table: "TicketMessage",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_TicketId",
                table: "TicketMessage",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseDisease");

            migrationBuilder.DropTable(
                name: "CaseDrug");

            migrationBuilder.DropTable(
                name: "CaseFoodStuff");

            migrationBuilder.DropTable(
                name: "CaseSupplement");

            migrationBuilder.DropTable(
                name: "Food_Drug_Intraction");

            migrationBuilder.DropTable(
                name: "Food_Food_Intraction");

            migrationBuilder.DropTable(
                name: "FoodGroup");

            migrationBuilder.DropTable(
                name: "RecommendationDisease_WhiteList");

            migrationBuilder.DropTable(
                name: "RecommendationDurationAge");

            migrationBuilder.DropTable(
                name: "RecommendationLifeCourse");

            migrationBuilder.DropTable(
                name: "SupplementDisease_WhiteList");

            migrationBuilder.DropTable(
                name: "SupplementDurationAge");

            migrationBuilder.DropTable(
                name: "SupplementLifeCourse");

            migrationBuilder.DropTable(
                name: "TicketMessage");

            migrationBuilder.DropTable(
                name: "FoodStuff");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "DurationAge");

            migrationBuilder.DropTable(
                name: "Supplement");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "SupplementGroup");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "LifeCourse");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
