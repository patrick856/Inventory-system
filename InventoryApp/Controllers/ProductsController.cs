using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService service)
    {
        _productService = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProducts();
        return View(products);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        await _productService.AddProduct(product);
        TempData["Announcement"] = "Item created successfully :> .";
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProduct(id);
        if (product is null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        await _productService.EditProduct(product);
        TempData["Announcement"] = "Item edited successfully :> .";
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Product product)
    {
        await _productService.DeleteProduct(product);
        TempData["Announcement"] = "Item deleted successfully :> .";
        return RedirectToAction("Index");
    }
}