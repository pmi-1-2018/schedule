using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    public enum RoomType
    {
        Lecture,
        Computer,
        Ordinary,
    }

    class Room
    {
        public RoomType RoomType { get; set; }
        public uint Number { get; set; }
    }
}
