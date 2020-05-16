using System;

namespace schedule.Entities
{
    [Serializable]
    public class TeacherSubject
    {
        public uint? Id { get; set; }
        public uint? TeacherId { get; set; }
        public uint? SubjectId { get; set; }
        public uint? Count { get; set; }

        public TeacherSubject(){}
    }
}
