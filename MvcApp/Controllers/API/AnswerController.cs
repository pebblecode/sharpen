using System;
using System.Collections.Concurrent;
using System.Net;
using System.Web.Http;
using MvcApp.Models;

namespace MvcApp.Controllers.API
{
    public class AnswerController : ApiController
    {
        private static readonly ConcurrentDictionary<Guid, AnswersDto> Answers = new ConcurrentDictionary<Guid, AnswersDto>();

        // GET api/answer/5
        public AnswersDto Get(Guid id)
        {
            AnswersDto answers;
            if (Answers.TryGetValue(id, out answers))
            {
                return answers;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST api/answer
        public AnswersDto Post(AnswersDto answers)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var id = Guid.NewGuid();
            answers.Id = id;

            if (!Answers.TryAdd(id, answers))
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            return answers;
        }
    }
}
