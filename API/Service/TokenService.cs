using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenInterface
    {
        private SymmetricSecurityKey key;
        public TokenService(IConfiguration config)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(Appusers user)
        {
            var claims = new List<Claim>
            {
                   new Claim (JwtRegisteredClaimNames.NameId, user.Username)
            };

            var Creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescribtion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims) ,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = Creds
            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokenDescribtion);
            return tokenhandler.WriteToken(token);


        }

        
    }
}