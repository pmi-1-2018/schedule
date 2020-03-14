using System;

namespace schedule.Entities
{
    [Serializable]
    public class Subject
    {
        public uint? Id { get; set; }
        public string Name { get; set; }
        public ClassType? Type { get; set; }

        public Subject(){}
        public override string ToString()
        {
            return Name;
        }
    }
}
