using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ClassLibrary.DTO;
using QuestPDF.Helpers;
using OMP_API.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        public readonly DatabaseContext _context;

        public PDFController()
        {
            _context = new();
            QuestPDF.Settings.License = LicenseType.Community;
        }

        [HttpPost("download")]
        public IActionResult DownloadPdf([FromBody] FMSummaryReportRequestDTO request)
        {
            var customer = _context.Customers.FirstOrDefault(e => e.Id == request.CustomerId && e.IsDeleted == false);
            var currencyMap = _context.Currencies
                .Where(c => request.Items.Select(i => i.CurrencyId).Distinct().Contains(c.Id))
                .ToDictionary(c => c.Id, c => c.Code);


            SummaryDocument document = new SummaryDocument(request, customer.Name, currencyMap);
            var pdf = document.GeneratePdf();
            return File(pdf, "application/pdf", "summary-report.pdf");
        }

        public class SummaryDocument : IDocument
        {
            private readonly FMSummaryReportRequestDTO _request;
            private readonly string _customerName;
            private readonly Dictionary<int, string> _currencyMap;

            public SummaryDocument(FMSummaryReportRequestDTO request, string customerName, Dictionary<int, string> currencyMap)
            {
                _request = request;
                _customerName = customerName;
                _currencyMap = currencyMap;
            }

            public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

            public void Compose(IDocumentContainer container)
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    // Header
                    page.Header().Column(column =>
                    {
                        column.Item().Text("Summary Report").FontSize(20).Bold();
                        column.Item().Text($"Customer: {_customerName ?? "Unknown"}");
                        column.Item().Text($"Date Range: {_request.StartDate:yyyy-MM-dd} to {_request.EndDate:yyyy-MM-dd}");
                        column.Item().PaddingBottom(10);
                    });

                    // Content
                    page.Content().PaddingVertical(10).Element(BuildTable);

                    // Footer
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Generated ");
                        text.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm")).SemiBold();
                    });
                });
            }
            private void BuildTable(IContainer container)
            {
                container.Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3); // Title
                        columns.RelativeColumn(2); // Type
                        columns.RelativeColumn(2); // Occurrence
                        columns.RelativeColumn(2); // Brutto
                        columns.RelativeColumn(2); // Netto
                        columns.RelativeColumn(2); // Tax
                        columns.RelativeColumn(2); // Tax Value
                        columns.RelativeColumn(1); // Currency
                        columns.RelativeColumn(2); // Date
                    });

                    // Header row
                    table.Header(header =>
                    {
                        string[] headers = {
                "Title", "Type", "Instances", "Brutto", "Netto", "Tax", "Value of Tax", "$", "Date of Creation"
            };

                        foreach (var h in headers)
                        {
                            header.Cell().Element(CellHeaderStyle).Text(h).FontSize(9).Bold().FontColor(Colors.White);
                        }

                        IContainer CellHeaderStyle(IContainer container) => container
                            .Background(Colors.Blue.Darken2) // More blue header
                            .PaddingVertical(5)
                            .PaddingHorizontal(6)
                            .AlignCenter()
                            .BorderBottom(1)
                            .BorderColor(Colors.Blue.Darken3);
                    });

                    // Body rows
                    foreach (var item in _request.Items)
                    {
                        table.Cell().Element(CellBody).Text(text => text.Span(item.Title).FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span(item.Type).FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span($"{item.Occurance:0.00}").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span($"{item.Brutto:0.00}").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span($"{item.Netto:0.00}").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span($"{item.Tax:0.##}%").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span($"{item.TaxValue:0.00}").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span(
                            _currencyMap.TryGetValue((int)item.CurrencyId, out var code) ? code : "N/A").FontSize(8.5f));
                        table.Cell().Element(CellBody).Text(text => text.Span(
                            item.CreationDate?.ToString("yyyy-MM-dd") ?? "N/A").FontSize(8.5f));
                    }

                    IContainer CellBody(IContainer container) => container
                        .BorderBottom(0.5f)
                        .BorderColor(Colors.Grey.Lighten2)
                        .PaddingVertical(4)
                        .PaddingHorizontal(6)
                        .AlignLeft()
                        .MinHeight(14); // Ensures even spacing for better clarity
                });
            }

        }
    }
}


