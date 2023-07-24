namespace Core.Persistence.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}