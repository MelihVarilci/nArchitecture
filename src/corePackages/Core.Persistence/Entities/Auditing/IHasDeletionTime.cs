namespace Core.Persistence.Entities.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        public DateTime? DeletionTime { get; set; }
    }
}