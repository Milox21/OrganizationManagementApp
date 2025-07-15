using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary.DTO
{
    public class FMSummaryReportRequestDTO
    {
        [JsonPropertyName("CustomerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("Items")]
        public List<FMSummaryDTO> Items { get; set; } = new();
    }
}
