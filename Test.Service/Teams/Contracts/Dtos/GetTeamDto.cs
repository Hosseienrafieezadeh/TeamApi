using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;

namespace Test.Service.Teams.Contracts.Dtos
{
    public class GetTeamDto
    {
        public string TeamName { get; set; }
        public TshirtRGB TshirOriginally { get; set; }
        public TshirtRGB TshirSub { get; set; }

    }
}
