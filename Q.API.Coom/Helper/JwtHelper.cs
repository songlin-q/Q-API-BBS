using Microsoft.IdentityModel.Tokens;
using Q.API.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Coom.Helper
{
    /// <summary>
    /// 生成JWt字符串  生成和解析
    /// </summary>
    public class JwtHelper
    {
        public static string IssueJet(TokenJwtModel jwtModel)
        {
            string iss = AppSettings.app(new string[] { "Audience", "Issuer" });//颁发者
            string aud = AppSettings.app(new string[] { "Audience", "Audience" });//订阅者
            string secret = AppSettings.app(new string[] { "Audience", "Secret" });//口令
            //通过打包的方式进行封装为一个字符串
            var claims = new List<Claim>
            {
                //特别注意：
                //这里将用户的部分信息，比如UID存入到claim中，如果想知道如何在其他地方将这个uid从token中获取出来，请看下面的
                //SerializeJwt()方法，或者在整个解决方案中搜索这个方法，
                //或者也可以研究一下，HttpContext.User.Claim,具体可以看看，Policys/PermissionHandler.cs类中是如何使用的



             new Claim(JwtRegisteredClaimNames.Jti,jwtModel.uID.ToString()),
             new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()}"),
             new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds()}"),
             
             new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeMilliseconds()}"),//这个为过期时间。目前过期1000毫秒，可以自定义，但是要注意的是JWT自己有缓冲时间
             
             new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(1000).ToString()),
             new Claim(JwtRegisteredClaimNames.Iss,iss),
             new Claim(JwtRegisteredClaimNames.Aud,aud),

            };
            //这样可以将一个用户的多个角色进行赋予权限
            claims.AddRange(jwtModel.Role.Split(',').Select(a => new Claim(ClaimTypes.Role, a)));
            //秘钥(SymmetricSecurityKey)对安全性的要求，密钥的长度太短会报出异常
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var JWT = new JwtSecurityToken(
                issuer: iss,
                claims: claims,
                signingCredentials: creds
                );
            var Jwthandler = new JwtSecurityTokenHandler();//通过打包的方式封装为一个字符串
            var encodedJwt = Jwthandler.WriteToken(JWT);

            return encodedJwt;


        }
        /// <summary>
        /// 对JWT字符串进行解析然后返回相对应的model
        /// </summary>
        /// <param name="jwtstr"></param>
        /// <returns></returns>
        public static TokenJwtModel SerializeJwt(string jwtstr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            TokenJwtModel tokenJwtModel=new TokenJwtModel();
            //token检查
            if (!string.IsNullOrWhiteSpace(jwtstr) && jwtHandler.CanReadToken(jwtstr))
            {
                JwtSecurityToken jwttoken = jwtHandler.ReadJwtToken(jwtstr);//读取token
                object role;
                jwttoken.Payload.TryGetValue(ClaimTypes.Role, out role);
                tokenJwtModel = new TokenJwtModel {
                 uID=Convert.ToInt64(jwttoken.Id),
                 Role=role==null?"":role.ToString()
                
                }; 



            }

            return tokenJwtModel;
        
        }

    }
}
