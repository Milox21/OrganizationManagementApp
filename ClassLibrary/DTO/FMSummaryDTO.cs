using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary.DTO
{
    public class FMSummaryDTO
    {
        [JsonPropertyName("DatabaseId")]  public int? DatabaseId { get; set; }

        [JsonPropertyName("Type")]  public string? Type { get; set; } // Cost, Income, Payroll

        [JsonPropertyName("Title")]  public string? Title { get; set; } // Name + Surname (Contract Type) or Title of invoice with (Cost) or (Income)
        [JsonPropertyName("Occurance")]  public int? Occurance { get; set; } // How many times payroll or occuring invoice will take place

        [JsonPropertyName("CurrencyId")] public int? CurrencyId { get; set; } // How many times payroll or occuring invoice will take place

        [JsonPropertyName("Brutto")]  public decimal? Brutto { get; set; }
        [JsonPropertyName("Netto")]  public decimal? Netto { get; set; }
        [JsonPropertyName("Tax")]  public decimal? Tax { get; set; } //Percentage of tax 
        [JsonPropertyName("TaxValue")]  public decimal? TaxValue { get; set; } // Value of that tax

        [JsonPropertyName("CreationDate")]  public DateTime? CreationDate { get; set; }
    }
}
