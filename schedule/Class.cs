using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    public enum Day
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
    class Class
    {
        public Subject Subject { get; set; }
        public Group Group { get; set; }
        public Room Room { get; set; }
        public string Teacher { get; set; }
        public Day Day { get; set; }
        public uint Number { get; set; }
    }
}
