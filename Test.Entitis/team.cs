using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entitis
{
    public class team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public TshirtRGB TshirOriginally { get; set; }
        public TshirtRGB TshirSub{ get; set; }

        public List<Players> Players {  get; set; }=new List<Players>();

    }
}
