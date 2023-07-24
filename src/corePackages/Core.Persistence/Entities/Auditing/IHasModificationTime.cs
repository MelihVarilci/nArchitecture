namespace Core.Persistence.Entities.Auditing
{
    public interface IHasModificationTime
    {
        public DateTime? LastModificationTime { get; set; }
    }
}