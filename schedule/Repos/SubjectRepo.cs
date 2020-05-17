using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using schedule.Enums;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class SubjectRepo
    //{
    //    public static Subject CreateSubject(uint SubjectId, string SubjectName, ClassType SubjectType)
    //    {
    //        return new Subject { Id = SubjectId, Name = SubjectName, Type = SubjectType };
    //    }
    //    public static void UpdateSubject(Subject subject, uint? SubjectId = null, string SubjectName = null,
    //                                        ClassType? SubjectType = null)
    //    {
    //        subject.Id = SubjectId ?? subject.Id;
    //        subject.Name = SubjectName ?? subject.Name;
    //        subject.Type = SubjectType ?? subject.Type;
    //    }
    //    public static uint? GetSubjectId(Subject subject)
    //    {
    //        return subject.Id;
    //    }
    //    public static string GetSubjectName(Subject subject)
    //    {
    //        return subject.Name;
    //    }
    //    public static ClassType? GetSubjectType(Subject subject)
    //    {
    //        return subject.Type;
    //    }
    //    public static void Serialize(string fileName, Subject subject)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Subject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, subject);
    //        }
    //    }
    //    public static Subject Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Subject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Subject)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, Subject[] subjects)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Subject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, subjects);
    //        }
    //    }
    //    public static Subject[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Subject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Subject[])serializer.Deserialize(fs);
    //        }
    //    }
    //}


    class SubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static SubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Subjects CreateSubject(long SubjectId, string SubjectName, ClassType SubjectType)
        {
            return new Subjects { Id = SubjectId, Name = SubjectName, Type = SubjectType };
        }
        public static Subjects CreateSubject(string SubjectName, ClassType SubjectType)
        {
            return new Subjects { Name = SubjectName, Type = SubjectType };
        }
        public static void UpdateSubject(Subjects subject, long SubjectId = 0, string SubjectName = null,
                                            ClassType? SubjectType = null)
        {
            subject.Id = SubjectId == 0 ? subject.Id : SubjectId;
            subject.Name = SubjectName ?? subject.Name;
            subject.Type = SubjectType ?? subject.Type;
        }
        public static long GetSubjectId(Subjects subject)
        {
            return subject.Id;
        }
        public static string GetSubjectName(Subjects subject)
        {
            return subject.Name;
        }
        public static ClassType? GetSubjectType(Subjects subject)
        {
            return subject.Type;
        }
        public static void Serialize(string fileName, Subjects subject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, subject);
            }
        }
        public static Subjects Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Subjects)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Subjects[] subjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, subjects);
            }
        }
        public static Subjects[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Subjects[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Subjects subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Subjects subject)
        {
            if (db.Subjects.Contains(subject))
            {
                db.Subjects.Remove(subject);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var subject = db.Subjects.Where(s => s.Id == id).FirstOrDefault();
            if (subject != null)
            {
                db.Subjects.Remove(subject);
            }
        }
        public static void UpdateInDb(Subjects subject)
        {
            var subjectToUpdate = db.Subjects.Where(s => s.Id == subject.Id).FirstOrDefault();
            if (subjectToUpdate != null)
            {
                db.Subjects.Update(subject);
            }
        }
        public static List<Subjects> GetSubjectsFromDb()
        {
            return db.Subjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Subjects.ToArray());
        }
    }
}
