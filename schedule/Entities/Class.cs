using System;
using System.Collections.Generic;

namespace schedule.Entities
{
    [Serializable]
    public partial class Class
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public long GroupId { get; set; }
        public long SubjectId { get; set; }
        public long TeacherId { get; set; }
        public DayOfWeek? Day { get; set; }
        public long? Number { get; set; }

        public virtual Group Group { get; set; }
        public virtual Room Room { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Class()
        {
          
        }
    }
}
