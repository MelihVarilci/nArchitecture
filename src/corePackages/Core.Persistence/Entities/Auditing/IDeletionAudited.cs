namespace Core.Persistence.Entities.Auditing
{
    public interface IDeletionAudited : IHasDeletionTime
    {
        public long? DeleterUserId { get; set; }
    }
}