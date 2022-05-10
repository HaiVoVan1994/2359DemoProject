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
            var passWordAdmin = CreatePasswordSeedData("admin");
            var passWordUserTest = CreatePasswordSeedData("test");
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passWordAdmin.Item1,
                    PasswordSalt = passWordAdmin.Item2,
                    DOB = new DateTime(1990, 01, 01),
                    Email = "ProjectAdmin123@gmail.com",
                    Gender = Common.Enum.GenderEnum.Unknown,
                    CreatedDate = new DateTime(),
                    RoleId = (int)Common.Enum.UserRoleEnum.Administrator
                },
                new User
                {
                    Id = 2,
                    Username = "test",
                    PasswordHash = passWordUserTest.Item1,
                    PasswordSalt = passWordUserTest.Item2,
                    DOB = new DateTime(1990, 01, 01),
                    Email = "TestUser123@gmail.com",
                    Gender = Common.Enum.GenderEnum.Female,
                    CreatedDate = new DateTime(),
                    RoleId = (int)Common.Enum.UserRoleEnum.User
                }
            };

            builder.HasData(users);
        }

        public Tuple<byte[], byte[]> CreatePasswordSeedData(string password)
        {
            _userService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            return Tuple.Create(passwordHash, passwordSalt);
        }
    }
}
