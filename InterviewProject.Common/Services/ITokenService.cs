using InterviewProject.Common.Enum;

namespace InterviewProject.Common.Services
{
    public interface ITokenService
    {
        public string CreateToken(string userName, string userEmai, UserRoleEnum userRole);
    }
}