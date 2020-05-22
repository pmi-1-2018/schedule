using System.Xml.Serialization;
using System.IO;
using schedule.Enums;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule.Repos
{
    class SubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static SubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Subject CreateSubject(long SubjectId, string SubjectName, ClassType? SubjectType)
        {
            return new Subject { Id = SubjectId, Name = SubjectName, Type = SubjectType };
        }
        public static Subject CreateSubject(string SubjectName, ClassType SubjectType)
        {
            return new Subject { Name = SubjectName, Type = SubjectType };
        }
        public static void UpdateSubject(Subject subject, long SubjectId = 0, string SubjectName = null,
                                            ClassType? SubjectType = null)
        {
            subject.Id = SubjectId == 0 ? subject.Id : SubjectId;
            subject.Name = SubjectName ?? subject.Name;
            subject.Type = SubjectType ?? subject.Type;
        }
        public static long GetSubjectId(Subject subject)
        {
            return subject.Id;
        }
        public static string GetSubjectName(Subject subject)
        {
            return subject.Name;
        }
        public static ClassType? GetSubjectType(Subject subject)
        {
            return subject.Type;
        }
        public static void Serialize(string fileName, Subject subject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, subject);
            }
        }
        public static Subject Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Subject)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Subject[] subjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, subjects);
            }
        }
        public static Subject[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Subject[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
        }
        public static void AddToDb(List<Subject> subjects)
        {
            db.Subjects.AddRange(subjects);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Subject subject)
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
        public static void UpdateInDb(Subject subject)
        {
            var subjectToUpdate = db.Subjects.Where(s => s.Id == subject.Id).FirstOrDefault();
            if (subjectToUpdate != null)
            {
                db.Subjects.Update(subject);
            }
        }
        public static List<Subject> GetSubjectsFromDb()
        {
            return db.Subjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            var subjectsFromDb = db.Subjects.ToArray();
            var subjectsToSerialize = new Subject[subjectsFromDb.Length];
            for (int i = 0; i < subjectsToSerialize.Length; i++)
            {
                subjectsToSerialize[i] = CreateSubject(subjectsFromDb[i].Id, subjectsFromDb[i].Name, subjectsFromDb[i].Type);
            }
            SerializeArray(filename, subjectsToSerialize);
        }
    }
}
