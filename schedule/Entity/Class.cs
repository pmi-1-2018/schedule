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
        public uint Id { get; set; }
        public uint RoomId { get; set; }
        public uint GroupId { get; set; }
        public uint SubjectId { get; set; }
        public uint TeacherId { get; set; }
        public Day Day { get; set; }
        public uint Number { get; set; }
    }
}
