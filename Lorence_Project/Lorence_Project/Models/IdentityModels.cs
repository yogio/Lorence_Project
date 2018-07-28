using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lorence_Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AspNetUsers : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUsers> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class LorenceDbContext : IdentityDbContext<AspNetUsers>
    {
        public LorenceDbContext()
            : base("LorenceConnection", throwIfV1Schema: false)
        {
        }

        public static LorenceDbContext Create()
        {
            return new LorenceDbContext();
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        //public System.Data.Entity.DbSet<Lorence_Project.Models.AspNetUsers> LorenceUsers { get; set; }
    }
}