using Microsoft.AspNetCore.Mvc;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    public class PDFController : Controller
    {
        //[HttpGet("download")]
        //public IActionResult DownloadPdf()
        //{
        //    var document = new SampleDocument();
        //    var pdf = document.GeneratePdf();
        //    return File(pdf, "application/pdf", "report.pdf");
        //}

        //public class SampleDocument : IDocument
        //{
        //    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        //    public void Compose(IDocumentContainer container)
        //    {
        //        container.Page(page =>
        //        {
        //            page.Margin(50);
        //            page.Content().Column(c =>
        //            {
        //                c.Item().Text("Hello from QuestPDF");
        //                c.Item().Text($"Generated: {DateTime.Now}");
        //            });
        //        });
        //    }
        //}
    }
}

