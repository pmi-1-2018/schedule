using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    class Group
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Size { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
