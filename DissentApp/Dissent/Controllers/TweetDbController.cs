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
            return View(await _context.text.Include("incomingTweets").ToListAsync());
        }

        [HttpPost]
        public IActionResult Add([FromBody]TweetsWithSentiment tweetsWithSentiment)
        {
            _context.Add(tweetsWithSentiment);
            _context.SaveChanges();

            return Ok(tweetsWithSentiment.Id);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Query query)
        {
            _context.Add(query);
            _context.SaveChanges();

            return Ok(query.Id);
        }
    }
}

