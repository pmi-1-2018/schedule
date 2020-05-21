using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using schedule.Enums;

namespace schedule.Entities
{
    [Serializable]
    public partial class Subject
    {
        public Subject()
        {
            Class = new HashSet<Class>();
            GroupSubject = new HashSet<GroupSubject>();
            TeacherSubject = new HashSet<TeacherSubject>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ClassType? Type { get; set; }

        [XmlIgnore]
        public virtual ICollection<Class> Class { get; set; }
        [XmlIgnore]
        public virtual ICollection<GroupSubject> GroupSubject { get; set; }
        [XmlIgnore]
        public virtual ICollection<TeacherSubject> TeacherSubject { get; set; }
        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}
