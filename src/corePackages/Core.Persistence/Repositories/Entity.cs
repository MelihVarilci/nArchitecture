namespace Core.Persistence.Repositories;

public class Entity : IEntity
{
    public int Id { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}