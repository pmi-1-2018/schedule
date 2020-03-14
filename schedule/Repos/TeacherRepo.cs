using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class TeacherRepo
    {
        public static Teacher CreateTeacher(uint TeacherId, string TeacherFullName)
        {
            return new Teacher { Id = TeacherId, FullName = TeacherFullName };
        }
        public static void UpdateTeacher(Teacher teacher, uint? TeacherId = null, string TeacherFullName = null)
        {
            teacher.Id = TeacherId ?? teacher.Id;
            teacher.FullName = TeacherFullName ?? teacher.FullName;
        }
        public static uint? GetTeacherId(Teacher teacher)
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
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacher);
            }
        }
        public static Teacher Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
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

    }
}
