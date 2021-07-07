using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.Helper
{
    public class JWTHelper
    {
        private readonly byte[] secret;
        public JWTHelper(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(@secretKey);
        }

        public string CreateToken(string @username)
        {
            var claims = new ClaimsIdentity();

            var tokenDescription = new SecurityTokenDescriptor();

            tokenDescription.Subject = claims;
            tokenDescription.Expires = DateTime.UtcNow.AddHours(2);
            tokenDescription.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature);
          

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
