using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class GroupSubjectRepo
    //{
    //    public static GroupSubject CreateGroupSubject(uint GroupSubjectGroupId, uint GroupSubjectSubjectId,
    //                                                    uint GroupSubjectCount)
    //    {
    //        return new GroupSubject
    //        {
    //            GroupId = GroupSubjectGroupId,
    //            SubjectId = GroupSubjectSubjectId,
    //            Count = GroupSubjectCount
    //        };
    //    }
    //    public static void UpdateGroupSubject(GroupSubject groupSubject, uint? GroupSubjectGroupId,
    //                                            uint? GroupSubjectSubjectId, uint? GroupSubjectCount)
    //    {
    //        groupSubject.GroupId = GroupSubjectGroupId ?? groupSubject.GroupId;
    //        groupSubject.SubjectId = GroupSubjectSubjectId ?? groupSubject.SubjectId;
    //        groupSubject.Count = GroupSubjectCount ?? groupSubject.Count;
    //    }
    //    public static uint? GetGroupSubjectGroupId(GroupSubject groupSubject)
    //    {
    //        return groupSubject.GroupId;
    //    }
    //    public static uint? GetGroupSubjectSubjectId(GroupSubject groupSubject)
    //    {
    //        return groupSubject.SubjectId;
    //    }
    //    public static uint? GetGroupSubjectCount(GroupSubject groupSubject)
    //    {
    //        return groupSubject.Count;
    //    }
    //    public static void Serialize(string fileName, GroupSubject groupSubject)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, groupSubject);
    //        }
    //    }
    //    public static GroupSubject Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (GroupSubject)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, GroupSubject[] groupSubjects)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, groupSubjects);
    //        }
    //    }
    //    public static GroupSubject[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(GroupSubject[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (GroupSubject[])serializer.Deserialize(fs);
    //        }
    //    }
    //}


    class GroupSubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static GroupSubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static GroupSubjects CreateGroupSubject(long id, long GroupSubjectGroupId, long GroupSubjectSubjectId,
                                                        long GroupSubjectCount)
        {
            return new GroupSubjects
            {
                Id = id,
                GroupId = GroupSubjectGroupId,
                SubjectId = GroupSubjectSubjectId,
                Count = GroupSubjectCount
            };
        }
        public static GroupSubjects CreateGroupSubject(long GroupSubjectGroupId, long GroupSubjectSubjectId,
                                                        long GroupSubjectCount)
        {
            return new GroupSubjects
            {
                GroupId = GroupSubjectGroupId,
                SubjectId = GroupSubjectSubjectId,
                Count = GroupSubjectCount
            };
        }
        public static void UpdateGroupSubject(GroupSubjects groupSubject, long GroupSubjectId = 0, long GroupSubjectGroupId = 0,
                                                long GroupSubjectSubjectId = 0, long GroupSubjectCount = 0)
        {
            groupSubject.Id = GroupSubjectId == 0 ? groupSubject.Id : GroupSubjectId;
            groupSubject.GroupId = GroupSubjectGroupId == 0 ? groupSubject.GroupId : GroupSubjectGroupId;
            groupSubject.SubjectId = GroupSubjectSubjectId == 0 ? groupSubject.SubjectId : GroupSubjectSubjectId;
            groupSubject.Count = GroupSubjectCount == 0 ? groupSubject.Count : GroupSubjectCount;
        }
        public static long GetGroupSubjectId(GroupSubjects groupSubject)
        {
            return groupSubject.Id;
        }
        public static long? GetGroupSubjectGroupId(GroupSubjects groupSubject)
        {
            return groupSubject.GroupId;
        }
        public static long? GetGroupSubjectSubjectId(GroupSubjects groupSubject)
        {
            return groupSubject.SubjectId;
        }
        public static long? GetGroupSubjectCount(GroupSubjects groupSubject)
        {
            return groupSubject.Count;
        }
        public static void Serialize(string fileName, GroupSubjects groupSubject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groupSubject);
            }
        }
        public static GroupSubjects Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubjects));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (GroupSubjects)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, GroupSubjects[] groupSubjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, groupSubjects);
            }
        }
        public static GroupSubjects[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GroupSubjects[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (GroupSubjects[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(GroupSubjects groupSubject)
        {
            db.GroupSubjects.Add(groupSubject);
            db.SaveChanges();
        }
        public static void RemoveFromDb(GroupSubjects groupSubject)
        {
            if (db.GroupSubjects.Contains(groupSubject))
            {
                db.GroupSubjects.Remove(groupSubject);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var groupSubject = db.GroupSubjects.Where(g => g.Id == id).FirstOrDefault();
            if (groupSubject != null)
            {
                db.GroupSubjects.Remove(groupSubject);
            }
        }
        public static void UpdateInDb(GroupSubjects groupSubject)
        {
            var groupSubjectToUpdate = db.GroupSubjects.Where(g => g.Id == groupSubject.Id).FirstOrDefault();
            if (groupSubjectToUpdate != null)
            {
                db.GroupSubjects.Update(groupSubject);
            }
        }
        public static List<GroupSubjects> GetGroupSubjectsFromDb()
        {
            return db.GroupSubjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.GroupSubjects.ToArray());
        }
    }
}
