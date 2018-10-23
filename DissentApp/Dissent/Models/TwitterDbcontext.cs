using Dissent.Models;
using Microsoft.EntityFrameworkCore;

namespace Dissent.wwwroot.Models
{
    public class TwitterDbcontext : DbContext
    {
        
        public TwitterDbcontext(DbContextOptions<TwitterDbcontext> options)
            : base(options)
        {
        }
        public DbSet<Tweets> Tweets { get; set; }
    }
}
