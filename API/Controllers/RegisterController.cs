using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class RegisterController : APIController
    {
        private readonly userdata data;
        private readonly ITokenInterface itok;

        public RegisterController(userdata data , ITokenInterface itok)
        {
            this.data = data;
            this.itok = itok;
        }

        [HttpPost ("register")]
        public async Task<ActionResult<UserDTOs>> post(RegisterDTOs afreet )
        {  if(await UserExist(afreet.username)) return BadRequest("Username already used") ;
           using var hash = new HMACSHA512();
            var user = new Appusers
            {
              Username = afreet.username,
              PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(afreet.password)),
              PasswordSalt = hash.Key,
             // DateOfBirth=afreet.DateOfBirth,
              KnownAs=afreet.KnownAs,
              Gender=afreet.Gender,
              Introduction=afreet.Introduction,
              LookingFor=afreet.LookingFor,
              Interests=afreet.Interests,
              City=afreet.City,
              Country=afreet.Country
            };

            data.users.Add(user);
            await data.SaveChangesAsync();

            return new UserDTOs
            {
                Username = user.Username,
                Token = itok.CreateToken(user)
            };
        }

        public async Task<bool> UserExist(string username)
        {
           return await data.users.AnyAsync(x => x.Username.ToLower()==username.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTOs>> logg(LoginDTOs log)
        {
            var user = await data.users.SingleOrDefaultAsync(x => x.Username == log.username);
            if(user==null) return Unauthorized("Invalid Username");
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var logpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(log.password));

            for (int i = 0;i<user.PasswordHash.Length;i++)
            {
                if(logpassword[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDTOs
            {
                Username = user.Username,
                Token = itok.CreateToken(user)
            };

        }

    }
}