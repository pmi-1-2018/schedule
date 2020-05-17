using System;
using System.Collections.Generic;

namespace schedule
{
    [Serializable]
    public partial class Classes
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public long GroupId { get; set; }
        public long SubjectId { get; set; }
        public long TeacherId { get; set; }
        public DayOfWeek? Day { get; set; }
        public long? Number { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Rooms Room { get; set; }
        public virtual Subjects Subject { get; set; }
        public virtual Teachers Teacher { get; set; }
        public Classes()
        {

        }
    }
}
