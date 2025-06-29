using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _accountService.RegisterAsync(model);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _accountService.LoginAsync(model);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Invalid login attempt");

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied() => View();

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        // make a page to manage current profile
        // edit username/password/delete profile
        //then make them all for admin
    }

    [HttpGet]
    public async Task<IActionResult> EditUsername()
    {
        var user = await _accountService.GetCurrentUserAsync();
        if (user is null) return NotFound();

        var model = new EditUsernameViewModel { NewUsername = user.UserName };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditUsername(EditUsernameViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _accountService.GetCurrentUserAsync();
        if (user is null) return NotFound();


        user.UserName = model.NewUsername;
        var result = await _accountService.UpdateUserAsync(user);

        if (result.Succeeded) return RedirectToAction("Index", "Home");

        foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);

        return View(model);
    }
}
