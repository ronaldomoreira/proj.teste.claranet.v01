using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app.teste.claranet.Migrations.AppMainDb
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "Bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TelefoneComercial = table.Column<string>(type: "varchar(20)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(20)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Num = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    NomeContato = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
