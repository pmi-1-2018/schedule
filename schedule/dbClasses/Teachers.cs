using System;
using System.Collections.Generic;

namespace schedule
{
    [Serializable]
    public partial class Teachers
    {
        public Teachers()
        {
            Classes = new HashSet<Classes>();
            TeacherSubjects = new HashSet<TeacherSubjects>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<TeacherSubjects> TeacherSubjects { get; set; }
        public override string ToString()
        {
            return FullName;
        }
    }
}
