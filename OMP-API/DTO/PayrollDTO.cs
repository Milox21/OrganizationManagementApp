using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class PayrollDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int ContractType { get; set; }
        public decimal RatePerHourBrutto { get; set; }
        public decimal Hours { get; set; }
        public string? PayrollTaxRateIds { get; set; }
        public int CustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ContractTypeDTO ContractTypeNavigation { get; set; } = null!;
        public virtual CurrencyDTO? Currency { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
    }
}
}
