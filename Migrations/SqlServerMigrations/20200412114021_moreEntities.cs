using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class moreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    NHSno = table.Column<string>(nullable: true),
                    CPMSno = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientIdId = table.Column<int>(nullable: true),
                    SlotIdId = table.Column<int>(nullable: true),
                    ClinicIdId = table.Column<int>(nullable: true),
                    InterventionIdId = table.Column<int>(nullable: true),
                    StatusIdId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Clinics_ClinicIdId",
                        column: x => x.ClinicIdId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Interventions_InterventionIdId",
                        column: x => x.InterventionIdId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientIdId",
                        column: x => x.PatientIdId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_TimeSlots_SlotIdId",
                        column: x => x.SlotIdId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Status_StatusIdId",
                        column: x => x.StatusIdId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicIdId",
                table: "Appointments",
                column: "ClinicIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InterventionIdId",
                table: "Appointments",
                column: "InterventionIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientIdId",
                table: "Appointments",
                column: "PatientIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SlotIdId",
                table: "Appointments",
                column: "SlotIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StatusIdId",
                table: "Appointments",
                column: "StatusIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
