using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class AnswerController : Controller
    {
        private readonly API.AnswerController answerApi = new API.AnswerController();
        private readonly API.TestController testApi = new API.TestController();

        //
        // GET: /Answer/

        public ActionResult Get(Guid id)
        {
            var test = testApi.Get(id);
            var answers = new AnswersDto
                {
                    TestId = test.Id,
                    TestName = test.Name,
                    Answers =
                        test.Questions.Select(
                            q =>
                            new AnswerDto
                                {
                                    Question = q.Question,
                                    MarkingCriteria = q.MarkingCriteria,
                                    Points = q.Points
                                }).ToList(),
                };

            return View(answers);
        }

    }
}
