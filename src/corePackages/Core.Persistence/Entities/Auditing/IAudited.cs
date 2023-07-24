namespace Core.Persistence.Entities.Auditing
{
    public interface IAudited : ICreationAudited, IModificationAudited
    {
    }
}