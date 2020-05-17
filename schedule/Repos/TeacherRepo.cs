using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class TeacherRepo
    //{
    //    public static Teacher CreateTeacher(uint TeacherId, string TeacherFullName)
    //    {
    //        return new Teacher { Id = TeacherId, FullName = TeacherFullName };
    //    }
    //    public static void UpdateTeacher(Teacher teacher, uint? TeacherId = null, string TeacherFullName = null)
    //    {
    //        teacher.Id = TeacherId ?? teacher.Id;
    //        teacher.FullName = TeacherFullName ?? teacher.FullName;
    //    }
    //    public static uint? GetTeacherId(Teacher teacher)
    //    {
    //        return teacher.Id;
    //    }
    //    public static string GetTeacherFullName(Teacher teacher)
    //    {
    //        return teacher.FullName;
    //    }
    //    public static void Serialize(string fileName, Teacher teacher)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
    //        using (FileStream fs = new FileStream(fileName, FileMode.Create))
    //        {
    //            serializer.Serialize(fs, teacher);
    //        }
    //    }
    //    public static Teacher Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
    //        using (FileStream fs = new FileStream(fileName, FileMode.Open))
    //        {
    //            return (Teacher)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, Teacher[] teachers)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Teacher[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, teachers);
    //        }
    //    }
    //    public static Teacher[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Teacher[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Teacher[])serializer.Deserialize(fs);
    //        }
    //    }

    //}


    class TeacherRepo
    {
        private readonly static ScheduleDbContext db;
        static TeacherRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Teachers CreateTeacher(long TeacherId, string TeacherFullName)
        {
            return new Teachers { Id = TeacherId, FullName = TeacherFullName };
        }
        public static Teachers CreateTeacher(string TeacherFullName)
        {
            return new Teachers {FullName = TeacherFullName };
        }
        public static void UpdateTeacher(Teachers teacher, long TeacherId = 0, string TeacherFullName = null)
        {
            teacher.Id = TeacherId == 0 ? teacher.Id : TeacherId;
            teacher.FullName = TeacherFullName ?? teacher.FullName;
        }
        public static long GetTeacherId(Teachers teacher)
        {
            return teacher.Id;
        }
        public static string GetTeacherFullName(Teachers teacher)
        {
            return teacher.FullName;
        }
        public static void Serialize(string fileName, Teachers teacher)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teachers));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, teacher);
            }
        }
        public static Teachers Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teachers));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (Teachers)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Teachers[] teachers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teachers[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teachers);
            }
        }
        public static Teachers[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teachers[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Teachers[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Teachers Teacher)
        {
            db.Teachers.Add(Teacher);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Teachers Teachers)
        {
            if (db.Teachers.Contains(Teachers))
            {
                db.Teachers.Remove(Teachers);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var Teacher = db.Teachers.Where(t => t.Id == id).FirstOrDefault();
            if (Teacher != null)
            {
                db.Teachers.Remove(Teacher);
            }
        }
        public static void UpdateInDb(Teachers Teacher)
        {
            var TeacherToUpdate = db.Teachers.Where(t => t.Id == Teacher.Id).FirstOrDefault();
            if (TeacherToUpdate != null)
            {
                db.Teachers.Update(Teacher);
            }
        }
        public static List<Teachers> GetTeachersFromDb()
        {
            return db.Teachers.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Teachers.ToArray());
        }

    }
}
