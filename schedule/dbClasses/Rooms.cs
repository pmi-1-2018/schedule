using System;
using System.Collections.Generic;
using schedule.Enums;

namespace schedule
{
    [Serializable]
    public partial class Rooms
    {
        public Rooms()
        {
            Classes = new HashSet<Classes>();
        }

        public long Id { get; set; }
        public ClassType Type { get; set; }
        public long? Number { get; set; }
        public long? Size { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
