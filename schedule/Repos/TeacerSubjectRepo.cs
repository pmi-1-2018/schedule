using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class TeacherSubjectRepo
    //{
    //    public static TeacherSubject CreateTeacherSubject(uint TeacherSubjectTeacherId, uint TeacherSubjectSubjectId,
    //                                                        uint TeacherSubjectCount)
    //    {
    //        return new TeacherSubject
    //        {
    //            TeacherId = TeacherSubjectTeacherId,
    //            SubjectId = TeacherSubjectSubjectId,
    //            Count = TeacherSubjectCount
    //        };
    //    }
    //    public static void UpdateTeacherSubject(TeacherSubject teacherSubject, uint? TeacherSubjectTeacherId,
    //                                                uint? TeacherSubjectSubjectId, uint? TeacherSubjectCount)
    //    {
    //        teacherSubject.TeacherId = TeacherSubjectTeacherId ?? teacherSubject.TeacherId;
    //        teacherSubject.SubjectId = TeacherSubjectSubjectId ?? teacherSubject.SubjectId;
    //        teacherSubject.Count = TeacherSubjectCount ?? teacherSubject.Count;
    //    }
    //    public static uint? GetTeacherSubjectTeacherId(TeacherSubject teacherSubject)
    //    {
    //        return teacherSubject.TeacherId;
    //    }
    //    public static uint? GetTeacherSubjectSubjectId(TeacherSubject teacherSubject)
    //    {
    //        return teacherSubject.SubjectId;
    //    }
    //    public static uint? GetTeacherSubjectCount(TeacherSubject teacherSubject)
    //    {
    //        return teacherSubject.Count;
    //    }
    //    public static void Serialize(string fileName, TeacherSubject teacherSubject)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, teacherSubject);
    //        }
    //    }
    //    public static TeacherSubject Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (TeacherSubject)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, TeacherSubject[] teacherSubjects)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, teacherSubjects);
    //        }
    //    }
    //    public static TeacherSubject[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (TeacherSubject[])serializer.Deserialize(fs);
    //        }
    //    }
    //}

    class TeacherSubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static TeacherSubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static TeacherSubjects CreateTeacherSubject(long id, long TeacherSubjectTeacherId, long TeacherSubjectSubjectId,
                                                            long TeacherSubjectCount)
        {
            return new TeacherSubjects()
            {
                Id = id,
                TeacherId = TeacherSubjectTeacherId,
                SubjectId = TeacherSubjectSubjectId,
                Count = TeacherSubjectCount
            };
        }
        public static TeacherSubjects CreateTeacherSubject(long TeacherSubjectTeacherId, long TeacherSubjectSubjectId,
                                                            long TeacherSubjectCount)
        {
            return new TeacherSubjects()
            {
                TeacherId = TeacherSubjectTeacherId,
                SubjectId = TeacherSubjectSubjectId,
                Count = TeacherSubjectCount
            };
        }
        public static void UpdateTeacherSubject(TeacherSubjects teacherSubject, long TeacherSubjectId = 0, 
                                                long TeacherSubjectTeacherId = 0, long TeacherSubjectSubjectId = 0,
                                                long TeacherSubjectCount = 0)
        {
            teacherSubject.Id = TeacherSubjectId == 0 ? teacherSubject.Id : TeacherSubjectId;
            teacherSubject.TeacherId = TeacherSubjectTeacherId == 0 ? teacherSubject.TeacherId : TeacherSubjectTeacherId;
            teacherSubject.SubjectId = TeacherSubjectSubjectId == 0 ? teacherSubject.SubjectId : TeacherSubjectSubjectId;
            teacherSubject.Count = TeacherSubjectCount == 0 ? teacherSubject.Count : TeacherSubjectCount;
        }
        public static long GetTeacherSubjectId(TeacherSubjects teacherSubject)
        {
            return teacherSubject.Id;
        }
        public static long? GetTeacherSubjectTeacherId(TeacherSubjects teacherSubject)
        {
            return teacherSubject.TeacherId;
        }
        public static long? GetTeacherSubjectSubjectId(TeacherSubjects teacherSubject)
        {
            return teacherSubject.SubjectId;
        }
        public static long? GetTeacherSubjectCount(TeacherSubjects teacherSubject)
        {
            return teacherSubject.Count;
        }
        public static void Serialize(string fileName, TeacherSubjects teacherSubject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacherSubject);
            }
        }
        public static TeacherSubjects Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (TeacherSubjects)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, TeacherSubjects[] teacherSubjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacherSubjects);
            }
        }
        public static TeacherSubjects[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TeacherSubjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (TeacherSubjects[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(TeacherSubjects teacherSubject)
        {
            db.TeacherSubjects.Add(teacherSubject);
            db.SaveChanges();
        }
        public static void RemoveFromDb(TeacherSubjects teacherSubjects)
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
        public static void UpdateInDb(TeacherSubjects teacherSubject)
        {
            var teacherSubjectToUpdate = db.TeacherSubjects.Where(s => s.Id == teacherSubject.Id).FirstOrDefault();
            if (teacherSubjectToUpdate != null)
            {
                db.TeacherSubjects.Update(teacherSubject);
            }
        }
        public static List<TeacherSubjects> GetTeacherSubjectsFromDb()
        {
            return db.TeacherSubjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.TeacherSubjects.ToArray());
        }
    }
}
