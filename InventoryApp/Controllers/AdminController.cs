using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AdminService _adminService;

    public AdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    public IActionResult Index() => View();

    public async Task<IActionResult> UserList()
    {
        var model = await _adminService.GetAllUsers();
        return View(model);
    }

    public async Task<IActionResult> ProductList()
    {
        var products = await _adminService.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> UserConfigure(string id)
    {
        var userModel = await _adminService.GetUser(id);
        if (userModel is not null)
            return View(userModel);
        return NotFound();
    }
}