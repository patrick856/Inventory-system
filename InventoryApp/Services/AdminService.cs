
using InventoryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class AdminService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AdminService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<List<AdminUserViewModel>> GetAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var model = new List<AdminUserViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            model.Add(new()
            {
                Id = user.Id,
                Username = user.UserName ?? "Anonymous",
                Roles = roles.ToList()
            });
        }

        return model;
    }

    public async Task<AdminUserViewModel?> GetUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is not null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var model = new AdminUserViewModel { Id = user.Id, Username = user.UserName ?? "anonymous", Roles = roles.ToList() };
            return model;
        }

        return null;
    }

    public async Task<List<Product>> GetAllProducts() => await _context.Products.ToListAsync();
}