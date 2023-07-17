using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IEmailAuthenticatorRepository : IRepository<EmailAuthenticator>, IAsyncRepository<EmailAuthenticator>
    {
        public Task<ICollection<EmailAuthenticator>> DeleteAllNonVerifiedAsync(AppUser user);
    }
}