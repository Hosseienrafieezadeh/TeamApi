using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entitis;

namespace Test.Service.Teams.Contracts.Dtos
{
    public class GetTeamFilterDto
    {
        public string? Name { get; set; }
        public TshirtRGB?Main  { get; set; }
        public TshirtRGB? sub  { get; set; }
    }
}
