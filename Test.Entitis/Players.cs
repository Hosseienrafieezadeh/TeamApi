using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entitis
{
    public class Players
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public DateTime Born { get; set; }
        public int TeamID { get; set; }
        public team Team { get; set; }

    }
}
