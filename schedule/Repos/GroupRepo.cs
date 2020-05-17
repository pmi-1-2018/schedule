using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule.Repos
{
    class GroupRepo
    {
        private readonly static ScheduleDbContext db;
        static GroupRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Group CreateGroup(long GroupId, string GroupName, long GroupSize)
        {
            return new Group { Id = GroupId, Name = GroupName, Size = GroupSize };
        }
        public static Group CreateGroup(string GroupName, long GroupSize)
        {
            return new Group {Name = GroupName, Size = GroupSize };
        }
        public static void UpdateGroup(Group group, long GroupId = 0, string GroupName = null,
                                            long? GroupSize = null)
        {
            group.Id = GroupId == 0 ? group.Id : GroupId;
            group.Name = GroupName ?? group.Name;
            group.Size = GroupSize ?? group.Size;
        }
        public static long GetGroupId(Group group)
        {
            return group.Id;
        }
        public static string GetGroupName(Group group)
        {
            return group.Name;
        }
        public static long? GetGroupSize(Group group)
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

        public static void AddToDb(Group group)
        {
            db.Groups.Add(group);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Group group)
        {
            if (db.Groups.Contains(group))
            {
                db.Groups.Remove(group);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var group = db.Groups.Where(g => g.Id == id).FirstOrDefault();
            if (group != null)
            {
                db.Groups.Remove(group);
            }
        }
        public static void UpdateInDb(Group group)
        {
            var groupToUpdate = db.Groups.Where(g => g.Id == group.Id).FirstOrDefault();
            if (groupToUpdate != null)
            {
                db.Groups.Update(group);
            }
        }
        public static List<Group> GetGroupsFromDb()
        {
            return db.Groups.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Groups.ToArray());
        }

    }
}
