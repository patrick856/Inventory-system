using System.Security.Claims;
using InventoryApp.Models;
using Microsoft.AspNetCore.Identity;


public class AccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IHttpContextAccessor _http;
    public AccountService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        IHttpContextAccessor http)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _http = http;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
    {
        var user = new ApplicationUser { UserName = model.Username };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return result;


        if (!await _roleManager.RoleExistsAsync("User"))
            await _roleManager.CreateAsync(new IdentityRole("User"));

        await _userManager.AddToRoleAsync(user, "User");
        await _signInManager.SignInAsync(user, isPersistent: false);

        return result;
    }

    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(
            model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (!result.Succeeded)
            return result;

        var user = await _userManager.FindByNameAsync(model.Username);
        if (user is not null) await _userManager.UpdateAsync(user);

        return result;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    public async Task<ApplicationUser?> GetCurrentUserAsync()
    {
        var userId = _http.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return null;

        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
    {
        return await _userManager.UpdateAsync(user);
    }
}