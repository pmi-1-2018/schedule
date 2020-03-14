using System;
using System.Xml.Serialization;
using System.IO;
using schedule.Entities;

namespace schedule
{
    class ClassRepo
    {
        public static Class CreateClass(uint ClassId, uint ClassRoomId, uint ClassGroupId, uint ClassSubjectId,
                                        uint ClassTeacherId, DayOfWeek ClassDay, uint ClassNumber)
        {
            return new Class 
            {
                Id = ClassId,
                RoomId = ClassRoomId,
                GroupId = ClassGroupId,
                SubjectId = ClassSubjectId,
                TeacherId = ClassTeacherId,
                Day = ClassDay,
                Number = ClassNumber
            };
        }
        public static void UpdateClass(Class @class, uint? ClassId = null, uint? ClassRoomId = null,
                                        uint? ClassGroupId = null, uint? ClassSubjectId = null, 
                                        uint? ClassTeacherId = null, DayOfWeek? ClassDay = null, uint? ClassNumber = null)
        {
            @class.Id = ClassId ?? @class.Id;
            @class.RoomId = ClassRoomId ?? @class.RoomId;
            @class.GroupId = ClassGroupId ?? @class.GroupId;
            @class.SubjectId = ClassSubjectId ?? @class.SubjectId;
            @class.TeacherId = ClassTeacherId ?? @class.TeacherId;
            @class.Day = ClassDay ?? @class.Day;
            @class.Number = ClassNumber ?? @class.Number;
        }
        public static uint? GetClassId(Class @class)
        {
            return @class.Id;
        }
        public static uint? GetClassRoomId(Class @class)
        {
            return @class.RoomId;
        }
        public static uint? GetClassGroupId(Class @class)
        {
            return @class.GroupId;
        }
        public static uint? GetClassSubjectId(Class @class)
        {
            return @class.SubjectId;
        }
        public static uint? GetClassTeacheId(Class @class)
        {
            return @class.TeacherId;
        }
        public static uint? GetClassNumber(Class @class)
        {
            return @class.Number;
        }
        public static DayOfWeek? GetClassDay(Class @class)
        {
            return @class.Day;
        }
        public static void Serialize(string fileName, Class @class)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, @class);
            }
        }
        public static Class Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Class)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Class[] classes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, classes);
            }
        }
        public static Class[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Class[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Class[])serializer.Deserialize(fs);
            }
        }
    }
}