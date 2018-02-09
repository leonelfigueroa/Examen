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

        [HttpGet]
        public HttpResponseMessage GetPersonas()
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
        [HttpGet]
        [Route("GetPersona/{dni}")]
        public HttpResponseMessage GetPersona(string dni)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(
                    bd.Persona.Single (p=> p.Dni == dni)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
                    "application/json");
                return result;
            }
            catch
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
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
