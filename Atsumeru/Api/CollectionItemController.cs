using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atsumeru.Models.Figures;

namespace Atsumeru.Api
{
    public class CollectionItemController : AbstractApiController
    {
        // GET api/collection
        public IEnumerable<Beast> Get()
        {
            return RavenSession.Query<Beast>().Customize(x => x.WaitForNonStaleResultsAsOfLastWrite()).ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/collection/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/collection
        public HttpResponseMessage Post([FromBody]Beast value)
        {
            RavenSession.Store(value);
            RavenSession.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/collection/5
        public void Put(int id, [FromBody]Beast value)
        {
            
        }

        // DELETE api/collection/5
        public void Delete(int id)
        {
        }
    }
}
