using CTFServerSide.Data;
using CTFServerSide.DTOs;
using CTFServerSide.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        if (_context.Users.Any(u => u.UserName == userDto.UserName))
        {
            return false; 
        }

        var user = new User
        {
            UserName = userDto.UserName,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }


    public string? Login(LoginDTO loginDto)
    {
        var user = _context.Users.SingleOrDefault(u => u.UserName == loginDto.UserName);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim("UserName", user.UserName)
            }),
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
