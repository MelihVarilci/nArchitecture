using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual int ProgrammingLanguageId { get; set; }

        [ForeignKey("ProgrammingLanguageId")]
        public ProgrammingLanguage? ProgrammingLanguageFk { get; set; }
    }
}