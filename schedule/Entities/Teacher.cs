using System;

namespace schedule.Entities
{
    [Serializable]
    public class Teacher
    {
        public uint? Id { get; set; }
        public string FullName { get; set; }

        public Teacher(){}
        public override string ToString()
        {
            return FullName;
        }
    }
}
