using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
   protected void SetRefreshTokenCookie(string refreshToken )
   {
      var cookieOption = new CookieOptions
         {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.UtcNow.AddDays(7)
         };
      Response.Cookies.Append("refreshToken",refreshToken,cookieOption);
   }
}