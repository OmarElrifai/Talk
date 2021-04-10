using API.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class userdata : DbContext
    {
        public userdata( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appusers> users { get; set; }
    }
}