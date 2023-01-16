﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ToDoApp.Api.Auth
{
    public class TokenGenerator
    {
        private readonly JwtSettings _settings;

        public TokenGenerator(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }
        public string Generate(string email)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, "api-user"),
                 new Claim("test type", "test value")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecrectKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            var tokenGenerator = new JwtSecurityTokenHandler();
            var jwtString = tokenGenerator.WriteToken(token);
            return jwtString;
        }
    }
}
