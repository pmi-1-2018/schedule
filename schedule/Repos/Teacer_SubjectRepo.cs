using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class Teacher_SubjectRepo
    {
        public static Teacher_Subject CreateTeacher_Subject(uint Teacher_SubjectTeacherId, uint Teacher_SubjectSubjectId,
                                                            uint Teacher_SubjectCount)
        {
            return new Teacher_Subject
            {
                TeacherId = Teacher_SubjectTeacherId,
                SubjectId = Teacher_SubjectSubjectId,
                Count = Teacher_SubjectCount
            };
        }
        public static void UpdateTeacher_Subject(Teacher_Subject teacher_subject, uint? Teacher_SubjectTeacherId,
                                                    uint? Teacher_SubjectSubjectId, uint? Teacher_SubjectCount)
        {
            teacher_subject.TeacherId = Teacher_SubjectTeacherId ?? teacher_subject.TeacherId;
            teacher_subject.SubjectId = Teacher_SubjectSubjectId ?? teacher_subject.SubjectId;
            teacher_subject.Count = Teacher_SubjectCount ?? teacher_subject.Count;
        }
        public static uint? GetTeacher_SubjectTeacherId(Teacher_Subject teacher_subject)
        {
            return teacher_subject.TeacherId;
        }
        public static uint? GetTeacher_SubjectSubjectId(Teacher_Subject teacher_subject)
        {
            return teacher_subject.SubjectId;
        }
        public static uint? GetTeacher_SubjectCount(Teacher_Subject teacher_subject)
        {
            return teacher_subject.Count;
        }
        public static void Serialize(string fileName, Teacher_Subject teacher_subject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher_Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacher_subject);
            }
        }
        public static Teacher_Subject Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher_Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Teacher_Subject)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Teacher_Subject[] teacher_subjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher_Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, teacher_subjects);
            }
        }
        public static Teacher_Subject[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Teacher_Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Teacher_Subject[])serializer.Deserialize(fs);
            }
        }
    }
}
