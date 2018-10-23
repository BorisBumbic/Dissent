using Dissent.Models;
using Dissent.wwwroot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dissent.Controllers
{
    public class TweetDbController : Controller
    {
        private readonly TwitterDbcontext _context;

        public TweetDbController(TwitterDbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tweets.Include("incomingTweets").ToListAsync());
        }

        [HttpPost]
        public IActionResult Add([FromBody]Tweets tweets)
        {


            _context.Add(tweets);
            _context.SaveChanges();

            return Ok(tweets.Id);
        }
    }
}

