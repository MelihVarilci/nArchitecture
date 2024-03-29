﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Moldels;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, BaseDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
        {
        }
    }
}