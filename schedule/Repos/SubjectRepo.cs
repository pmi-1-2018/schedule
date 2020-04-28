using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class SubjectRepo
    {
        public static Subject CreateSubject(uint SubjectId, string SubjectName, ClassType SubjectType)
        {
            return new Subject { Id = SubjectId, Name = SubjectName, Type = SubjectType };
        }
        public static void UpdateSubject(Subject subject, uint? SubjectId = null, string SubjectName = null,
                                            ClassType? SubjectType = null)
        {
            subject.Id = SubjectId ?? subject.Id;
            subject.Name = SubjectName ?? subject.Name;
            subject.Type = SubjectType ?? subject.Type;
        }
        public static uint? GetSubjectId(Subject subject)
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
    }
}
