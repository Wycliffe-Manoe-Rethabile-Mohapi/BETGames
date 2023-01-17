using BETGaming.Server.Data;
using System.Security.Cryptography;

namespace BETGaming.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public DataContext _Context { get; }
        public AuthService(DataContext context)
        {
            _Context = context;
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
    }
}
