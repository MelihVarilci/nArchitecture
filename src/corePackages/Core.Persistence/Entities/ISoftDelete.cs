namespace Core.Persistence.Entities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}