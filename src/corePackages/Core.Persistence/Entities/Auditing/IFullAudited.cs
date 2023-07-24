namespace Core.Persistence.Entities.Auditing
{
    public interface IFullAudited : IAudited, IDeletionAudited
    {
    }
}