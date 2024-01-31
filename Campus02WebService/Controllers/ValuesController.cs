using Campus02WebService.Models;
using Microsoft.AspNetCore.Mvc;


//Run-Symbol, F5, Menü Debug - Start Debug

//campus02.at.WebServices.Security
//microsoft.word
//apple.ui

namespace Campus02WebService.Controllers
{
    [Route("api/[controller]")] //Attribute -- Metadaten 
    [ApiController]
    //GET  ......http:///.... /api/Values
    public class ValuesController : ControllerBase //Vererbung ValuesController erbt / wird abgeleitet von ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        //Methode mit Rückgabewert - Function 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Student student1 = new Student(); //implizit weil using vorhanden
            Campus02WebService.Models.Student student2 = new Campus02WebService.Models.Student();

            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        //void Methode ohne Rückgabewert
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
