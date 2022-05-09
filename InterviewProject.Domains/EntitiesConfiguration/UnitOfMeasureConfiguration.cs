using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Domains.EntitiesConfiguration
{
    public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.HasData(
                new UnitOfMeasure
                {
                   Id = 1,
                   UnitName = "Pack"
                },
                new UnitOfMeasure
                {
                    Id = 2,
                    UnitName = "Bar"
                },
                new UnitOfMeasure
                {
                    Id = 3,
                    UnitName = "Kilo"
                }
            );
        }
    }
}
