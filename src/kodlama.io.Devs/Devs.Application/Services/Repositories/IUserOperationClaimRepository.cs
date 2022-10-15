using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Devs.Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }

}
