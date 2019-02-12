using System.Linq;
using SleeperCell.Models;
using SleeperCell.Handlers;
using System.Web.Mvc;

namespace SleeperCell.Controllers
{
    [RoutePrefix("product")]
    public class ProductInfoController : Controller
    {
        ProductRepository _productRepository = new ProductRepository(); 
        // GET: ProductInfo
        [HttpGet, Route("info/{start}/{count}")]
        public ActionResult Index(int start, int count)
        {
            if (Request.IsAjaxRequest())
            {
                var data = _productRepository.GetAllProducts().OrderByDescending(x => x.Id).Skip(start).Take(count);
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        [HttpPost, Route("create")]
        public ActionResult Create(ProductViewModel model)
        {
            if (Request.IsAjaxRequest())
            {
                var response = new
                {
                    Status = 200,
                    StatusText = "OK"
                };
                return Json(response);
            }
            return RedirectToAction("Create", "Products");
        }

        [HttpPost]
        public ActionResult Test(string name)
        {
            var response = new
            {
                Status = 200,
                StatusText = "OK"
            };
            return Json(response);
        }
    }
}