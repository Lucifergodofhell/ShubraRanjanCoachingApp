

using ShubraRanjanAPI.Entities;

public interface ITokenServices
{
   Task<string> CreateToken(AppUser appUser);
   string GenerateRefreshTokenToken();

}