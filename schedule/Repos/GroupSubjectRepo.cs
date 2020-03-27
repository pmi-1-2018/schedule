using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class GroupSubjectRepo
    {
        public static GroupSubject CreateGroupSubject(uint GroupSubjectGroupId, uint GroupSubjectSubjectId,
                                                        uint GroupSubjectCount)
        {
            return new GroupSubject
            {
                GroupId = GroupSubjectGroupId,
                SubjectId = GroupSubjectSubjectId,
                Count = GroupSubjectCount
            };
        }
        public static void UpdateGroupSubject(GroupSubject groupSubject, uint? GroupSubjectGroupId,
                                                uint? GroupSubjectSubjectId, uint? GroupSubjectCount)
        {
            groupSubject.GroupId = GroupSubjectGroupId ?? groupSubject.GroupId;
            groupSubject.SubjectId = GroupSubjectSubjectId ?? groupSubject.SubjectId;
            groupSubject.Count = GroupSubjectCount ?? groupSubject.Count;
        }
        public static uint? GetGroupSubjectGroupId(GroupSubject groupSubject)
        {
            return groupSubject.GroupId;
        }
        public static uint? GetGroupSubjectSubjectId(GroupSubject groupSubject)
        {
            return groupSubject.SubjectId;
        }
        public static uint? GetGroupSubjectCount(GroupSubject groupSubject)
        {
            return groupSubject.Count;
        }
        public static void Serialize(string fileName, GroupSubject groupSubject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groupSubject);
            }
        }
        public static GroupSubject Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (GroupSubject)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, GroupSubject[] groupSubjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groupSubjects);
            }
        }
        public static GroupSubject[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (GroupSubject[])serializer.Deserialize(fs);
            }
        }
    }
}
