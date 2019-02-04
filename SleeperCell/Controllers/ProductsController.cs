using System.Web.Mvc;
using SleeperCell.Handlers;
using SleeperCell.Models;

namespace SleeperCell.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository _productRepository;
        private CategoryService _categoryService;

        // GET: Products
        public ProductsController()
        {
            _categoryService = new CategoryService();
            _productRepository = new ProductRepository();
        }
        public ActionResult Index()
        {
            return View(_productRepository.GetAllProducts());
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var product = _productRepository.FindProduct(Id);
            ViewBag.CategorySelectList = _categoryService.GetSelectList(product.CategoryId);
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategorySelectList = _categoryService.GetSelectList();
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(_productRepository.FindProduct(Id));
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(_productRepository.FindProduct(Id));
        }
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            _productRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}