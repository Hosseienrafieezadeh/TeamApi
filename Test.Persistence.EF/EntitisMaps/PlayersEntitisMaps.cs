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
    internal class PlayersEntitisMaps : IEntityTypeConfiguration<Players>
    {
        public void Configure(EntityTypeBuilder<Players> _)
        {
            _.HasKey(_ => _.Id);
            _.Property(_=>_.PlayerName).IsRequired();
            _.Property(_=>_.Born).IsRequired();
            _.HasOne(_ => _.Team).WithMany(_ => _.Players).HasForeignKey(_ => _.TeamID).OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
