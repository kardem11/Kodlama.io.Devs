using Core.Security.Entities;
using Core.Security.JWT;

namespace Devs.Application.Features.Auths.AuthServıce
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);

        public Task<RefreshToken> AddRefreshToken(RefreshToken token);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);

    }
}