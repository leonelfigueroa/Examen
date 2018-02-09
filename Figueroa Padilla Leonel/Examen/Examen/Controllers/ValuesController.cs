using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Web.Http;
using Examen.Models;
using Newtonsoft.Json;

namespace Examen.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private examenEntities bd = new examenEntities();

        // GET api/values
        public HttpResponseMessage GetPersona()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(
                    bd.Persona.ToList()));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
                    "application/json");
                return result;
            }
            catch 
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // GET api/values/5

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
