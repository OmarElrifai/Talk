using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(userdata data)
        {
           if(await data.users.AnyAsync() ) return;
           var seed= await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
           var users= JsonSerializer.Deserialize<List<Appusers>>(seed);

           foreach(var user in users)
           {
               using var hmac= new HMACSHA512();

               user.PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
               user.PasswordSalt=hmac.Key;
               data.users.Add(user);
           }

           await data.SaveChangesAsync();

        }
    }
}