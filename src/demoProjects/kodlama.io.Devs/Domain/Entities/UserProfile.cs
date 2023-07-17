using Core.Security.Enums;
using Core.Security.Moldels;

namespace Domain.Entities
{
    public class UserProfile : AppUser
    {
        public virtual SocialProfile SocialProfile { get; set; }

        public UserProfile()
        {
        }

        public UserProfile(int id,
            string firstName,
            string lastName,
            string email,
            byte[] passwordSalt,
            byte[] passwordHash,
            bool status,
            AuthenticatorType authenticatorType)
            : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}