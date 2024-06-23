using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kerridge.MAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        // GET: api/<ReceiptController>
        [HttpGet]
        public IEnumerable<string> GetReceipt()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReceiptController>/5
        [HttpGet("{id}")]
        public string GetReceiptById(int id)
        {
            return "value";
        }

        // POST api/<ReceiptController>
        [HttpPost]
        public void PostReceipt([FromBody] string value)
        {
        }

        // PUT api/<ReceiptController>/5
        [HttpPut("{id}")]
        public void PutReceipt(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceiptController>/5
        [HttpDelete("{id}")]
        public void DeleteReceipt(int id)
        {
        }
    }
}
