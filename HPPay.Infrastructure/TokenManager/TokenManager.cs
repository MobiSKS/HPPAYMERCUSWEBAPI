using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HPPay.Infrastructure.TokenManager
{

    public class TokenManager
    {


        //private static string Secret = Guid.NewGuid().ToString();
        public static string Secret = string.Empty;
        //public static string GenerateToken(string Useragent, string Userip)
        public static string GenerateToken(string Useragent, string Userid, string UserIp)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                      new Claim(ClaimTypes.Name,Userid )
                }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                //Issuer = Userip,
                Issuer = UserIp,
                Audience = Useragent,
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        //public static ClaimsPrincipal GetPrincipal(string token, string Useragent, string Userip, string UserId)
        public static ClaimsPrincipal GetPrincipal(string token, string Useragent, string UserId, string UserIp)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    NameClaimType = UserId,
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    //ValidIssuer = Userip,
                    ValidIssuer = UserIp,
                    ValidAudience = Useragent,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };


                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                return principal;


            }
            catch
            {
                return null;
            }
        }
        //public static string ValidateToken(string token, string Useragent, string Userip, string UserId)
        public static string ValidateToken(string token, string Useragent, string UserId, string UserIp)
        {
            //ClaimsPrincipal principal = GetPrincipal(token, Useragent, Userip, UserId);
            ClaimsPrincipal principal = GetPrincipal(token, Useragent, UserId, UserIp);
            if (principal == null)
                return null;
            ClaimsIdentity identity;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            string username = usernameClaim.Value;
            return username;
        }


    }
}
