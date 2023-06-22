using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
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