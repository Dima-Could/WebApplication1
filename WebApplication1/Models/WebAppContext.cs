using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class WebAppContext : DbContext
    {
        public WebAppContext() : base("DefaultConection")
        {
            
        }
        public DbSet<Customer> Customers  { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}