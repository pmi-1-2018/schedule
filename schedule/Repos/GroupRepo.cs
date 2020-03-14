using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class GroupRepo
    {
        public static Group CreateGroup(uint GroupId, string GroupName, uint GroupSize)
        {
            return new Group { Id = GroupId, Name = GroupName, Size = GroupSize };
        }
        public static void UpdateGroup(Group group, uint? GroupId = null, string GroupName = null,
                                            uint? GroupSize = null)
        {
            group.Id = GroupId ?? group.Id;
            group.Name = GroupName ?? group.Name;
            group.Size = GroupSize ?? group.Size;
        }
        public static uint? GetGroupId(Group group)
        {
            return group.Id;
        }
        public static string GetGroupName(Group group)
        {
            return group.Name;
        }
        public static uint? GetGroupSize(Group group)
        {
            return group.Size;
        }
        public static void Serialize(string fileName, Group group)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, group);
            }
        }
        public static Group Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Group)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Group[] groups)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groups);
            }
        }
        public static Group[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Group[])serializer.Deserialize(fs);
            }
        }

    }
}
