using Dissent.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dissent.wwwroot.Models
{
    public class TwitterDbcontext : IdentityDbContext<IdentityUser>
    {
        
        public TwitterDbcontext(DbContextOptions<TwitterDbcontext> options)
            : base(options)
        {
        }
        public DbSet<TweetsWithSentiment> TweetsWithSentiment { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Query> Query { get; set; }

    }
}
