using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Service.play.Contracts.Dtos
{
    public class GetplayersFillterDto
    {
        public string? PlayerName { get; set; }
       
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
    }
}
