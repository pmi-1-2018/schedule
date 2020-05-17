using System;
using System.Collections.Generic;

namespace schedule.Entities
{
    [Serializable]
    public partial class TeacherSubject
    {
        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? SubjectId { get; set; }
        public long? Count { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
