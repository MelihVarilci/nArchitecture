namespace Core.Persistence.Entities.Auditing
{
    public abstract class AuditedEntity : AuditedEntity<int>, IEntity
    {
    }

    public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
    {
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
    }
}