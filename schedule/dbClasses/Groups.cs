using System;
using System.Collections.Generic;

namespace schedule
{
    [Serializable]
    public partial class Groups
    {
        public Groups()
        {
            Classes = new HashSet<Classes>();
            GroupSubjects = new HashSet<GroupSubjects>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<GroupSubjects> GroupSubjects { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
