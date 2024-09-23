using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands.Auth
{
    public class SignIn
    {
        public class Request : IRequest<AuthResponse>
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class AuthResponse
        {
            public required bool IsValid { get; set; }
            public required string Token { get; set; }
        }

        public class Handler(ILogger<Handler> logger, MembersContext context) : IRequestHandler<Request, AuthResponse>
        {
            private readonly ILogger<Handler> _logger = logger;
            private readonly MembersContext _context = context;

            public async Task<AuthResponse> Handle(Request request, CancellationToken cancellationToken)
            {
                var member = await _context.Members.FirstOrDefaultAsync(s => s.Email == request.Email && s.Password == request.Password);

                if (member == null)
                {
                    // Could not be validated
                    return new AuthResponse { IsValid = false, Token = "" };
                }

                return new AuthResponse { IsValid = true, Token = CreateToken(member) };
            }

            private static string CreateToken(Member member) {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("thisisakeythatiskindofbigandgettingbiggerthanthat");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                    [
                        new(ClaimTypes.NameIdentifier, member.Id.ToString()),
                    ]),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = "https://localhost:4242/login",
                    Audience = "ohana-user",
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}