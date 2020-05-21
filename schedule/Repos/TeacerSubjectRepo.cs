using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule.Repos
{
    class TeacherSubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static TeacherSubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static TeacherSubject CreateTeacherSubject(long id, long? TeacherSubjectTeacherId, long? TeacherSubjectSubjectId,
                                                            long? TeacherSubjectCount)
        {
            return new TeacherSubject()
            {
                Id = id,
                TeacherId = TeacherSubjectTeacherId,
                SubjectId = TeacherSubjectSubjectId,
                Count = TeacherSubjectCount
            };
        }
        public static TeacherSubject CreateTeacherSubject(long TeacherSubjectTeacherId, long TeacherSubjectSubjectId,
                                                            long TeacherSubjectCount)
        {
            return new TeacherSubject()
            {
                TeacherId = TeacherSubjectTeacherId,
                SubjectId = TeacherSubjectSubjectId,
                Count = TeacherSubjectCount
            };
        }
        public static void UpdateTeacherSubject(TeacherSubject teacherSubject, long TeacherSubjectId = 0, 
                                                long TeacherSubjectTeacherId = 0, long TeacherSubjectSubjectId = 0,
                                                long TeacherSubjectCount = 0)
        {
            teacherSubject.Id = TeacherSubjectId == 0 ? teacherSubject.Id : TeacherSubjectId;
            teacherSubject.TeacherId = TeacherSubjectTeacherId == 0 ? teacherSubject.TeacherId : TeacherSubjectTeacherId;
            teacherSubject.SubjectId = TeacherSubjectSubjectId == 0 ? teacherSubject.SubjectId : TeacherSubjectSubjectId;
            teacherSubject.Count = TeacherSubjectCount == 0 ? teacherSubject.Count : TeacherSubjectCount;
        }
        public static long GetTeacherSubjectId(TeacherSubject teacherSubject)
        {
            return teacherSubject.Id;
        }
        public static long? GetTeacherSubjectTeacherId(TeacherSubject teacherSubject)
        {
            return teacherSubject.TeacherId;
        }
        public static long? GetTeacherSubjectSubjectId(TeacherSubject teacherSubject)
        {
            return teacherSubject.SubjectId;
        }
        public static long? GetTeacherSubjectCount(TeacherSubject teacherSubject)
        {
            return teacherSubject.Count;
        }
        public static void Serialize(string fileName, TeacherSubject teacherSubject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacherSubject);
            }
        }
        public static TeacherSubject Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (TeacherSubject)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, TeacherSubject[] teacherSubjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacherSubjects);
            }
        }
        public static TeacherSubject[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (TeacherSubject[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(TeacherSubject teacherSubject)
        {
            db.TeacherSubjects.Add(teacherSubject);
            db.SaveChanges();
        }
        public static void AddToDb(List<TeacherSubject> teacherSubjects)
        {
            db.TeacherSubjects.AddRange(teacherSubjects);
            db.SaveChanges();
        }
        public static void RemoveFromDb(TeacherSubject teacherSubjects)
        {
            if (db.TeacherSubjects.Contains(teacherSubjects))
            {
                db.TeacherSubjects.Remove(teacherSubjects);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var teacherSubject = db.TeacherSubjects.Where(s => s.Id == id).FirstOrDefault();
            if (teacherSubject != null)
            {
                db.TeacherSubjects.Remove(teacherSubject);
            }
        }
        public static void UpdateInDb(TeacherSubject teacherSubject)
        {
            var teacherSubjectToUpdate = db.TeacherSubjects.Where(s => s.Id == teacherSubject.Id).FirstOrDefault();
            if (teacherSubjectToUpdate != null)
            {
                db.TeacherSubjects.Update(teacherSubject);
            }
        }
        public static List<TeacherSubject> GetTeacherSubjectsFromDb()
        {
            return db.TeacherSubjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            var teacherSubjectsFromDb = db.TeacherSubjects.ToArray();
            var teacherSubjectsToSerialize = new TeacherSubject[teacherSubjectsFromDb.Length];
            for (int i = 0; i < teacherSubjectsToSerialize.Length; i++)
            {
                teacherSubjectsToSerialize[i] = CreateTeacherSubject(teacherSubjectsFromDb[i].Id, teacherSubjectsFromDb[i].TeacherId, teacherSubjectsFromDb[i].SubjectId, teacherSubjectsFromDb[i].Count);
            }
            SerializeArray(filename, teacherSubjectsToSerialize);
        }
    }
}
