using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;

namespace schedule.Repos
{
    class GroupSubjectRepo
    {
        private readonly static ScheduleDbContext db;
        static GroupSubjectRepo()
        {
            db = new ScheduleDbContext();
        }
        public static GroupSubject CreateGroupSubject(long id, long? GroupSubjectGroupId, long? GroupSubjectSubjectId,
                                                        long? GroupSubjectCount)
        {
            return new GroupSubject
            {
                Id = id,
                GroupId = GroupSubjectGroupId,
                SubjectId = GroupSubjectSubjectId,
                Count = GroupSubjectCount
            };
        }
        public static GroupSubject CreateGroupSubject(long GroupSubjectGroupId, long GroupSubjectSubjectId,
                                                        long GroupSubjectCount)
        {
            return new GroupSubject
            {
                GroupId = GroupSubjectGroupId,
                SubjectId = GroupSubjectSubjectId,
                Count = GroupSubjectCount
            };
        }
        public static void UpdateGroupSubject(GroupSubject groupSubject, long GroupSubjectId = 0, long GroupSubjectGroupId = 0,
                                                long GroupSubjectSubjectId = 0, long GroupSubjectCount = 0)
        {
            groupSubject.Id = GroupSubjectId == 0 ? groupSubject.Id : GroupSubjectId;
            groupSubject.GroupId = GroupSubjectGroupId == 0 ? groupSubject.GroupId : GroupSubjectGroupId;
            groupSubject.SubjectId = GroupSubjectSubjectId == 0 ? groupSubject.SubjectId : GroupSubjectSubjectId;
            groupSubject.Count = GroupSubjectCount == 0 ? groupSubject.Count : GroupSubjectCount;
        }
        public static long GetGroupSubjectId(GroupSubject groupSubject)
        {
            return groupSubject.Id;
        }
        public static long? GetGroupSubjectGroupId(GroupSubject groupSubject)
        {
            return groupSubject.GroupId;
        }
        public static long? GetGroupSubjectSubjectId(GroupSubject groupSubject)
        {
            return groupSubject.SubjectId;
        }
        public static long? GetGroupSubjectCount(GroupSubject groupSubject)
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

        public static void AddToDb(GroupSubject groupSubject)
        {
            db.GroupSubjects.Add(groupSubject);
            db.SaveChanges();
        }
        public static void AddToDb(List<GroupSubject> groupSubjects)
        {
            db.GroupSubjects.AddRange(groupSubjects);
            db.SaveChanges();
        }
        public static void RemoveFromDb(GroupSubject groupSubject)
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
        public static void UpdateInDb(GroupSubject groupSubject)
        {
            var groupSubjectToUpdate = db.GroupSubjects.Where(g => g.Id == groupSubject.Id).FirstOrDefault();
            if (groupSubjectToUpdate != null)
            {
                db.GroupSubjects.Update(groupSubject);
            }
        }
        public static List<GroupSubject> GetGroupSubjectsFromDb()
        {
            return db.GroupSubjects.ToList();
        }

        public static void SerializeDb(string filename)
        {
            var groupSubjectsFromDb = db.GroupSubjects.ToArray();
            var groupSubjectsToSerialize = new GroupSubject[groupSubjectsFromDb.Length];
            for (int i = 0; i < groupSubjectsToSerialize.Length; i++)
            {
                groupSubjectsToSerialize[i] = CreateGroupSubject(groupSubjectsFromDb[i].Id, groupSubjectsFromDb[i].GroupId, groupSubjectsFromDb[i].SubjectId, groupSubjectsFromDb[i].Count);
            }
            SerializeArray(filename, groupSubjectsToSerialize);
        }
    }
}
