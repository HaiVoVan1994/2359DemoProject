namespace InterviewProject.Common.Services
{
    using InterviewProject.Common.Enum;
    using InterviewProject.Common.OptionConfiguration;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class TokenServices : ITokenService
    {
        private readonly IOptions<JWTOptions> _jwtOptions;
        public TokenServices(IOptions<JWTOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string CreateToken(string userName, string userEmai, UserRoleEnum userRole)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, userEmai),
                new Claim(ClaimTypes.Role, userRole.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.ValidIssuer,
                audience: _jwtOptions.Value.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
