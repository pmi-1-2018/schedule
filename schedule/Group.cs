using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    class Group
    {
        public string Specialty { get; set; }
        public uint Number { get; set; }
        public override string ToString()
        {
            return $"{Specialty}-{Number}";
        }
    }
}
