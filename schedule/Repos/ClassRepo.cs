using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule
{
    class ClassRepo
    {
        private readonly static ScheduleDbContext db;
        static ClassRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Class CreateClass(long ClassId, long ClassRoomId, long ClassGroupId, long ClassSubjectId,
                                        long ClassTeacherId, DayOfWeek ClassDay, long ClassNumber)
        {
            return new Class()
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
        public static Class CreateClass(long ClassRoomId, long ClassGroupId, long ClassSubjectId,
                                long ClassTeacherId, DayOfWeek ClassDay, long ClassNumber)
        {
            return new Class()
            {
                RoomId = ClassRoomId,
                GroupId = ClassGroupId,
                SubjectId = ClassSubjectId,
                TeacherId = ClassTeacherId,
                Day = ClassDay,
                Number = ClassNumber
            };
        }
        public static Class CreateClass(long ClassGroupId, long ClassSubjectId,
                                long ClassTeacherId)
        {
            return new Class()
            {
                GroupId = ClassGroupId,
                SubjectId = ClassSubjectId,
                TeacherId = ClassTeacherId,
            };
        }
        public static void UpdateClass(Class @class, long ClassId = 0, long ClassRoomId = 0,
                                        long ClassGroupId = 0, long ClassSubjectId = 0,
                                        long ClassTeacherId = 0, DayOfWeek? ClassDay = null, long? ClassNumber = null)
        {
            @class.Id = ClassId == 0 ? @class.Id : ClassId;
            @class.RoomId = ClassRoomId == 0 ? @class.RoomId : ClassRoomId;
            @class.GroupId = ClassGroupId == 0 ? @class.GroupId : ClassGroupId;
            @class.SubjectId = ClassSubjectId == 0 ? @class.SubjectId : ClassSubjectId;
            @class.TeacherId = ClassTeacherId == 0 ? @class.TeacherId : ClassTeacherId;
            @class.Day = ClassDay ?? @class.Day;
            @class.Number = ClassNumber ?? @class.Number;
        }
        public static long GetClassId(Class @class)
        {
            return @class.Id;
        }
        public static long GetClassRoomId(Class @class)
        {
            return @class.RoomId;
        }
        public static long GetClassGroupId(Class @class)
        {
            return @class.GroupId;
        }
        public static long GetClassSubjectId(Class @class)
        {
            return @class.SubjectId;
        }
        public static long GetClassTeacheId(Class @class)
        {
            return @class.TeacherId;
        }
        public static long? GetClassNumber(Class @class)
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
        
        public static void AddToDb(Class @class)
        {
            db.Classes.Add(@class);
            db.SaveChanges();
        }
        public static void AddToDb(List<Class> classes)
        {
            db.Classes.AddRange(classes);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Class @class)
        {
            if(db.Classes.Contains(@class))
            {
                db.Classes.Remove(@class);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var @class = db.Classes.Where(c => c.Id == id).FirstOrDefault();
            if(@class != null)
            {
                db.Classes.Remove(@class);
            }
        }
        public static void UpdateInDb(Class @class)
        {
            var classToUpdate = db.Classes.Where(c => c.Id == @class.Id).FirstOrDefault();
            if (classToUpdate != null)
            {
                db.Classes.Update(@class);
            }
        }
        public static List<Class> GetClassesFromDb()
        {
            return db.Classes.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Classes.ToArray());
        }
    }
}