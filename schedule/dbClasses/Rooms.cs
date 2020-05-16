using System;
using System.Collections.Generic;

namespace schedule
{
    public partial class Rooms
    {
        public Rooms()
        {
            Classes = new HashSet<Classes>();
        }

        public long Id { get; set; }
        public int? Type { get; set; }
        public long? Number { get; set; }
        public long? Size { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
