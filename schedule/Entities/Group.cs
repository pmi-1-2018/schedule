using System;
using System.Collections.Generic;

namespace schedule.Entities
{
    [Serializable]
    public partial class Group
    {
        public Group()
        {
            Class = new HashSet<Class>();
            GroupSubject = new HashSet<GroupSubject>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<GroupSubject> GroupSubject { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
