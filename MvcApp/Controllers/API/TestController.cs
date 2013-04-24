using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using MvcApp.Models;

namespace MvcApp.Controllers.API
{
    public class TestController : ApiController
    {
        private static readonly ConcurrentDictionary<Guid, TestDto> Tests = new ConcurrentDictionary<Guid, TestDto>();

        // GET api/test
        public IEnumerable<TestDto> Get()
        {
            return Tests.Values;
        }

        // GET api/test/5
        public TestDto Get(Guid id)
        {
            TestDto test;
            if (Tests.TryGetValue(id, out test))
            {
                return test;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST api/test
        public TestDto Post(TestDto test)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var id = Guid.NewGuid();
            test.Id = id;
            if (!Tests.TryAdd(id, test))
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            return test;
        }
    }
}
