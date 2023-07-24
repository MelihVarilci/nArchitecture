namespace Core.Persistence.Entities
{
    public interface IPassivable
    {
        public bool IsActive { get; set; }
    }
}