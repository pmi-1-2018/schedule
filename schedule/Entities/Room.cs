using System;
using System.Collections.Generic;
using schedule.Enums;

namespace schedule.Entities
{
    [Serializable]
    public partial class Room
    {
        public Room()
        {
            Class = new HashSet<Class>();
        }

        public long Id { get; set; }
        public ClassType Type { get; set; }
        public long? Number { get; set; }
        public long? Size { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
