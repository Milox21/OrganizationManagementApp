using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

[Table("InvoiceCost")]
public partial class InvoiceCost
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("unit")]
    [StringLength(50)]
    public string Unit { get; set; } = null!;

    [Column("quantity", TypeName = "decimal(10, 2)")]
    public decimal Quantity { get; set; }

    [Column("priceNetto", TypeName = "decimal(10, 2)")]
    public decimal PriceNetto { get; set; }

    [Column("valueNetto", TypeName = "decimal(10, 2)")]
    public decimal ValueNetto { get; set; }

    [Column("vatTax")]
    public int? VatTax { get; set; }

    [Column("vatTaxValue", TypeName = "decimal(10, 2)")]
    public decimal? VatTaxValue { get; set; }

    [Column("valueBrutto", TypeName = "decimal(10, 2)")]
    public decimal? ValueBrutto { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("currencyId")]
    public int? CurrencyId { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CurrencyId")]
    [InverseProperty("InvoiceCosts")]
    public virtual Currency? Currency { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("InvoiceCosts")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<ReccuringCostInvoice> ReccuringCostInvoices { get; set; } = new List<ReccuringCostInvoice>();

    [ForeignKey("VatTax")]
    [InverseProperty("InvoiceCosts")]
    public virtual InvoiceTaxRate? VatTaxNavigation { get; set; }
}
