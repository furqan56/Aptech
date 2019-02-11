using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Models;
using SleeperCell.Handlers;

namespace SleeperCell.Controllers
{
    [RoutePrefix("Product")]
    public class ProductInfoController : Controller
    {
        ProductRepository _productRepository = new ProductRepository(); 
        // GET: ProductInfo
        [HttpGet,Route("info/{start}/{count}")]
        public ActionResult Index(int start,int count)
        {
            if (Request.IsAjaxRequest())
            {
                var data = _productRepository.GetAllProducts().OrderByDescending(x => x.Id).Take(count);
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}