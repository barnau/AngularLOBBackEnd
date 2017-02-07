using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    //[EnableCorsAttribute("*", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        public IHttpActionResult Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();

            return Ok(products.Where(p => p.ProductCode.Contains(search)));
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();

            return Ok(products.Where(p => p.ProductId == id).FirstOrDefault());
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]ProductToPostDto productFromBody)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();

            int maxId = products.Max(p => p.ProductId);

            Product product = new Product()
            {
                
                ProductId = maxId + 1,
                Category = productFromBody.Category,
                Cost = productFromBody.Cost,
                Description = productFromBody.Description,
                ImageUrl = productFromBody.ImageUrl,
                Price = productFromBody.Price,
                ProductCode = productFromBody.ProductCode,
                ProductName = productFromBody.ProductName,
                ReleaseDate = DateTime.Now,
                Tags = productFromBody.Tags
            };

            productRepository.Save(product);

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // PUT: api/Products/5
        
        public IHttpActionResult Put(int id, [FromBody]Product productFromBody)
        {
            var productRepository = new ProductRepository();
            productRepository.Save(id, productFromBody);

            return Content(HttpStatusCode.Accepted, "Product Updated");


        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
