using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class GroupRepo
    //{
    //    public static Group CreateGroup(uint GroupId, string GroupName, uint GroupSize)
    //    {
    //        return new Group { Id = GroupId, Name = GroupName, Size = GroupSize };
    //    }
    //    public static void UpdateGroup(Group group, uint? GroupId = null, string GroupName = null,
    //                                        uint? GroupSize = null)
    //    {
    //        group.Id = GroupId ?? group.Id;
    //        group.Name = GroupName ?? group.Name;
    //        group.Size = GroupSize ?? group.Size;
    //    }
    //    public static uint? GetGroupId(Group group)
    //    {
    //        return group.Id;
    //    }
    //    public static string GetGroupName(Group group)
    //    {
    //        return group.Name;
    //    }
    //    public static uint? GetGroupSize(Group group)
    //    {
    //        return group.Size;
    //    }
    //    public static void Serialize(string fileName, Group group)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Group));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, group);
    //        }
    //    }
    //    public static Group Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Group));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Group)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, Group[] groups)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Group[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, groups);
    //        }
    //    }
    //    public static Group[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Group[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Group[])serializer.Deserialize(fs);
    //        }
    //    }

    //}

    class GroupRepo
    {
        private readonly static ScheduleDbContext db;
        static GroupRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Groups CreateGroup(long GroupId, string GroupName, long GroupSize)
        {
            return new Groups { Id = GroupId, Name = GroupName, Size = GroupSize };
        }
        public static Groups CreateGroup(string GroupName, long GroupSize)
        {
            return new Groups {Name = GroupName, Size = GroupSize };
        }
        public static void UpdateGroup(Groups group, long GroupId = 0, string GroupName = null,
                                            long? GroupSize = null)
        {
            group.Id = GroupId == 0 ? group.Id : GroupId;
            group.Name = GroupName ?? group.Name;
            group.Size = GroupSize ?? group.Size;
        }
        public static long GetGroupId(Groups group)
        {
            return group.Id;
        }
        public static string GetGroupName(Groups group)
        {
            return group.Name;
        }
        public static long? GetGroupSize(Groups group)
        {
            return group.Size;
        }
        public static void Serialize(string fileName, Groups group)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Groups));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, group);
            }
        }
        public static Groups Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Groups)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Groups[] groups)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Groups[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groups);
            }
        }
        public static Groups[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Groups[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Groups[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Groups group)
        {
            db.Groups.Add(group);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Groups group)
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
        public static void UpdateInDb(Groups group)
        {
            var groupToUpdate = db.Groups.Where(g => g.Id == group.Id).FirstOrDefault();
            if (groupToUpdate != null)
            {
                db.Groups.Update(group);
            }
        }
        public static List<Groups> GetGroupsFromDb()
        {
            return db.Groups.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Groups.ToArray());
        }

    }
}
