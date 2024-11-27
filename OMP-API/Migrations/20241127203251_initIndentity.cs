using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMP_API.Migrations
{
    /// <inheritdoc />
    public partial class initIndentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__3213E83FFADA5D77", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__3213E83F881D31EE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    exchangeRateToDollar = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Currenci__3213E83F918EF608", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3213E83FBA8D94FA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ImageInput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ImageInp__3213E83F11FB439D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TextInput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TextInpu__3213E83F91C0D28B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    baseRatePerHourBrutto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contract__3213E83F5815878A", x => x.id);
                    table.ForeignKey(
                        name: "FK__ContractT__custo__4A4E069C",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DebitNote",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DebitNot__3213E83F09677558", x => x.id);
                    table.ForeignKey(
                        name: "FK__DebitNote__custo__603D47BB",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Errors__3213E83F74876A49", x => x.id);
                    table.ForeignKey(
                        name: "FK__Errors__customer__6EC0713C",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Groups__3213E83FD3834658", x => x.id);
                    table.ForeignKey(
                        name: "FK__Groups__customer__05A3D694",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTaxRates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rate = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceT__3213E83FF2C8D260", x => x.id);
                    table.ForeignKey(
                        name: "FK__InvoiceTa__custo__40C49C62",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PayrollTaxRates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PayrollT__3213E83F578F27D2", x => x.id);
                    table.ForeignKey(
                        name: "FK__PayrollTa__custo__4589517F",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__3213E83FFD67D6A3", x => x.id);
                    table.ForeignKey(
                        name: "FK__Positions__custo__7B264821",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialGroups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SpecialG__3213E83FF1856CEF", x => x.id);
                    table.ForeignKey(
                        name: "FK__SpecialGr__custo__2BC97F7C",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    contractType = table.Column<int>(type: "int", nullable: false),
                    ratePerHourBrutto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    hours = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payrollTaxRateIds = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payroll__3213E83F7EDFC64D", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payroll__contrac__5B78929E",
                        column: x => x.contractType,
                        principalTable: "ContractTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Payroll__custome__5A846E65",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCost",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    priceNetto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    valueNetto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    vatTax = table.Column<int>(type: "int", nullable: true),
                    vatTaxValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    valueBrutto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceC__3213E83F4730B068", x => x.id);
                    table.ForeignKey(
                        name: "FK__InvoiceCo__custo__4F12BBB9",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__InvoiceCo__vatTa__5006DFF2",
                        column: x => x.vatTax,
                        principalTable: "InvoiceTaxRates",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceIncome",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    priceNetto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    valueNetto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    vatTax = table.Column<int>(type: "int", nullable: true),
                    vatTaxValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    valueBrutto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceI__3213E83F6F4DA711", x => x.id);
                    table.ForeignKey(
                        name: "FK__InvoiceIn__custo__54CB950F",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__InvoiceIn__vatTa__55BFB948",
                        column: x => x.vatTax,
                        principalTable: "InvoiceTaxRates",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    positionId = table.Column<int>(type: "int", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83FD3C01ED7", x => x.id);
                    table.ForeignKey(
                        name: "FK__Users__customerI__7FEAFD3E",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Users__positionI__00DF2177",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ReccuringCostInvoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nextDueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reccurin__3213E83F4D6AC24D", x => x.id);
                    table.ForeignKey(
                        name: "FK__Reccuring__custo__6501FCD8",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Reccuring__invoi__65F62111",
                        column: x => x.invoiceId,
                        principalTable: "InvoiceCost",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ReccuringIncomeInvoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nextDueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reccurin__3213E83FA29DD903", x => x.id);
                    table.ForeignKey(
                        name: "FK__Reccuring__custo__6ABAD62E",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Reccuring__invoi__6BAEFA67",
                        column: x => x.invoiceId,
                        principalTable: "InvoiceIncome",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GroupMessages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupMes__3213E83FF4260B8C", x => x.id);
                    table.ForeignKey(
                        name: "FK__GroupMess__group__214BF109",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__GroupMess__userI__2057CCD0",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "GroupsUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    isOwner = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupsUs__3213E83F1A74F4EA", x => x.id);
                    table.ForeignKey(
                        name: "FK__GroupsUse__group__1B9317B3",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__GroupsUse__userI__1A9EF37A",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    notificationSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    notificationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSeen = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F1C8EAB56", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__userI__11158940",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationsSubscribers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    notificationSource = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F5BD0CE61", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__userI__15DA3E5D",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userSenderId = table.Column<int>(type: "int", nullable: false),
                    userRecipientId = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PrivateM__3213E83F60C30931", x => x.id);
                    table.ForeignKey(
                        name: "FK__PrivateMe__userR__2704CA5F",
                        column: x => x.userRecipientId,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__PrivateMe__userS__2610A626",
                        column: x => x.userSenderId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialGroupsTickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    specialGroupId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SpecialG__3213E83F03BD1DB8", x => x.id);
                    table.ForeignKey(
                        name: "FK__SpecialGr__speci__382F5661",
                        column: x => x.specialGroupId,
                        principalTable: "SpecialGroups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__SpecialGr__userI__373B3228",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialGroupsUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    specialGroupId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    isOwner = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SpecialG__3213E83F9A09927F", x => x.id);
                    table.ForeignKey(
                        name: "FK__SpecialGr__custo__308E3499",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__SpecialGr__speci__318258D2",
                        column: x => x.specialGroupId,
                        principalTable: "SpecialGroups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__SpecialGr__userI__32767D0B",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskRecipient = table.Column<int>(type: "int", nullable: false),
                    TaskSender = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deadlineTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    lateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    completionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    isMeeting = table.Column<bool>(type: "bit", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__3213E83F81C74467", x => x.id);
                    table.ForeignKey(
                        name: "FK__Tasks__TaskRecip__0A688BB1",
                        column: x => x.TaskRecipient,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tasks__TaskSende__0B5CAFEA",
                        column: x => x.TaskSender,
                        principalTable: "Groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTypes_customerId",
                table: "ContractTypes",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_customerId",
                table: "DebitNote",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_customerId",
                table: "Errors",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_groupId",
                table: "GroupMessages",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_userId",
                table: "GroupMessages",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_customerId",
                table: "Groups",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_groupId",
                table: "GroupsUsers",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUsers_userId",
                table: "GroupsUsers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCost_customerId",
                table: "InvoiceCost",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCost_vatTax",
                table: "InvoiceCost",
                column: "vatTax");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIncome_customerId",
                table: "InvoiceIncome",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIncome_vatTax",
                table: "InvoiceIncome",
                column: "vatTax");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTaxRates_customerId",
                table: "InvoiceTaxRates",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_userId",
                table: "Notifications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsSubscribers_userId",
                table: "NotificationsSubscribers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_contractType",
                table: "Payroll",
                column: "contractType");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_customerId",
                table: "Payroll",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollTaxRates_customerId",
                table: "PayrollTaxRates",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_customerId",
                table: "Positions",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_userRecipientId",
                table: "PrivateMessages",
                column: "userRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_userSenderId",
                table: "PrivateMessages",
                column: "userSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringCostInvoice_customerId",
                table: "ReccuringCostInvoice",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringCostInvoice_invoiceId",
                table: "ReccuringCostInvoice",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringIncomeInvoice_customerId",
                table: "ReccuringIncomeInvoice",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringIncomeInvoice_invoiceId",
                table: "ReccuringIncomeInvoice",
                column: "invoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroups_customerId",
                table: "SpecialGroups",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroupsTickets_specialGroupId",
                table: "SpecialGroupsTickets",
                column: "specialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroupsTickets_userId",
                table: "SpecialGroupsTickets",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroupsUsers_customerId",
                table: "SpecialGroupsUsers",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroupsUsers_specialGroupId",
                table: "SpecialGroupsUsers",
                column: "specialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialGroupsUsers_userId",
                table: "SpecialGroupsUsers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskRecipient",
                table: "Tasks",
                column: "TaskRecipient");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskSender",
                table: "Tasks",
                column: "TaskSender");

            migrationBuilder.CreateIndex(
                name: "IX_Users_customerId",
                table: "Users",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_positionId",
                table: "Users",
                column: "positionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "DebitNote");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "GroupMessages");

            migrationBuilder.DropTable(
                name: "GroupsUsers");

            migrationBuilder.DropTable(
                name: "ImageInput");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationsSubscribers");

            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropTable(
                name: "PayrollTaxRates");

            migrationBuilder.DropTable(
                name: "PrivateMessages");

            migrationBuilder.DropTable(
                name: "ReccuringCostInvoice");

            migrationBuilder.DropTable(
                name: "ReccuringIncomeInvoice");

            migrationBuilder.DropTable(
                name: "SpecialGroupsTickets");

            migrationBuilder.DropTable(
                name: "SpecialGroupsUsers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TextInput");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "InvoiceCost");

            migrationBuilder.DropTable(
                name: "InvoiceIncome");

            migrationBuilder.DropTable(
                name: "SpecialGroups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "InvoiceTaxRates");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
