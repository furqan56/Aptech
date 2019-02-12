using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SleeperCell.Handlers;
using SleeperCell.Models;

namespace SleeperCell.Controllers
{
    
    [RoutePrefix("Product")]
    public class ProductInfoController : Controller
    {
      //  private ProductService _productService;
        // GET: ProductInfo
        [HttpGet,Route("info/{start}/{count}")]
        public ActionResult Index(int start,int count)
        {
            if (Request.IsAjaxRequest())
            {
                //var data=new List<ProductViewModel>();
               // var data = _productService.GetAllProducts();

               // return Json(data, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}