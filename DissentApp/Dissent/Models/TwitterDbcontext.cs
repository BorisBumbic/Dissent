﻿using Dissent.Models;
using Microsoft.EntityFrameworkCore;

namespace Dissent.wwwroot.Models
{
    public class TwitterDbcontext : DbContext
    {
        
        public TwitterDbcontext(DbContextOptions<TwitterDbcontext> options)
            : base(options)
        {
        }
        public DbSet<TweetsWithSentiment> TweetsWithSentiment { get; set; }

        public DbSet<Query> Query { get; set; }

    }
}
