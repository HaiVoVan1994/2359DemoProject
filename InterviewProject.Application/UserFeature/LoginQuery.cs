namespace InterviewProject.Application.UserFeature
{
    using InterviewProject.Infrastructure;
    using MediatR;
    using System.Data;
    using System.Security.Cryptography;
    using InterviewProject.Common;
    using InterviewProject.Common.Services;
    using Microsoft.Extensions.Logging;
using InterviewProject.Common.Enum;
    using Microsoft.EntityFrameworkCore;

    public class LoginQuery : IRequest<RequestResult<LoginResult>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }

    public class LoginQueryHanlder : IRequestHandler<LoginQuery, RequestResult<LoginResult>>
    {
        private readonly DataContext _db;
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginQueryHanlder> _logger;
        private readonly IUserService _userService;

        public LoginQueryHanlder(DataContext db, ITokenService tokenService, ILogger<LoginQueryHanlder> logger, IUserService userService)
        {
            _db = db;
            _tokenService = tokenService;
            _logger = logger;
            _userService = userService;
        }
        public async Task<RequestResult<LoginResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userInfo = new LoginResult();
            try
            {
                var user = _db.User.Include(x => x.UserRole).Where(x => x.Username.Equals(request.Username)).FirstOrDefault();
                if (user == null)
                {
                    return await Task.FromResult(new FailResult<LoginResult>("User not found"));
                }

                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return await Task.FromResult(new FailResult<LoginResult>("Wrong password"));
                }
                var jwt = _tokenService.CreateToken(user.Username, user.Email, (UserRoleEnum)user.RoleId);
                userInfo = new LoginResult
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    DOB = user.DOB,
                    Gender = (user.Gender).ToString(),
                    Token = jwt,
                    Role = user.UserRole.RoleName
                };
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "Login error :" + e.Message);
                throw;
            }
            
            _logger.Log(LogLevel.Information, _userService.GetUserName() +": Login");
            return await Task.FromResult(new SuccessResult<LoginResult>(userInfo));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
