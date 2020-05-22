using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace schedule.Entities
{
    [Serializable]
    public partial class Teacher
    {
        public Teacher()
        {
            Class = new HashSet<Class>();
            TeacherSubject = new HashSet<TeacherSubject>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }

        [XmlIgnore]
        public virtual ICollection<Class> Class { get; set; }
        [XmlIgnore]
        public virtual ICollection<TeacherSubject> TeacherSubject { get; set; }
        public override string ToString()
        {
            return FullName;
        }
    }
}
