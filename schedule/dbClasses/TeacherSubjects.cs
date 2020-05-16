using System;
using System.Collections.Generic;

namespace schedule
{
    public partial class TeacherSubjects
    {
        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? SubjectId { get; set; }
        public long? Count { get; set; }

        public virtual Subjects Subject { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
