using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class Group_SubjectRepo
    {
        public static Group_Subject CreateGroup_Subject(uint Group_SubjectGroupId, uint Group_SubjectSubjectId,
                                                        uint Group_SubjectCount)
        {
            return new Group_Subject
            {
                GroupId = Group_SubjectGroupId,
                SubjectId = Group_SubjectSubjectId,
                Count = Group_SubjectCount
            };
        }
        public static void UpdateGroup_Subject(Group_Subject group_subject, uint? Group_SubjectGroupId,
                                                uint? Group_SubjectSubjectId, uint? Group_SubjectCount)
        {
            group_subject.GroupId = Group_SubjectGroupId ?? group_subject.GroupId;
            group_subject.SubjectId = Group_SubjectSubjectId ?? group_subject.SubjectId;
            group_subject.Count = Group_SubjectCount ?? group_subject.Count;
        }
        public static uint? GetGroup_SubjectGroupId(Group_Subject group_subject)
        {
            return group_subject.GroupId;
        }
        public static uint? GetGroup_SubjectSubjectId(Group_Subject group_subject)
        {
            return group_subject.SubjectId;
        }
        public static uint? GetGroup_SubjectCount(Group_Subject group_subject)
        {
            return group_subject.Count;
        }
        public static void Serialize(string fileName, Group_Subject group_subject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group_Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, group_subject);
            }
        }
        public static Group_Subject Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group_Subject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Group_Subject)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Group_Subject[] group_subjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group_Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, group_subjects);
            }
        }
        public static Group_Subject[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group_Subject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Group_Subject[])serializer.Deserialize(fs);
            }
        }
    }
}
