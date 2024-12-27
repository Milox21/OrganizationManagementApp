using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class Currency
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("exchangeRateToDollar", TypeName = "decimal(10, 4)")]
    public decimal ExchangeRateToDollar { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [InverseProperty("CurrencyNavigation")]
    public virtual ICollection<DebitNote> DebitNotes { get; set; } = new List<DebitNote>();

    [InverseProperty("Currency")]
    public virtual ICollection<InvoiceCost> InvoiceCosts { get; set; } = new List<InvoiceCost>();

    [InverseProperty("Currency")]
    public virtual ICollection<InvoiceIncome> InvoiceIncomes { get; set; } = new List<InvoiceIncome>();

    [InverseProperty("Currency")]
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
}
