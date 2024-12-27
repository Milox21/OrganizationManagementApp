namespace ClassLibrary.Models.ModelInterfaces
{
    public interface IBaseModel
    {
        public int Id { get; set; }
        bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
