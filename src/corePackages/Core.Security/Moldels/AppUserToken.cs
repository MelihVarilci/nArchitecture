﻿using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserToken : IdentityUserToken<int>, IEntity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? ReasonRevoked { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;

        public AppUser User { get; set; }

        public AppUserToken()
        {
        }

        public AppUserToken(int id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked, string? revokedByIp, string? replacedByToken, string? reasonRevoked)
        {
            Id = id;
            Token = token;
            Expires = expires;
            Created = created;
            CreatedByIp = createdByIp;
            Revoked = revoked;
            RevokedByIp = revokedByIp;
            ReplacedByToken = replacedByToken;
            ReasonRevoked = reasonRevoked;
        }
    }
}