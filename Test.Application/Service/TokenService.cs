using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using Test.Domain.Model;
using Newtonsoft.Json;
using Test.Application.IService;

namespace Test.Application.Service
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private static Dictionary<string, string> _refreshTokens = new();
        public TokenService(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<string> GenerateJWToken(string user_id, string password, string userType)
        {
            var user = new
            {
                user_id,
                password,
                userType
            };
            var claims = new[]
            {
                 new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(user)),

                 new Claim("uid", user_id),
                 new Claim("user_name", password),
                 new Claim(ClaimTypes.Role, userType)
             };

            return new JwtSecurityTokenHandler().WriteToken(JWTGeneration(claims));

        }
        private JwtSecurityToken JWTGeneration(IEnumerable<Claim> claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public string GetClaimFromToken(string token, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            return jsonToken?.Claims.FirstOrDefault(claim => claim.Type == claimType)?.Value;
        }
    }
}
