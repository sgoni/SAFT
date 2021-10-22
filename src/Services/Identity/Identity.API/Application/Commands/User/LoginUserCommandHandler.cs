using Identity.API.Infrastructure.Auth;
using Identity.Domain.AggregatesModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.API.Application.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object>
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginUserCommandHandler> _logger;
        private readonly IMediator _mediator;

        public LoginUserCommandHandler(
            IOptions<JwtBearerTokenSettings> jwtTokenOptions,
            UserManager<ApplicationUser> userManager,
            IMediator mediator,
            ILogger<LoginUserCommandHandler> logger)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value; ;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await ValidateUser(request.Username, request.Password);

            if (identityUser != null)
            {
                var token = GenerateToken(identityUser);
                return token;
            }
            else
            {
                return null;
            }
        }

        private async Task<IdentityUser> ValidateUser(string username, string password)
        {
            var identityUser = await _userManager.FindByNameAsync(username);

            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }

        private object GenerateToken(IdentityUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email)
                }),

                Expires = DateTime.UtcNow.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
