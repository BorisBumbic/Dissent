﻿using Dissent.wwwroot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissent.Models
{
    public class Repository
    {
        private readonly TwitterDbcontext _context;

        public Repository(TwitterDbcontext context)
        {
            _context = context;
        }

        public void Add(TweetsWithSentiment tweet)
        {
            _context.Add(tweet);
            _context.SaveChanges();
        }

        public IEnumerable<TweetsWithSentiment> GetAll()
        {
            return _context.TweetsWithSentiment.ToList();
        }


        public void RecreateDatabase()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

    }
}
