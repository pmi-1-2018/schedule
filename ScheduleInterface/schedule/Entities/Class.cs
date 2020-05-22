using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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

        [XmlIgnore]
        public virtual Group Group { get; set; }
        [XmlIgnore]
        public virtual Room Room { get; set; }
        [XmlIgnore]
        public virtual Subject Subject { get; set; }
        [XmlIgnore]
        public virtual Teacher Teacher { get; set; }
        public Class()
        {
          
        }
    }
}
