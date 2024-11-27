using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

public partial class Customer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<ContractType> ContractTypes { get; set; } = new List<ContractType>();

    [InverseProperty("Customer")]
    public virtual ICollection<DebitNote> DebitNotes { get; set; } = new List<DebitNote>();

    [InverseProperty("Customer")]
    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    [InverseProperty("Customer")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    [InverseProperty("Customer")]
    public virtual ICollection<InvoiceCost> InvoiceCosts { get; set; } = new List<InvoiceCost>();

    [InverseProperty("Customer")]
    public virtual ICollection<InvoiceIncome> InvoiceIncomes { get; set; } = new List<InvoiceIncome>();

    [InverseProperty("Customer")]
    public virtual ICollection<InvoiceTaxRate> InvoiceTaxRates { get; set; } = new List<InvoiceTaxRate>();

    [InverseProperty("Customer")]
    public virtual ICollection<PayrollTaxRate> PayrollTaxRates { get; set; } = new List<PayrollTaxRate>();

    [InverseProperty("Customer")]
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    [InverseProperty("Customer")]
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    [InverseProperty("Customer")]
    public virtual ICollection<ReccuringCostInvoice> ReccuringCostInvoices { get; set; } = new List<ReccuringCostInvoice>();

    [InverseProperty("Customer")]
    public virtual ICollection<ReccuringIncomeInvoice> ReccuringIncomeInvoices { get; set; } = new List<ReccuringIncomeInvoice>();

    [InverseProperty("Customer")]
    public virtual ICollection<SpecialGroup> SpecialGroups { get; set; } = new List<SpecialGroup>();

    [InverseProperty("Customer")]
    public virtual ICollection<SpecialGroupsUser> SpecialGroupsUsers { get; set; } = new List<SpecialGroupsUser>();

    [InverseProperty("Customer")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
