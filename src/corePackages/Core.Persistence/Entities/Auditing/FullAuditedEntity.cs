namespace Core.Persistence.Entities.Auditing
{
    public abstract class FullAuditedEntity : FullAuditedEntity<int>, IEntity
    {
    }

    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IFullAudited
    {
        public virtual bool IsDeleted { get; set; }

        public virtual long? DeleterUserId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }
}