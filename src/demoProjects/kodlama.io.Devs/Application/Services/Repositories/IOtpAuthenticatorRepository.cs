using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IOtpAuthenticatorRepository : IRepository<OtpAuthenticator>, IAsyncRepository<OtpAuthenticator>
    {
    }
}