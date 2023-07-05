using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IOtpAuthenticatorRepository : IRepository<OtpAuthenticator>, IAsyncRepository<OtpAuthenticator>
    {
    }
}