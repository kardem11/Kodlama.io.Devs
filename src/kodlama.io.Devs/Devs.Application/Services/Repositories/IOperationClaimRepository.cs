﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Devs.Application.Services.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }

}
