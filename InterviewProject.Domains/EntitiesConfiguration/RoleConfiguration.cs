using InterviewProject.Common.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace InterviewProject.Domains.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roles = new List<Role>
            {
                new Role
                {
                   Id = 1,
                   RoleName = "Administrator",
                },
                new Role
                {
                    Id = 2,
                    RoleName = "User",
                }
            };

            builder.HasData(roles);
        }
    }
}
