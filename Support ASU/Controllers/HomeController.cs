using TriviaQuiz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TriviaQuiz.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TriviaContext db = new TriviaContext();
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var data = db.TriviaQuestions.ToList();
            return View(data);
        }

        public ActionResult Contact()
        {
            var userId = User.Identity.Name;
            var lastQuestionId = db.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
                .Select(q => q.QuestionId)
                .FirstOrDefault();
            ViewBag.Message = userId;
            ViewBag.data = lastQuestionId;

            return View();
        }
        //private async Task<TriviaQuestion> NextQuestionAsync(string userId)
        //{
        //    var lastQuestionId = await this.db.TriviaAnswers
        //        .Where(a => a.UserId == userId)
        //        .GroupBy(a => a.QuestionId)
        //        .Select(g => new { QuestionId = g.Key, Count = g.Count() })
        //        .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
        //        .Select(q => q.QuestionId)
        //        .FirstOrDefaultAsync();

        //    var questionsCount = await this.db.TriviaQuestions.CountAsync();

        //    var nextQuestionId = (lastQuestionId % questionsCount) + 1;
        //    return await this.db.TriviaQuestions.FindAsync(CancellationToken.None, nextQuestionId);
        //}
    }
}