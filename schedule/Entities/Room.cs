using System;

namespace schedule.Entities
{
    [Serializable]
    public class Room
    {
        public uint? Id { get; set; }
        public ClassType? Type { get; set; }
        public uint? Number { get; set; }
        public uint? Size { get; set; }

        public Room(){}
    }
}
