using Dissent.wwwroot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissent.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly TwitterDbcontext _appDbContext;

        public FeedbackRepository(TwitterDbcontext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
