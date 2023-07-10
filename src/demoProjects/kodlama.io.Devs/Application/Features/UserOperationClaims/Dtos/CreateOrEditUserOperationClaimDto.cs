namespace Application.Features.UserOperationClaims.Dtos
{
    public class CreateOrEditUserOperationClaimDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}