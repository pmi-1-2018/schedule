using System;
using System.Collections.Generic;
using schedule.Enums;

namespace schedule
{
    [Serializable]
    public partial class Subjects
    {
        public Subjects()
        {
            Classes = new HashSet<Classes>();
            GroupSubjects = new HashSet<GroupSubjects>();
            TeacherSubjects = new HashSet<TeacherSubjects>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ClassType? Type { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<GroupSubjects> GroupSubjects { get; set; }
        public virtual ICollection<TeacherSubjects> TeacherSubjects { get; set; }
        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}
