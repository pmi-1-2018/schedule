using System;
using System.Xml.Serialization;
using System.IO;
using schedule.Entities;
using System.Linq;
using System.Collections.Generic;

namespace schedule
{
    //class ClassRepo
    //{
    //    public static Class CreateClass(uint ClassId, uint ClassRoomId, uint ClassGroupId, uint ClassSubjectId,
    //                                    uint ClassTeacherId, DayOfWeek ClassDay, uint ClassNumber)
    //    {
    //        return new Class 
    //        {
    //            Id = ClassId,
    //            RoomId = ClassRoomId,
    //            GroupId = ClassGroupId,
    //            SubjectId = ClassSubjectId,
    //            TeacherId = ClassTeacherId,
    //            Day = ClassDay,
    //            Number = ClassNumber
    //        };
    //    }
    //    public static void UpdateClass(Class @class, uint? ClassId = null, uint? ClassRoomId = null,
    //                                    uint? ClassGroupId = null, uint? ClassSubjectId = null, 
    //                                    uint? ClassTeacherId = null, DayOfWeek? ClassDay = null, uint? ClassNumber = null)
    //    {
    //        @class.Id = ClassId ?? @class.Id;
    //        @class.RoomId = ClassRoomId ?? @class.RoomId;
    //        @class.GroupId = ClassGroupId ?? @class.GroupId;
    //        @class.SubjectId = ClassSubjectId ?? @class.SubjectId;
    //        @class.TeacherId = ClassTeacherId ?? @class.TeacherId;
    //        @class.Day = ClassDay ?? @class.Day;
    //        @class.Number = ClassNumber ?? @class.Number;
    //    }
    //    public static uint? GetClassId(Class @class)
    //    {
    //        return @class.Id;
    //    }
    //    public static uint? GetClassRoomId(Class @class)
    //    {
    //        return @class.RoomId;
    //    }
    //    public static uint? GetClassGroupId(Class @class)
    //    {
    //        return @class.GroupId;
    //    }
    //    public static uint? GetClassSubjectId(Class @class)
    //    {
    //        return @class.SubjectId;
    //    }
    //    public static uint? GetClassTeacheId(Class @class)
    //    {
    //        return @class.TeacherId;
    //    }
    //    public static uint? GetClassNumber(Class @class)
    //    {
    //        return @class.Number;
    //    }
    //    public static DayOfWeek? GetClassDay(Class @class)
    //    {
    //        return @class.Day;
    //    }
    //    public static void Serialize(string fileName, Class @class)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Class));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, @class);
    //        }
    //    }
    //    public static Class Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Class));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Class)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, Class[] classes)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Class[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, classes);
    //        }
    //    }
    //    public static Class[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Class[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Class[])serializer.Deserialize(fs);
    //        }
    //    }
    //}

    class ClassRepo
    {
        private readonly static ScheduleDbContext db;
        static ClassRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Classes CreateClass(long ClassId, long ClassRoomId, long ClassGroupId, long ClassSubjectId,
                                        long ClassTeacherId, DayOfWeek ClassDay, long ClassNumber)
        {
            return new Classes()
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
        public static Classes CreateClass(long ClassRoomId, long ClassGroupId, long ClassSubjectId,
                                long ClassTeacherId, DayOfWeek ClassDay, long ClassNumber)
        {
            return new Classes()
            {
                RoomId = ClassRoomId,
                GroupId = ClassGroupId,
                SubjectId = ClassSubjectId,
                TeacherId = ClassTeacherId,
                Day = ClassDay,
                Number = ClassNumber
            };
        }
        public static void UpdateClass(Classes @class, long ClassId = 0, long ClassRoomId = 0,
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
        public static long GetClassId(Classes @class)
        {
            return @class.Id;
        }
        public static long GetClassRoomId(Classes @class)
        {
            return @class.RoomId;
        }
        public static long GetClassGroupId(Classes @class)
        {
            return @class.GroupId;
        }
        public static long GetClassSubjectId(Classes @class)
        {
            return @class.SubjectId;
        }
        public static long GetClassTeacheId(Classes @class)
        {
            return @class.TeacherId;
        }
        public static long? GetClassNumber(Classes @class)
        {
            return @class.Number;
        }
        public static DayOfWeek? GetClassDay(Classes @class)
        {
            return @class.Day;
        }
        public static void Serialize(string fileName, Classes @class)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Classes));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, @class);
            }
        }
        public static Classes Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Classes));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Classes)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Classes[] classes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Classes[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, classes);
            }
        }
        public static Classes[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Classes[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Classes[])serializer.Deserialize(fs);
            }
        }
        
        public static void AddToDb(Classes @class)
        {
            db.Classes.Add(@class);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Classes @class)
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
        public static void UpdateInDb(Classes @class)
        {
            var classToUpdate = db.Classes.Where(c => c.Id == @class.Id).FirstOrDefault();
            if (classToUpdate != null)
            {
                db.Classes.Update(@class);
            }
        }
        public static List<Classes> GetClassesFromDb()
        {
            return db.Classes.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Classes.ToArray());
        }
    }
}