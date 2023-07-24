namespace Core.Persistence.Entities.Auditing
{
    public interface IModificationAudited : IHasModificationTime
    {
        public long? LastModifierUserId { get; set; }
    }
}