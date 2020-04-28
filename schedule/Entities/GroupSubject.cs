using System;

namespace schedule.Entities
{
    [Serializable]
    public class GroupSubject
    {
        public uint? GroupId { get; set; }
        public uint? SubjectId { get; set; }
        public uint? Count { get; set; }

        public GroupSubject(){}
    }
}
