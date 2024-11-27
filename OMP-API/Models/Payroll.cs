using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

[Table("Payroll")]
public partial class Payroll
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(255)]
    public string Surname { get; set; } = null!;

    [Column("contractType")]
    public int ContractType { get; set; }

    [Column("ratePerHourBrutto", TypeName = "decimal(10, 2)")]
    public decimal RatePerHourBrutto { get; set; }

    [Column("hours", TypeName = "decimal(10, 2)")]
    public decimal Hours { get; set; }

    [Column("payrollTaxRateIds")]
    [StringLength(255)]
    public string? PayrollTaxRateIds { get; set; }

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

    [ForeignKey("ContractType")]
    [InverseProperty("Payrolls")]
    public virtual ContractType ContractTypeNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("Payrolls")]
    public virtual Currency? Currency { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Payrolls")]
    public virtual Customer Customer { get; set; } = null!;
}
