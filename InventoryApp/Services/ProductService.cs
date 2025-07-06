using System.Security.Claims;
using InventoryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

public class ProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _http;
    private readonly string userId;

    public ProductService(ApplicationDbContext context, IHttpContextAccessor http)
    {
        _context = context;
        _http = http;
        userId = _http.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Anonymous";
    }

    public async Task<List<Product>> GetAllProducts() => await _context.Products.Where(p => p.UserId == userId).ToListAsync();

    public async Task<Product?> GetProduct(int id) => await _context.Products.Where(p => p.UserId == userId && id == p.Id).SingleOrDefaultAsync();

    public async Task AddProduct(Product product)
    {
        product.UserId = userId ?? "Anonymous";

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task EditProduct(Product product)
    {
        product.UserId = userId ?? "Anonymous";

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}