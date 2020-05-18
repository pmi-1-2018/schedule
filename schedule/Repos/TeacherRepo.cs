using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule.Repos
{
    class TeacherRepo
    {
        private readonly static ScheduleDbContext db;
        static TeacherRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Teacher CreateTeacher(long TeacherId, string TeacherFullName)
        {
            return new Teacher { Id = TeacherId, FullName = TeacherFullName };
        }
        public static Teacher CreateTeacher(string TeacherFullName)
        {
            return new Teacher {FullName = TeacherFullName };
        }
        public static void UpdateTeacher(Teacher teacher, long TeacherId = 0, string TeacherFullName = null)
        {
            teacher.Id = TeacherId == 0 ? teacher.Id : TeacherId;
            teacher.FullName = TeacherFullName ?? teacher.FullName;
        }
        public static long GetTeacherId(Teacher teacher)
        {
            return teacher.Id;
        }
        public static string GetTeacherFullName(Teacher teacher)
        {
            return teacher.FullName;
        }
        public static void Serialize(string fileName, Teacher teacher)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, teacher);
            }
        }
        public static Teacher Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return (Teacher)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Teacher[] teachers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teachers);
            }
        }
        public static Teacher[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Teacher[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Teacher teacher)
        {
            if (db.Teachers.Contains(teacher))
            {
                db.Teachers.Remove(teacher);
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
        public static void UpdateInDb(Teacher teacher)
        {
            var TeacherToUpdate = db.Teachers.Where(t => t.Id == teacher.Id).FirstOrDefault();
            if (TeacherToUpdate != null)
            {
                db.Teachers.Update(teacher);
            }
        }
        public static List<Teacher> GetTeachersFromDb()
        {
            return db.Teachers.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Teachers.ToArray());
        }

    }
}
