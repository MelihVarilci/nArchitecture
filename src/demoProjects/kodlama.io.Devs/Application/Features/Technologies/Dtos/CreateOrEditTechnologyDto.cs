namespace Application.Features.Technologies.Dtos
{
    public class CreateOrEditTechnologyDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}