using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kerridge.MAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        // GET: api/<TaxController>
        [HttpGet]
        public IEnumerable<string> GetTax()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TaxController>/5
        [HttpGet("{id}")]
        public string GetTaxById(int id)
        {
            return "value";
        }

        // POST api/<TaxController>
        [HttpPost]
        public void PostTax([FromBody] string value)
        {
        }

        // PUT api/<TaxController>/5
        [HttpPut("{id}")]
        public void PutTax(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaxController>/5
        [HttpDelete("{id}")]
        public void DeleteTax(int id)
        {
        }
    }
}
