using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyProject.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKubernetesConfigFileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cluster");

            migrationBuilder.DropTable(
                name: "Context");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ClusterDetails");

            migrationBuilder.DropTable(
                name: "ContextDetails");

            migrationBuilder.DropTable(
                name: "KubernetesClusterConfigs");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClusterDetails",
                columns: table => new
                {
                    ClusterDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateAuthorityData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Server = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterDetails", x => x.ClusterDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "ContextDetails",
                columns: table => new
                {
                    ContextDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cluster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContextDetails", x => x.ContextDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "KubernetesClusterConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KubernetesClusterConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCertificateData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientKeyData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Cluster",
                columns: table => new
                {
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsClusterDetailsId = table.Column<int>(type: "int", nullable: true),
                    KubernetesClusterConfigId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cluster", x => x.ClusterId);
                    table.ForeignKey(
                        name: "FK_Cluster_ClusterDetails_DetailsClusterDetailsId",
                        column: x => x.DetailsClusterDetailsId,
                        principalTable: "ClusterDetails",
                        principalColumn: "ClusterDetailsId");
                    table.ForeignKey(
                        name: "FK_Cluster_KubernetesClusterConfigs_KubernetesClusterConfigId",
                        column: x => x.KubernetesClusterConfigId,
                        principalTable: "KubernetesClusterConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Context",
                columns: table => new
                {
                    ContextId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsContextDetailsId = table.Column<int>(type: "int", nullable: true),
                    KubernetesClusterConfigId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Context", x => x.ContextId);
                    table.ForeignKey(
                        name: "FK_Context_ContextDetails_DetailsContextDetailsId",
                        column: x => x.DetailsContextDetailsId,
                        principalTable: "ContextDetails",
                        principalColumn: "ContextDetailsId");
                    table.ForeignKey(
                        name: "FK_Context_KubernetesClusterConfigs_KubernetesClusterConfigId",
                        column: x => x.KubernetesClusterConfigId,
                        principalTable: "KubernetesClusterConfigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailsUserDetailsId = table.Column<int>(type: "int", nullable: true),
                    KubernetesClusterConfigId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_KubernetesClusterConfigs_KubernetesClusterConfigId",
                        column: x => x.KubernetesClusterConfigId,
                        principalTable: "KubernetesClusterConfigs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserDetails_DetailsUserDetailsId",
                        column: x => x.DetailsUserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "UserDetailsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cluster_DetailsClusterDetailsId",
                table: "Cluster",
                column: "DetailsClusterDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cluster_KubernetesClusterConfigId",
                table: "Cluster",
                column: "KubernetesClusterConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Context_DetailsContextDetailsId",
                table: "Context",
                column: "DetailsContextDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Context_KubernetesClusterConfigId",
                table: "Context",
                column: "KubernetesClusterConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DetailsUserDetailsId",
                table: "User",
                column: "DetailsUserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_KubernetesClusterConfigId",
                table: "User",
                column: "KubernetesClusterConfigId");
        }
    }
}
