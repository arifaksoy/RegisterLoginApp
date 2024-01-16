using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RegisterLoginApp.Server.Data
{
    public class RegisterLoginDBContext:IdentityDbContext
    {
        public RegisterLoginDBContext(DbContextOptions<RegisterLoginDBContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "1187f674-b649-45b3-a7ef-de977d2601fc";
            var writerRoleId = "df941982-f6b4-4df8-b8b5-254cc805eb3d";

            var roles = new List<IdentityRole> {
               new IdentityRole
               {
                   Id = readerRoleId,
                   ConcurrencyStamp = readerRoleId,
                   Name = "Reader",
                   NormalizedName = "Reader".ToUpper(),
               },
                new IdentityRole
               {
                   Id = writerRoleId,
                   ConcurrencyStamp = writerRoleId,
                   Name = "Writer",
                   NormalizedName = "Writer".ToUpper(),
               }
            };

            builder.Entity<IdentityRole>().HasData(roles);  
        }
    }
}
