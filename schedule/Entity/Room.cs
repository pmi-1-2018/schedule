using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    public enum Type
    {
        Lecture,
        Computer,
        Ordinary,
    }

    class Room
    {
        public uint Id { get; set; }
        public Type Type { get; set; }
        public uint Number { get; set; }
        public uint Size { get; set; }
    }
}
