namespace InterviewProject.Application.UserFeature
{
using InterviewProject.Application.ProductFeature;
    using InterviewProject.Common;
    using InterviewProject.Common.Enum;
    using InterviewProject.Common.Services;
    using InterviewProject.Domains;
    using InterviewProject.Infrastructure;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class RegisterCommand : IRequest<RequestResult<RegisterResult>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
    }

    public class RegisterResult
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RequestResult<RegisterResult>>
    {
        private readonly DataContext _db;
        private readonly ITokenService _tokenService;
        private readonly ILogger<RegisterCommandHandler> _logger;
        private readonly IUserService _userService;

        public RegisterCommandHandler(DataContext db, ITokenService tokenService, ILogger<RegisterCommandHandler> logger, IUserService userService)
        {
            _db = db;
            _tokenService = tokenService;
            _logger = logger;
            _userService = userService;
        }
        public async Task<RequestResult<RegisterResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = new RegisterResult();
            try
            {
                if (_db.User.Any(x => x.Username.Equals(request.Username)))
                {
                    return await Task.FromResult(new FailResult<RegisterResult>(string.Format(
                        "User has existed")));
                }

                _userService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newUser = new User
                {
                    Username = request.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DOB = request.DOB,
                    Gender =  (GenderEnum)request.Gender,
                    Email = request.Email,
                    RoleId = (int)UserRoleEnum.User
                };
                _db.User.Add(newUser);
                _db.SaveChanges();

                result = new RegisterResult
                {
                    Id = newUser.Id,
                    Username = newUser.Username,
                    Email = newUser.Email,
                    DOB = newUser.DOB,
                    Gender = (newUser.Gender).ToString(),
                    Token = _tokenService.CreateToken(newUser.Username, newUser.Email, (UserRoleEnum)newUser.RoleId)
                };

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, _userService.GetUserName() + "register error:" + ex.Message);
                throw;
            }
            _logger.Log(LogLevel.Information, _userService.GetUserName() +": Register");
            return await Task.FromResult(new SuccessResult<RegisterResult>(result));
        }
    }
}
