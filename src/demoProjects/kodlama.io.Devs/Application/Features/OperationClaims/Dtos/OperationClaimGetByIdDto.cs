namespace Application.Features.OperationClaims.Dtos
{
    public class OperationClaimGetByIdDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}