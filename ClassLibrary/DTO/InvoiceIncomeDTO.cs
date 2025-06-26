using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class InvoiceIncomeDTO : IBaseModel
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; } = null!;
        [JsonPropertyName("unit")] public string Unit { get; set; } = null!;
        [JsonPropertyName("quantity")] public decimal Quantity { get; set; }
        [JsonPropertyName("priceNetto")] public decimal PriceNetto { get; set; }
        [JsonPropertyName("vatTaxId")] public decimal? VatTax { get; set; }
        [JsonPropertyName("currencyId")] public int? CurrencyId { get; set; }
        [JsonPropertyName("valueNetto")] public decimal? ValueNetto { get; set; }
        [JsonPropertyName("valueBrutto")] public decimal? ValueBrutto { get; set; }
        [JsonPropertyName("customerId")] public int CustomerId { get; set; }
        [JsonPropertyName("creationDate")] public DateTime CreationDate { get; set; }
        [JsonPropertyName("editDate")] public DateTime? EditDate { get; set; }
        [JsonPropertyName("deleteDate")] public DateTime? DeleteDate { get; set; }
        [JsonPropertyName("isDeleted")] public bool IsDeleted { get; set; }
    }
}
