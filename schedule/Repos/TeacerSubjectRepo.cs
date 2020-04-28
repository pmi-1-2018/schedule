using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class TeacherSubjectRepo
    {
        public static TeacherSubject CreateTeacherSubject(uint TeacherSubjectTeacherId, uint TeacherSubjectSubjectId,
                                                            uint TeacherSubjectCount)
        {
            return new TeacherSubject
            {
                TeacherId = TeacherSubjectTeacherId,
                SubjectId = TeacherSubjectSubjectId,
                Count = TeacherSubjectCount
            };
        }
        public static void UpdateTeacherSubject(TeacherSubject teacherSubject, uint? TeacherSubjectTeacherId,
                                                    uint? TeacherSubjectSubjectId, uint? TeacherSubjectCount)
        {
            teacherSubject.TeacherId = TeacherSubjectTeacherId ?? teacherSubject.TeacherId;
            teacherSubject.SubjectId = TeacherSubjectSubjectId ?? teacherSubject.SubjectId;
            teacherSubject.Count = TeacherSubjectCount ?? teacherSubject.Count;
        }
        public static uint? GetTeacherSubjectTeacherId(TeacherSubject teacherSubject)
        {
            return teacherSubject.TeacherId;
        }
        public static uint? GetTeacherSubjectSubjectId(TeacherSubject teacherSubject)
        {
            return teacherSubject.SubjectId;
        }
        public static uint? GetTeacherSubjectCount(TeacherSubject teacherSubject)
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
    }
}
