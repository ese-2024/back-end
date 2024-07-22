using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CTFServerSide.Data;
using CTFServerSide.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace CTFServerSide.Services
{
    public class AuthService
    {
        private readonly CTFContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(CTFContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool Register(UserDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Email = userDto.Email
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public string Login(UserDTO userDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == userDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
