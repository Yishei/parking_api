
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using parking_api.Models.EFModels;
//using System.Threading.Tasks;

//namespace parking_api.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class UserController : ControllerBase
//{
//    private readonly UserManager<User> _userManager;
//    private readonly SignInManager<User> _signInManager;

//    public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }

//    [HttpPost("register")]
//    public async Task<IActionResult> Register(string email)
//    {
//        var user = new User { UserName = email, Email = email };
//        var result = await _userManager.CreateAsync(user, "RandomPassword123!");

//        if (result.Succeeded)
//        {
//            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//            var resetLink = Url.Action("ResetPassword", "User", new { token = token, email = email }, Request.Scheme);

//            // Send the email with the reset link here. This depends on how you send emails in your application.

//            return Ok();
//        }

//        return BadRequest(result.Errors);
//    }


//    [HttpPost("login")]
//    public async Task<IActionResult> Login(string email, string password)
//    {
//        var user = await _userManager.FindByEmailAsync(email);
//        if (user != null && await _userManager.CheckPasswordAsync(user, password))
//        {
//            // Authentication successful, generate and return a token.
//            // This depends on how you handle authentication in your application.
//            var token = GenerateToken(user);
//            return Ok(new { token = token });
//        }

//        // Authentication failed, return Unauthorized.
//        return Unauthorized();
//    }
//}
