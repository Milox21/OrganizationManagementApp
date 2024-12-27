using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class InvoiceTaxRate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("type")]
    [StringLength(50)]
    public string Type { get; set; } = null!;

    [Column("rate", TypeName = "decimal(10, 4)")]
    public decimal Rate { get; set; }

    [Column("country")]
    [StringLength(100)]
    public string Country { get; set; } = null!;

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("InvoiceTaxRates")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("VatTaxNavigation")]
    public virtual ICollection<InvoiceCost> InvoiceCosts { get; set; } = new List<InvoiceCost>();

    [InverseProperty("VatTaxNavigation")]
    public virtual ICollection<InvoiceIncome> InvoiceIncomes { get; set; } = new List<InvoiceIncome>();
}
