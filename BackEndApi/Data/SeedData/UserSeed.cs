using BackEndApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEndApi.Data.SeedData
{
    public static class UserSeed
    {
        public static void SeedUser(this ModelBuilder builder)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                },
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "USER",
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }   
    }
}
