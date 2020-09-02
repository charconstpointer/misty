using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Misty.Commands
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetUsername()
        {
            if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var bearer))
                throw new ApplicationException();
            var username = GetUsername(bearer);
            return await Task.FromResult(username);
        }

        private string GetUsername(StringValues bearer)
        {
            var s = bearer.ToString();
            var token = s.AsSpan().Slice("Bearer ".Length).ToString();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            return tokenS?.Claims.Single(c => c.Type == "unique_name").Value;
        }
    }

    public interface IUserAccessor
    {
        Task<string> GetUsername();
    }
}