using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SleeperCell.Handlers;
using SleeperCell.Models;

namespace SleeperCell.ApiControllers
{
    public class ProductsController : ApiController
    {
        private ProductService _productService;
        private CategoryService _categoryService;
        public ProductsController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }
        [HttpGet]
        public IHttpActionResult Index()
        {
            var products = _productService.GetAllProducts();

            return Json(products);
        }

        [HttpPost]
        public IHttpActionResult Index([FromBody] ProductViewModel product)
        {
            _productService.AddProduct(product);

            return Ok();
        }

        [HttpGet, Route("find/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _productService.FindProduct(id);

            return Json(product);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]ProductViewModel product)
        {
            return Ok();
        }
    }
}
