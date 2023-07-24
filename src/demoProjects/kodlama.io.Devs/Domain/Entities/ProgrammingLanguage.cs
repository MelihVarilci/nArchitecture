using Core.Persistence.Entities.Auditing;

namespace Domain.Entities
{
    public class ProgrammingLanguage : FullAuditedEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }

        public ProgrammingLanguage()
        {
            Technologies = new HashSet<Technology>();
        }

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}