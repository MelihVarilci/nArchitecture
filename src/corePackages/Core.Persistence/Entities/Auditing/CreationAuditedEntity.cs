namespace Core.Persistence.Entities.Auditing
{
    public abstract class CreationAuditedEntity : CreationAuditedEntity<int>, IEntity
    {
    }

    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        public virtual DateTime CreationTime { get; set; }

        public virtual long? CreatorUserId { get; set; }

        protected CreationAuditedEntity()
        {
            CreationTime = DateTime.Now;
        }
    }
}