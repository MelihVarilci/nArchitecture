namespace Core.Persistence.Entities.Auditing
{
    public interface IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
    }
}