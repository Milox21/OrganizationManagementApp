// ------------------------------
// ✅ 1. API Controller (PrintoutController.cs)
// ------------------------------
using Microsoft.AspNetCore.Mvc;
using Xceed.Words.NET;
using ClassLibrary.DTO;
using Xceed.Document.NET;
using Xceed.Drawing;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintoutController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public PrintoutController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload-template")]
        public async Task<IActionResult> UploadTemplate(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (!Request.Headers.TryGetValue("CustomerId", out var customerIdHeader))
                return BadRequest("CustomerId header is missing.");

            if (!int.TryParse(customerIdHeader, out var customerId))
                return BadRequest("Invalid CustomerId.");

            var folder = Path.Combine(_env.ContentRootPath, "Templates");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, $"FMSummaryTemplate-{customerId}.docx");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("Template uploaded successfully.");
        }

        [HttpPost("generate-summary")]
        public IActionResult GenerateSummaryReport(FMSummaryReportRequestDTO dto)
        {
            var folder = Path.Combine(_env.ContentRootPath, "Templates");
            var templatePath = Path.Combine(folder, $"FMSummaryTemplate-{dto.CustomerId}.docx");

            if (!System.IO.File.Exists(templatePath))
            {
                templatePath = Path.Combine(folder, "FMSummaryTemplate-default.docx");
                if (!System.IO.File.Exists(templatePath))
                    return NotFound("No template found.");
            }

            using var templateStream = new MemoryStream(System.IO.File.ReadAllBytes(templatePath));
            using var doc = DocX.Load(templateStream);

            // Replace simple placeholders
            doc.ReplaceText("{StartDate}", dto.StartDate.ToString("yyyy-MM-dd"));
            doc.ReplaceText("{EndDate}", dto.EndDate.ToString("yyyy-MM-dd"));
            doc.ReplaceText("{TotalIncome}", dto.Items.Where(i => i.Type == "Income").Sum(i => i.Brutto ?? 0).ToString("N2"));
            doc.ReplaceText("{TotalCost}", dto.Items.Where(i => i.Type == "Cost").Sum(i => i.Brutto ?? 0).ToString("N2"));
            doc.ReplaceText("{NetBalance}", dto.Items.Sum(i => i.Brutto ?? 0).ToString("N2"));

            // Find and replace {table} with actual table
            var tablePlaceholder = doc.Paragraphs.FirstOrDefault(p => p.Text.Contains("{table}"));
            if (tablePlaceholder != null)
            {
                int index = doc.Paragraphs.IndexOf(tablePlaceholder);
                string before = tablePlaceholder.Text.Split("{table}")[0];
                string after = tablePlaceholder.Text.Split("{table}").Length > 1 ? tablePlaceholder.Text.Split("{table}")[1] : "";

                doc.RemoveParagraph(tablePlaceholder);

                if (!string.IsNullOrWhiteSpace(before))
                    doc.InsertParagraph(before, false);

                var t = doc.AddTable(dto.Items.Count + 1, 6);
                t.AutoFit = AutoFit.Window;

                // Header style
                Color headerBg = Color.MidnightBlue;

                string[] headers = { "Title", "Type", "Brutto", "Netto", "Tax", "Date" };
                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = t.Rows[0].Cells[col];
                    cell.FillColor = headerBg;
                    cell.Paragraphs[0].Append(headers[col]).FontSize(10).Bold().Color(Xceed.Drawing.Color.White).Alignment = Alignment.center;
                }

                for (int i = 0; i < dto.Items.Count; i++)
                {
                    var item = dto.Items[i];
                    t.Rows[i + 1].Cells[0].Paragraphs[0].Append(item.Title ?? "").FontSize(10);
                    t.Rows[i + 1].Cells[1].Paragraphs[0].Append(item.Type ?? "").FontSize(10);
                    t.Rows[i + 1].Cells[2].Paragraphs[0].Append($"{item.Brutto:N2}").FontSize(10);
                    t.Rows[i + 1].Cells[3].Paragraphs[0].Append($"{item.Netto:N2}").FontSize(10);
                    t.Rows[i + 1].Cells[4].Paragraphs[0].Append($"{item.Tax:P1}").FontSize(10);
                    t.Rows[i + 1].Cells[5].Paragraphs[0].Append(item.CreationDate?.ToString("yyyy-MM-dd") ?? "").FontSize(10);
                }

                doc.InsertTable(index, t);

                if (!string.IsNullOrWhiteSpace(after))
                    doc.InsertParagraph(after, false);
            }

            using var outputStream = new MemoryStream();
            doc.SaveAs(outputStream);
            outputStream.Seek(0, SeekOrigin.Begin);

            var fileName = $"FMSummary-{DateTime.Now:yyyyMMddHHmm}.docx";
            return File(outputStream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                        fileName);
        }
    }
}
