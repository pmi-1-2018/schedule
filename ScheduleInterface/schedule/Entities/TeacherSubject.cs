using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace schedule.Entities
{
    [Serializable]
    public partial class TeacherSubject
    {
        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? SubjectId { get; set; }
        public long? Count { get; set; }

        [XmlIgnore]
        public virtual Subject Subject { get; set; }
        [XmlIgnore]
        public virtual Teacher Teacher { get; set; }
    }
}
