using InterviewProject.Common.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace InterviewProject.Domains.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IUserService _userService;
        public UserConfiguration(IUserService userService)
        {
            _userService = userService;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _userService.CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DOB = new DateTime(1990, 01, 01),
                    Email = "ProjectAdmin123@gmail.com",
                    Gender = Common.Enum.GenderEnum.Unknown,
                    CreatedDate = new DateTime()
                }
            );
        }
    }
}
