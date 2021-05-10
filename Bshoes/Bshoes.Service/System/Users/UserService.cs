using Bshoes.Data.EF;
using Bshoes.Data.Entiti;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Bshoes.ViewModel.System;

namespace Bshoes.Service.System.Users
{
    public class UserService : IUserService
    {
        public dbcontext _context;
        private readonly AppSettings _appSettings;
        public UserService(dbcontext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ip)
        {
            //get user from db
            var user = _context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            //return null if user=null
            if (user == null) return null;
            //create token
            var jwtToken = generateJwtToken(user);

            //create refresh token
            var refreshToken = generateRefreshToken(ip);

            //add refreshtoken
            user.RefreshTokens.Add(refreshToken);
            _context.Update(user);
            _context.SaveChanges();
            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //decode chuoi bi mat thanh dang bytes
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            List<Claim> listRole = new List<Claim>();
            listRole.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
            var query = from u in _context.Users
                        join ur in _context.UserRoles
                        on u.Id equals ur.UserId
                        join r in _context.Roles
                        on ur.RoleId equals r.Id
                        where u.Id == user.Id
                        select r.name;
            var l = query.ToList();
            for (int i = 0; i < l.Count; i++)
            {
                listRole.Add(new Claim(ClaimTypes.Role, l[i]));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(listRole),

                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private RefreshToken generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }

        public AuthenticateResponse RefreshToken(string token, string ip)
        {
            //get user co token =token gui len. do refresh token la array nen dung any
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null) return null;
            //lay ra refresh token 
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            // return null if token is no longer active
            if (!refreshToken.IsActive) return null;
            // replace old refresh token with a new one and save
            var newRefreshtoken = generateRefreshToken(ip);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ip;
            refreshToken.ReplacedByToken = newRefreshtoken.Token;


            user.RefreshTokens.Add(newRefreshtoken);
            _context.Update(user);
            _context.SaveChanges();

            var jwtToken = generateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshtoken.Token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            _context.Update(user);
            _context.SaveChanges();

            return true;
        }

        public List<UserViewModel>  GetAllUser()
        {
            List<User> list = _context.Users.ToList();
            var query = from u in _context.Users
                        join ur in _context.UserRoles
                        on u.Id equals ur.UserId
                        join r in _context.Roles
                        on ur.RoleId equals r.Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            FirstName=u.FirstName,
                             LastName= u.LastName,
                            Role = r.name
                        };
            return query.ToList();
        }
    }
}
