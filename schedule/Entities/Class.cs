using System;

namespace schedule.Entities
{
    [Serializable]
    public class Class
    {
        public uint? Id { get; set; }
        public uint? RoomId { get; set; }
        public uint? GroupId { get; set; }
        public uint? SubjectId { get; set; }
        public uint? TeacherId { get; set; }
        public DayOfWeek? Day { get; set; }
        public uint? Number { get; set; }
        
        public Class(){}
    }
}
