using Core.Persistence.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Technology : FullAuditedEntity
    {
        public string Name { get; set; }

        public virtual int ProgrammingLanguageId { get; set; }

        [ForeignKey("ProgrammingLanguageId")]
        public ProgrammingLanguage? ProgrammingLanguageFk { get; set; }
    }
}