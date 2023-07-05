using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, BaseDbContext>, IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<EmailAuthenticator>> DeleteAllNonVerifiedAsync(User user)
        {
            List<EmailAuthenticator> userEmailAuthenticators = Query()
                .Where(uea => uea.UserId == user.Id && uea.IsVerified == false)
                .ToList();

            await DeleteRangeAsync(userEmailAuthenticators);

            //foreach (UserEmailAuthenticator userEmailAuthenticator in userEmailAuthenticators)
            //{
            //    Context.Entry(userEmailAuthenticator).State = EntityState.Deleted;
            //}
            //await Context.SaveChangesAsync();

            return userEmailAuthenticators;
        }
    }
}