using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Atsumeru.Models.Administration;
using Atsumeru.Models.Figures;

namespace Atsumeru.Api
{
    public class CollectionTypeController : AbstractApiController
    {
        // GET api/collectiontype
        public IEnumerable<CollectionType> Get()
        {
            var apa = RavenSession.Query<CollectionType>().Customize(x => x.WaitForNonStaleResultsAsOfLastWrite()).ToList();
            return apa;
        }

        // GET api/collectiontype/5
        public CollectionType Get(string id)
        {
            return RavenSession.Query<CollectionType>().FirstOrDefault(d => d.CollectionIdentifier == id);
        }

        // POST api/collectiontype
        public HttpResponseMessage Post([FromBody]CollectionType value)
        {
            RavenSession.Store(value);
            RavenSession.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/collectiontype/5
        public HttpResponseMessage Put(string id, [FromBody]CollectionType value)
        {
            var existing = RavenSession.Load<CollectionType>(id);
            existing.Fields = value.Fields;
            existing.Name = value.Name;
            RavenSession.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/collectiontype/5
        public void Delete(int id)
        {
        }
    }
}
