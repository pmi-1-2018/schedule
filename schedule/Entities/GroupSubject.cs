using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace schedule.Entities
{
    [Serializable]
    public partial class GroupSubject
    {
        public long Id { get; set; }
        public long? GroupId { get; set; }
        public long? SubjectId { get; set; }
        public long? Count { get; set; }

        [XmlIgnore]
        public virtual Group Group { get; set; }
        [XmlIgnore]
        public virtual Subject Subject { get; set; }
        public GroupSubject()
        {

        }
    }
}
