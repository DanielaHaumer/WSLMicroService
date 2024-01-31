
using Campus02WebService.Models;
using Campus02WebService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Campus02WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private Member Variable zeigt auf LieferkostenCalculator
        private ILieferkostenCalculator _calculator;
        private IConfiguration _configuration;

        //Konstruktor Injection
        public ProductController(ILieferkostenCalculator calculator, IConfiguration configuration)
        {
            _calculator = calculator;
            _configuration = configuration;
        }

        static List<Product> products = new List<Product>();

        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            
            return products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                //Product product = products[id]
                var product = products.Find(p => p.Id == id); // oder products.Where
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }

        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post(Product newProduct)
        {
            //LieferkostenCalculator calculator = new LieferkostenCalculator();

            newProduct.Lieferkosten = _calculator.CalculateLieferkosten(newProduct.Gewicht);

            //Über DI den Suffix aus appsettings.json auslesen
            //und in die Beschreibung einfügen

            // Check if a product with the same Id already exists
            if (products.Any(p => p.Id == newProduct.Id))
            {
                // Return a conflict response (HTTP 409) indicating that the resource already exists
                return Conflict($"A product with Id {newProduct.Id} already exists.");
            }

            // Access the suffix from configuration
            string suffix = _configuration["ProductSuffix"];

            // Append the suffix to the product description
            newProduct.Beschreibung = $"{newProduct.Beschreibung} - {suffix}";

            // If the product doesn't exist, add it to the list
            products.Add(newProduct);

            // Return a Created response (HTTP 201) with details of the created product
            return CreatedAtAction(nameof(Post), new { id = newProduct.Id }, newProduct); // route: URL wo das neue Produkt erreichbar ist
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = products.Find(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Id = updatedProduct.Id;
            existingProduct.Beschreibung = updatedProduct.Beschreibung;

            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return NoContent();
        }
    }
}
