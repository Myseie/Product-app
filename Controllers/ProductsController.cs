using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1", Price = 100, Description = "This is Product 1" },
            new Product { Id = 2, Name = "Product 2", Price = 200, Description = "This is Product 2" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);

            }
            return RedirectToAction("Index");

        }
    }
}
