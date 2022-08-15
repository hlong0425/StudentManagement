

using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Response<string>> Login(string username, string password)
        {
            var response = new Response<string>();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username));


            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else
            {
                var hmac = new System.Security.Cryptography.HMACSHA512(user.Salt);
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computeHash.SequenceEqual(user.PasswordHash) == false)
                {
                    response.Success = false;
                    response.Message = "Wrong password";
                }

                else
                {
                    response.Data = user.Id.ToString();
                    response.Message = "Login success";
                }
            }


            return response;
            
        }

        public async Task<Response<int>> Register(User user, string password)
        {
            //Create Password

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Response<int> response = new Response<int>();

            if (await UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exist";
                return response;
            }

            var hmac = new System.Security.Cryptography.HMACSHA512();          

            user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); ;
            user.Salt = hmac.Key; ;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            
            response.Success = true;
            response.Message = "Register Completed";
            response.Data = user.Id;
            return response; 
        }       
       

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}
