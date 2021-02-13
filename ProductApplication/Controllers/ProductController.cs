using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.PRODUCTOSContext db = new Models.PRODUCTOSContext())
            {

                var lst = (from p in db.Products join s in db.ProductConditions on p.ProdCondition equals s.CondId where p.ProdStatus == 0
                           select new Models.Request.ProductGetRequest
                           {
                               ProdId = p.ProdId,
                               ProdName = p.ProdName,
                               ProdCondition = s.CondName,
                               ProdStatus = p.ProdStatus
                           }).ToList();

                return Ok(lst);
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Product>> GetProduct(int id)
        {
            using (Models.PRODUCTOSContext db = new Models.PRODUCTOSContext())
            {
                Models.Product Product = db.Products.Find(id);

                if (Product == null)
                {
                    return NotFound();
                }

                return Product;
            }

            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.ProductPostRequest request)
        {
            using (Models.PRODUCTOSContext db = new Models.PRODUCTOSContext())
            {
                Models.Product Product = new Models.Product();
                Product.ProdName = request.name;
                Product.ProdCondition = request.condition;
                Product.ProdStatus = 0;

                db.Add(Product);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.ProductPutRequest request)
        {
            using (Models.PRODUCTOSContext db = new Models.PRODUCTOSContext())
            {
                Models.Product Product = db.Products.Find(request.id);
                Product.ProdCondition = request.condition;
                Product.ProdStatus = request.status;

                db.Entry(Product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
