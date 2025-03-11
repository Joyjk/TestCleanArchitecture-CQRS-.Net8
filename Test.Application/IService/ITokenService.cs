using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.IService
{
    public interface ITokenService
    {
        Task<string> GenerateJWToken(string user_id, string password, string userType);
        //string GenerateRefreshToken();
        string GetClaimFromToken(string token, string claimType);
        //void StoreRefreshToken(string username, string refreshToken);
        //bool ValidateRefreshToken(string username, string refreshToken);
    }
}
