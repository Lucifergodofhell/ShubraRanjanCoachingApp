using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShubraRanjanAPI.Entities;

namespace ShubraRanjanAPI.Services;
public class TokenServices(UserManager<AppUser> userManager,IConfiguration config) : ITokenServices
{

   public async Task<string> CreateToken(AppUser user)
   {
      var tokenKey = config["TokenKey"];
      if(String.IsNullOrEmpty(tokenKey) ||  tokenKey.Length < 64)
      {
         throw new Exception("Token Key is smaller than 64 length");
      }
      
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email,user.Email!),
        new Claim(ClaimTypes.NameIdentifier,user.Id),
      }; 

      var roles = await userManager.GetRolesAsync(user);
      claims.AddRange(roles.Select(role=> new Claim(ClaimTypes.Role,role)));
      var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires =  DateTime.UtcNow.AddMinutes(15),
        SigningCredentials = cred
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
   }

   public string GenerateRefreshTokenToken()
   {
      var refreshToken = RandomNumberGenerator.GetBytes(64);
      return Convert.ToBase64String(refreshToken);
   }
}