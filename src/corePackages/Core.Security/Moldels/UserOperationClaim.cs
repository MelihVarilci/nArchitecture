using Core.Persistence.Repositories;

namespace Core.Security.Moldels;

public class UserOperationClaim : Entity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual AppUser User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId) : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}