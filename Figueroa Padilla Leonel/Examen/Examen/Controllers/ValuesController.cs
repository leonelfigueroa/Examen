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
        [HttpPost]
        public HttpResponseMessage Create(Persona persona)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                bd.Persona.Add(persona);
                bd.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Update(Persona persona)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var newPersona = bd.Persona.Single(p => p.Dni == persona.Dni);
                newPersona.PrimerNom = persona.PrimerNom;
                newPersona.SegundoNom = persona.SegundoNom;
                newPersona.ApellidoPaterno = persona.ApellidoPaterno;
                newPersona.ApellidoMaterno = persona.ApellidoMaterno;
                newPersona.FechaNacimiento = persona.FechaNacimiento;

                bd.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("Delete/{dni}")]
        public HttpResponseMessage Delete(string dni)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                bd.Persona.Remove(bd.Persona.Single(p => p.Dni == dni));

                bd.SaveChanges();
                return result;
            }
            catch
            {

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
