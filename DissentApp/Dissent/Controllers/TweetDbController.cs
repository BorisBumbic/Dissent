using Dissent.wwwroot.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dissent.Controllers
{
    public class TweetDbController : Controller
    {
        private readonly TwitterDbcontext _context;

        public TweetDbController(TwitterDbcontext context)
        {
            _context = context;
        }

        //utkommenterar för nu//BB
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.text.Include("incomingTweets").ToListAsync());
        //}

    }
}

