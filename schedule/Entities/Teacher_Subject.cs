using System;

namespace schedule.Entities
{
    [Serializable]
    public class Teacher_Subject
    {
        public uint? TeacherId { get; set; }
        public uint? SubjectId { get; set; }
        public uint? Count { get; set; }

        public Teacher_Subject(){}
    }
}
