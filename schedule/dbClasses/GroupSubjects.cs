using System;
using System.Collections.Generic;

namespace schedule
{
    [Serializable]
    public partial class GroupSubjects
    {
        public long Id { get; set; }
        public long? GroupId { get; set; }
        public long? SubjectId { get; set; }
        public long? Count { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Subjects Subject { get; set; }
        public GroupSubjects()
        {

        }
    }
}
