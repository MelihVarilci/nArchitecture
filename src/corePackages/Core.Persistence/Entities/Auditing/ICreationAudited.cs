namespace Core.Persistence.Entities.Auditing
{
    public interface ICreationAudited : IHasCreationTime
    {
        public long? CreatorUserId { get; set; }
    }
}