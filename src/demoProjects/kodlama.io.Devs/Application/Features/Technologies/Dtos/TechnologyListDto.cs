using Domain.Entities;

namespace Application.Features.Technologies.Dtos
{
    public class TechnologyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguageFk { get; set; }
    }
}