using BETGaming.Server.Data;
using BETGaming.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BETGaming.Server.Services.AuthService
{

    public class AuthService : IAuthService
    {
        public DataContext _Context { get; }
        public IConfiguration _Configuration { get; }
        public IHttpContextAccessor _HttpContextAccessor { get; }

        public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _Context = context;
            _Configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
        }

        

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "User already exists"
                };
            }

            CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            user.PaswordHash= hash;
            user.PasswordSalt= salt;

            _Context.Users.Add(user);
            await _Context.SaveChangesAsync();

            return new ServiceResponse<int>() { Data = user.Id, Success = true ,Message = "Registration Successful"};
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _Context.Users.AnyAsync(s=>s.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();

            var user =  _Context.Users.FirstOrDefault(s=>s.Email.ToLower().Equals(email.ToLower()));
            if (user == null) 
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if(!VerifyPasswordHash(password, user.PaswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incrorrect username and password combination";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }

        private bool VerifyPasswordHash(string password, byte[] paswordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                        hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(paswordHash);
            }   
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Email)
            };

            var key = new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8
                        .GetBytes(_Configuration.GetSection("AppSettings:SecurityKey").Value));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _Context.Users.FindAsync(userId);

            if (user==null)
            {
                return new ServiceResponse<bool>()
                {
                    Success = false
                };
            }

            CreatePasswordHash(newPassword, out byte[] hash, out byte[] salt);

            user.PaswordHash = hash;
            user.PasswordSalt = salt;


            var response = await _Context.SaveChangesAsync();

            return new ServiceResponse<bool>()
            {
                Success = true,
                Data=true,
                Message = "Password has been changed."
            };
        }

        public int GetUserId()
        {
            return int.Parse(_HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public string GetUserEmail()
        {
            return _HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _Context.Users.FirstOrDefaultAsync(s => s.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
