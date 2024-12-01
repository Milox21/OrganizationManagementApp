using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class ContractTypeDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal BaseRatePerHourBrutto { get; set; }
        public string Country { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public CustomerDTO Customer { get; set; } = null!;

    }
}
