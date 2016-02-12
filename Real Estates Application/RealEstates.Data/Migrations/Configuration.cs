namespace RealEstates.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public sealed class Configuration : DbMigrationsConfiguration<RealEstatesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RealEstatesDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole { Name = "Administrator" });
                context.SaveChanges();
            }

            if (!context.Users.Where(u => u.UserName == "admin@site.com").Any())
            {
                var admin = new User
                {
                    UserName = "admin@site.com",
                    Email = "admin@site.com",
                    PasswordHash = new PasswordHasher().HashPassword("admin"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ImageURL = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTt7AMZyo3bBwOnN4tiunQJwcXfP9Z29X1BEsLmx1eYnNTlicRnusML0Jc".ToString()
                };

                context.Users.Add(admin);

                var role = context.Roles.Where(r => r.Name == "Administrator").FirstOrDefault();
                var adminRole = new IdentityUserRole
                {
                    RoleId = role.Id
                };

                admin.Roles.Add(adminRole);
                context.SaveChanges();
            }

            if (!context.Users.Where(u => u.UserName == "user1@site.com").Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    var user = new User
                    {
                        UserName = $"user{i}@site.com",
                        Email = $"user{i}@site.com",
                        PasswordHash = new PasswordHasher().HashPassword($"user{i}"),
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ImageURL = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTt7AMZyo3bBwOnN4tiunQJwcXfP9Z29X1BEsLmx1eYnNTlicRnusML0Jc".ToString()
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
