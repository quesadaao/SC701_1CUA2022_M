using FE.Models;
using FE.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(IProductsService _productsService, ICategoriesService _categoriesService)
        {
            productsService = _productsService;
            categoriesService = _categoriesService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {            
            return View(await productsService.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await productsService.GetOneByIdAsync((int)id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(categoriesService.GetAll(), "CategoryId", "CategoryName");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DateDiscontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                productsService.Insert(products);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(categoriesService.GetAll(), "CategoryId", "CategoryName", products.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await productsService.GetOneByIdAsync((int)id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(categoriesService.GetAll(), "CategoryId", "CategoryName", products.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DateDiscontinued")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productsService.Update(products);
                }
                catch (Exception ee)
                {
                    if (!ProductsExists(products.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(categoriesService.GetAll(), "CategoryId", "CategoryName", products.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await productsService.GetOneByIdAsync((int)id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await productsService.GetOneByIdAsync((int)id);
            productsService.Delete(products);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return (productsService.GetOneByIdAsync((int)id)!=null);
        }
    }
}
