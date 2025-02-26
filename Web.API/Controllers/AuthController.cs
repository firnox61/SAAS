using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                // Önce eski çerezi sil
                Response.Cookies.Delete("AuthToken");

                // Yeni çerezi ekle
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // HTTP için false, production'da true olmalı
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.Expiration
                };

                Response.Cookies.Append("AuthToken", result.Data.Token, cookieOptions);

                return Ok(new { message = "Login successful" });
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                // Önce eski çerezi sil
                Response.Cookies.Delete("AuthToken");

                // Yeni çerezi ekle
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // HTTP için false, production'da true olmalı
                    SameSite = SameSiteMode.Strict,
                    Expires = result.Data.Expiration
                };

                Response.Cookies.Append("AuthToken", result.Data.Token, cookieOptions);

                return Ok(new { message = "Registration successful" });
            }

            return BadRequest(result.Message);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            
            return Ok(new { message = "Logged out successfully" });
        }

        //[HttpGet("getuserdetails")]
        //public IActionResult GetUserDetail()
        //{
        //    var result = _userService.GetUserDetailDtos();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}