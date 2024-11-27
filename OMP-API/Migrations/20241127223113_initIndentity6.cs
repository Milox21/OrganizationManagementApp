using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMP_API.Migrations
{
    /// <inheritdoc />
    public partial class initIndentity6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ContractT__custo__4A4E069C",
                table: "ContractTypes");

            migrationBuilder.DropForeignKey(
                name: "FK__DebitNote__custo__603D47BB",
                table: "DebitNote");

            migrationBuilder.DropForeignKey(
                name: "FK__Errors__customer__6EC0713C",
                table: "Errors");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupMess__group__214BF109",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupMess__userI__2057CCD0",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__Groups__customer__05A3D694",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupsUse__group__1B9317B3",
                table: "GroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupsUse__userI__1A9EF37A",
                table: "GroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceCo__custo__4F12BBB9",
                table: "InvoiceCost");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceCo__vatTa__5006DFF2",
                table: "InvoiceCost");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceIn__custo__54CB950F",
                table: "InvoiceIncome");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceIn__vatTa__55BFB948",
                table: "InvoiceIncome");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceTa__custo__40C49C62",
                table: "InvoiceTaxRates");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__userI__11158940",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__userI__15DA3E5D",
                table: "NotificationsSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK__Payroll__contrac__5B78929E",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK__Payroll__custome__5A846E65",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK__PayrollTa__custo__4589517F",
                table: "PayrollTaxRates");

            migrationBuilder.DropForeignKey(
                name: "FK__Positions__custo__7B264821",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK__PrivateMe__userR__2704CA5F",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__PrivateMe__userS__2610A626",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__custo__6501FCD8",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__invoi__65F62111",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__custo__6ABAD62E",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__invoi__6BAEFA67",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__custo__2BC97F7C",
                table: "SpecialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__speci__382F5661",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__userI__373B3228",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__custo__308E3499",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__speci__318258D2",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__userI__32767D0B",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__TaskRecip__0A688BB1",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__TaskSende__0B5CAFEA",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__customerI__7FEAFD3E",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__positionI__00DF2177",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__3213E83FD3C01ED7",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__TextInpu__3213E83F91C0D28B",
                table: "TextInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tasks__3213E83F81C74467",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83F9A09927F",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83F03BD1DB8",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83FF1856CEF",
                table: "SpecialGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reccurin__3213E83FA29DD903",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ReccuringIncomeInvoice_customerId",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reccurin__3213E83F4D6AC24D",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ReccuringCostInvoice_customerId",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PrivateM__3213E83F60C30931",
                table: "PrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Position__3213E83FFD67D6A3",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PayrollT__3213E83F578F27D2",
                table: "PayrollTaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Payroll__3213E83F7EDFC64D",
                table: "Payroll");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__3213E83F5BD0CE61",
                table: "NotificationsSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__3213E83F1C8EAB56",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceT__3213E83FF2C8D260",
                table: "InvoiceTaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceI__3213E83F6F4DA711",
                table: "InvoiceIncome");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceC__3213E83F4730B068",
                table: "InvoiceCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ImageInp__3213E83F11FB439D",
                table: "ImageInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GroupsUs__3213E83F1A74F4EA",
                table: "GroupsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Groups__3213E83FD3834658",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GroupMes__3213E83FF4260B8C",
                table: "GroupMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Errors__3213E83F74876A49",
                table: "Errors");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DebitNot__3213E83F09677558",
                table: "DebitNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Customer__3213E83FBA8D94FA",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Currenci__3213E83F918EF608",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Country__3213E83F881D31EE",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Contract__3213E83F5815878A",
                table: "ContractTypes");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "ReccuringCostInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currencyId",
                table: "Payroll",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currencyId",
                table: "InvoiceIncome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currencyId",
                table: "InvoiceCost",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currencyId",
                table: "DebitNote",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__3213E83F4499240F",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TextInpu__3213E83F13DC09AD",
                table: "TextInput",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tasks__3213E83F964422DE",
                table: "Tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83F7696AC27",
                table: "SpecialGroupsUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83F6FF0DB49",
                table: "SpecialGroupsTickets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83F54E2EB48",
                table: "SpecialGroups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reccurin__3213E83F89099AD5",
                table: "ReccuringIncomeInvoice",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reccurin__3213E83FF40254C6",
                table: "ReccuringCostInvoice",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PrivateM__3213E83F3BE648B5",
                table: "PrivateMessages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Position__3213E83F16476757",
                table: "Positions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PayrollT__3213E83FDB6ED523",
                table: "PayrollTaxRates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Payroll__3213E83FCDBD170F",
                table: "Payroll",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__3213E83F329ED79A",
                table: "NotificationsSubscribers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__3213E83F27B0DAA5",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceT__3213E83F287EAB76",
                table: "InvoiceTaxRates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceI__3213E83FDCD6D769",
                table: "InvoiceIncome",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceC__3213E83F310AB2C4",
                table: "InvoiceCost",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ImageInp__3213E83F78F8C9D2",
                table: "ImageInput",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GroupsUs__3213E83FF1D1464B",
                table: "GroupsUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Groups__3213E83F53CA99A1",
                table: "Groups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GroupMes__3213E83FDCCEBE82",
                table: "GroupMessages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Errors__3213E83F89403E77",
                table: "Errors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DebitNot__3213E83FA5ACCDF3",
                table: "DebitNote",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Customer__3213E83F35E24FBE",
                table: "Customers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Currenci__3213E83FD1F38041",
                table: "Currencies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Country__3213E83FAFE6F665",
                table: "Country",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Contract__3213E83F3C20CDCF",
                table: "ContractTypes",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_countryId",
                table: "Users",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_currencyId",
                table: "Payroll",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceIncome_currencyId",
                table: "InvoiceIncome",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCost_currencyId",
                table: "InvoiceCost",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNote_currencyId",
                table: "DebitNote",
                column: "currencyId");

            migrationBuilder.AddForeignKey(
                name: "FK__ContractT__custo__0E240DFC",
                table: "ContractTypes",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__DebitNote__curre__2AC04CAA",
                table: "DebitNote",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__DebitNote__custo__2BB470E3",
                table: "DebitNote",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Errors__customer__31A25463",
                table: "Errors",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupMess__group__68F2894D",
                table: "GroupMessages",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupMess__userI__67FE6514",
                table: "GroupMessages",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Groups__customer__4D4A6ED8",
                table: "Groups",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupsUse__group__6339AFF7",
                table: "GroupsUsers",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupsUse__userI__62458BBE",
                table: "GroupsUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceCo__curre__17AD7836",
                table: "InvoiceCost",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceCo__custo__16B953FD",
                table: "InvoiceCost",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceCo__vatTa__18A19C6F",
                table: "InvoiceCost",
                column: "vatTax",
                principalTable: "InvoiceTaxRates",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceIn__curre__1E5A75C5",
                table: "InvoiceIncome",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceIn__custo__1D66518C",
                table: "InvoiceIncome",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceIn__vatTa__1F4E99FE",
                table: "InvoiceIncome",
                column: "vatTax",
                principalTable: "InvoiceTaxRates",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceTa__custo__049AA3C2",
                table: "InvoiceTaxRates",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__userI__58BC2184",
                table: "Notifications",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__userI__5D80D6A1",
                table: "NotificationsSubscribers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payroll__contrac__25FB978D",
                table: "Payroll",
                column: "contractType",
                principalTable: "ContractTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payroll__currenc__25077354",
                table: "Payroll",
                column: "currencyId",
                principalTable: "Currencies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payroll__custome__24134F1B",
                table: "Payroll",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PayrollTa__custo__095F58DF",
                table: "PayrollTaxRates",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Positions__custo__3E082B48",
                table: "Positions",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PrivateMe__userR__6EAB62A3",
                table: "PrivateMessages",
                column: "userRecipientId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PrivateMe__userS__6DB73E6A",
                table: "PrivateMessages",
                column: "userSenderId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__invoi__30792600",
                table: "ReccuringCostInvoice",
                column: "invoiceId",
                principalTable: "InvoiceCost",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__invoi__353DDB1D",
                table: "ReccuringIncomeInvoice",
                column: "invoiceId",
                principalTable: "InvoiceIncome",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__custo__737017C0",
                table: "SpecialGroups",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__speci__7FD5EEA5",
                table: "SpecialGroupsTickets",
                column: "specialGroupId",
                principalTable: "SpecialGroups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__userI__7EE1CA6C",
                table: "SpecialGroupsTickets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__custo__7834CCDD",
                table: "SpecialGroupsUsers",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__speci__7928F116",
                table: "SpecialGroupsUsers",
                column: "specialGroupId",
                principalTable: "SpecialGroups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__userI__7A1D154F",
                table: "SpecialGroupsUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__TaskRecip__520F23F5",
                table: "Tasks",
                column: "TaskRecipient",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__TaskSende__5303482E",
                table: "Tasks",
                column: "TaskSender",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__countryId__47919582",
                table: "Users",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__customerI__469D7149",
                table: "Users",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__positionI__4885B9BB",
                table: "Users",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ContractT__custo__0E240DFC",
                table: "ContractTypes");

            migrationBuilder.DropForeignKey(
                name: "FK__DebitNote__curre__2AC04CAA",
                table: "DebitNote");

            migrationBuilder.DropForeignKey(
                name: "FK__DebitNote__custo__2BB470E3",
                table: "DebitNote");

            migrationBuilder.DropForeignKey(
                name: "FK__Errors__customer__31A25463",
                table: "Errors");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupMess__group__68F2894D",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupMess__userI__67FE6514",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__Groups__customer__4D4A6ED8",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupsUse__group__6339AFF7",
                table: "GroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupsUse__userI__62458BBE",
                table: "GroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceCo__curre__17AD7836",
                table: "InvoiceCost");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceCo__custo__16B953FD",
                table: "InvoiceCost");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceCo__vatTa__18A19C6F",
                table: "InvoiceCost");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceIn__curre__1E5A75C5",
                table: "InvoiceIncome");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceIn__custo__1D66518C",
                table: "InvoiceIncome");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceIn__vatTa__1F4E99FE",
                table: "InvoiceIncome");

            migrationBuilder.DropForeignKey(
                name: "FK__InvoiceTa__custo__049AA3C2",
                table: "InvoiceTaxRates");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__userI__58BC2184",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK__Notificat__userI__5D80D6A1",
                table: "NotificationsSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK__Payroll__contrac__25FB978D",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK__Payroll__currenc__25077354",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK__Payroll__custome__24134F1B",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK__PayrollTa__custo__095F58DF",
                table: "PayrollTaxRates");

            migrationBuilder.DropForeignKey(
                name: "FK__Positions__custo__3E082B48",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK__PrivateMe__userR__6EAB62A3",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__PrivateMe__userS__6DB73E6A",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__invoi__30792600",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__Reccuring__invoi__353DDB1D",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__custo__737017C0",
                table: "SpecialGroups");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__speci__7FD5EEA5",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__userI__7EE1CA6C",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__custo__7834CCDD",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__speci__7928F116",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__SpecialGr__userI__7A1D154F",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__TaskRecip__520F23F5",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__Tasks__TaskSende__5303482E",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__countryId__47919582",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__customerI__469D7149",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK__Users__positionI__4885B9BB",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__3213E83F4499240F",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_countryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__TextInpu__3213E83F13DC09AD",
                table: "TextInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tasks__3213E83F964422DE",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83F7696AC27",
                table: "SpecialGroupsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83F6FF0DB49",
                table: "SpecialGroupsTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SpecialG__3213E83F54E2EB48",
                table: "SpecialGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reccurin__3213E83F89099AD5",
                table: "ReccuringIncomeInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reccurin__3213E83FF40254C6",
                table: "ReccuringCostInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PrivateM__3213E83F3BE648B5",
                table: "PrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Position__3213E83F16476757",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PayrollT__3213E83FDB6ED523",
                table: "PayrollTaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Payroll__3213E83FCDBD170F",
                table: "Payroll");

            migrationBuilder.DropIndex(
                name: "IX_Payroll_currencyId",
                table: "Payroll");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__3213E83F329ED79A",
                table: "NotificationsSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Notifica__3213E83F27B0DAA5",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceT__3213E83F287EAB76",
                table: "InvoiceTaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceI__3213E83FDCD6D769",
                table: "InvoiceIncome");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceIncome_currencyId",
                table: "InvoiceIncome");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InvoiceC__3213E83F310AB2C4",
                table: "InvoiceCost");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceCost_currencyId",
                table: "InvoiceCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ImageInp__3213E83F78F8C9D2",
                table: "ImageInput");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GroupsUs__3213E83FF1D1464B",
                table: "GroupsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Groups__3213E83F53CA99A1",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK__GroupMes__3213E83FDCCEBE82",
                table: "GroupMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Errors__3213E83F89403E77",
                table: "Errors");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DebitNot__3213E83FA5ACCDF3",
                table: "DebitNote");

            migrationBuilder.DropIndex(
                name: "IX_DebitNote_currencyId",
                table: "DebitNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Customer__3213E83F35E24FBE",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Currenci__3213E83FD1F38041",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Country__3213E83FAFE6F665",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Contract__3213E83F3C20CDCF",
                table: "ContractTypes");

            migrationBuilder.DropColumn(
                name: "countryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "Payroll");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "InvoiceIncome");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "InvoiceCost");

            migrationBuilder.DropColumn(
                name: "currencyId",
                table: "DebitNote");

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "ReccuringIncomeInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "ReccuringCostInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__3213E83FD3C01ED7",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TextInpu__3213E83F91C0D28B",
                table: "TextInput",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tasks__3213E83F81C74467",
                table: "Tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83F9A09927F",
                table: "SpecialGroupsUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83F03BD1DB8",
                table: "SpecialGroupsTickets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SpecialG__3213E83FF1856CEF",
                table: "SpecialGroups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reccurin__3213E83FA29DD903",
                table: "ReccuringIncomeInvoice",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reccurin__3213E83F4D6AC24D",
                table: "ReccuringCostInvoice",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PrivateM__3213E83F60C30931",
                table: "PrivateMessages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Position__3213E83FFD67D6A3",
                table: "Positions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PayrollT__3213E83F578F27D2",
                table: "PayrollTaxRates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Payroll__3213E83F7EDFC64D",
                table: "Payroll",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__3213E83F5BD0CE61",
                table: "NotificationsSubscribers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Notifica__3213E83F1C8EAB56",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceT__3213E83FF2C8D260",
                table: "InvoiceTaxRates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceI__3213E83F6F4DA711",
                table: "InvoiceIncome",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InvoiceC__3213E83F4730B068",
                table: "InvoiceCost",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ImageInp__3213E83F11FB439D",
                table: "ImageInput",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GroupsUs__3213E83F1A74F4EA",
                table: "GroupsUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Groups__3213E83FD3834658",
                table: "Groups",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__GroupMes__3213E83FF4260B8C",
                table: "GroupMessages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Errors__3213E83F74876A49",
                table: "Errors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DebitNot__3213E83F09677558",
                table: "DebitNote",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Customer__3213E83FBA8D94FA",
                table: "Customers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Currenci__3213E83F918EF608",
                table: "Currencies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Country__3213E83F881D31EE",
                table: "Country",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Contract__3213E83F5815878A",
                table: "ContractTypes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    deleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    editDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__3213E83FFADA5D77", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringIncomeInvoice_customerId",
                table: "ReccuringIncomeInvoice",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReccuringCostInvoice_customerId",
                table: "ReccuringCostInvoice",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK__ContractT__custo__4A4E069C",
                table: "ContractTypes",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__DebitNote__custo__603D47BB",
                table: "DebitNote",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Errors__customer__6EC0713C",
                table: "Errors",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupMess__group__214BF109",
                table: "GroupMessages",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupMess__userI__2057CCD0",
                table: "GroupMessages",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Groups__customer__05A3D694",
                table: "Groups",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupsUse__group__1B9317B3",
                table: "GroupsUsers",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupsUse__userI__1A9EF37A",
                table: "GroupsUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceCo__custo__4F12BBB9",
                table: "InvoiceCost",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceCo__vatTa__5006DFF2",
                table: "InvoiceCost",
                column: "vatTax",
                principalTable: "InvoiceTaxRates",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceIn__custo__54CB950F",
                table: "InvoiceIncome",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceIn__vatTa__55BFB948",
                table: "InvoiceIncome",
                column: "vatTax",
                principalTable: "InvoiceTaxRates",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__InvoiceTa__custo__40C49C62",
                table: "InvoiceTaxRates",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__userI__11158940",
                table: "Notifications",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Notificat__userI__15DA3E5D",
                table: "NotificationsSubscribers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payroll__contrac__5B78929E",
                table: "Payroll",
                column: "contractType",
                principalTable: "ContractTypes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payroll__custome__5A846E65",
                table: "Payroll",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PayrollTa__custo__4589517F",
                table: "PayrollTaxRates",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Positions__custo__7B264821",
                table: "Positions",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PrivateMe__userR__2704CA5F",
                table: "PrivateMessages",
                column: "userRecipientId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__PrivateMe__userS__2610A626",
                table: "PrivateMessages",
                column: "userSenderId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__custo__6501FCD8",
                table: "ReccuringCostInvoice",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__invoi__65F62111",
                table: "ReccuringCostInvoice",
                column: "invoiceId",
                principalTable: "InvoiceCost",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__custo__6ABAD62E",
                table: "ReccuringIncomeInvoice",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Reccuring__invoi__6BAEFA67",
                table: "ReccuringIncomeInvoice",
                column: "invoiceId",
                principalTable: "InvoiceIncome",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__custo__2BC97F7C",
                table: "SpecialGroups",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__speci__382F5661",
                table: "SpecialGroupsTickets",
                column: "specialGroupId",
                principalTable: "SpecialGroups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__userI__373B3228",
                table: "SpecialGroupsTickets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__custo__308E3499",
                table: "SpecialGroupsUsers",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__speci__318258D2",
                table: "SpecialGroupsUsers",
                column: "specialGroupId",
                principalTable: "SpecialGroups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__SpecialGr__userI__32767D0B",
                table: "SpecialGroupsUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__TaskRecip__0A688BB1",
                table: "Tasks",
                column: "TaskRecipient",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Tasks__TaskSende__0B5CAFEA",
                table: "Tasks",
                column: "TaskSender",
                principalTable: "Groups",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__customerI__7FEAFD3E",
                table: "Users",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Users__positionI__00DF2177",
                table: "Users",
                column: "positionId",
                principalTable: "Positions",
                principalColumn: "id");
        }
    }
}
