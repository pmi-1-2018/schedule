using System;

namespace schedule.Entities
{
    [Serializable]
    public class Group_Subject
    {
        public uint? GroupId { get; set; }
        public uint? SubjectId { get; set; }
        public uint? Count { get; set; }

        public Group_Subject(){}
    }
}
