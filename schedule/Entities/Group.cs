using System;

namespace schedule.Entities
{
    [Serializable]
    public class Group
    {
        public uint? Id { get; set; }
        public string Name { get; set; }
        public uint? Size { get; set; }

        public Group(){}
        public override string ToString()
        {
            return Name;
        }
    }
}
