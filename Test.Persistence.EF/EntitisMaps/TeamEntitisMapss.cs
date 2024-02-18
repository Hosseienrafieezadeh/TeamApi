using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;

namespace Test.Persistence.EF.EntitisMaps
{
    public class TeamEntitisMapss : IEntityTypeConfiguration<team>
    {
        public void Configure(EntityTypeBuilder<team> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_ => _.TeamName).IsRequired();
            _.Property(_ => _.TshirSub).IsRequired();
            _.Property(_ => _.TshirOriginally).IsRequired();

            _.HasMany(_=>_.Players).WithOne(_=>_.Team).HasForeignKey(_ =>_.TeamID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
