using CW16_1.Models;
using CW16_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CW16_1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProdcutRepository _prodcutRepository;

        public ProductController(IProdcutRepository prodcutRepository)
        {
            _prodcutRepository = prodcutRepository;
        }
        public IActionResult Index()
        {
            return View(_prodcutRepository.GetListOfProducts());
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _prodcutRepository.InsertProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_prodcutRepository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _prodcutRepository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _prodcutRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }

}
