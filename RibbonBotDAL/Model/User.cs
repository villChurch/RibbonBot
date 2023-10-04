using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RibbonBotDAL.Model
{
    public class User
    {
        //TODO: Add admin/edit roles

        [Key]
        public long id { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public ClaimsPrincipal ToClaimsPrincipal()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Hash, password)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            return new ClaimsPrincipal(userIdentity);
        }

        public static User FromClaimsPrincipal(ClaimsPrincipal principal)
        {
            return new User
            {
                username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "",
                password = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Hash)?.Value ?? ""
            };
        }

    }
}
