using ClassLibrary.DTO;
using ClassLibrary.Models.ModelInterfaces;
using System.Text.Json.Serialization;

public class PayrollDTO : IBaseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("surname")]
    public string Surname { get; set; } = null!;

    [JsonPropertyName("contractType")]
    public int ContractType { get; set; }

    [JsonPropertyName("ratePerHourBrutto")]
    public decimal RatePerHourBrutto { get; set; }

    [JsonPropertyName("hours")]
    public decimal Hours { get; set; }

    [JsonPropertyName("payrollTaxRateIds")]
    public string? PayrollTaxRateIds { get; set; }

    [JsonPropertyName("taxrate")]
    public decimal TaxRate { get; set; }

    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("currencyId")]
    public int? CurrencyId { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("editDate")]
    public DateTime? EditDate { get; set; }

    [JsonPropertyName("deleteDate")]
    public DateTime? DeleteDate { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("contractTypeNavigation")]
    public virtual ContractTypeDTO? ContractTypeNavigation { get; set; }

    [JsonPropertyName("currency")]
    public virtual CurrencyDTO? Currency { get; set; }

 
}
