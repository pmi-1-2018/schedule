using System.Xml.Serialization;
using schedule.Entities;
using System.IO;
using schedule.Enums;
using System.Linq;
using System.Collections.Generic;

namespace schedule.Repos
{
    //class RoomRepo
    //{
    //    public static Room CreateRoom(uint RoomId, ClassType RoomType, uint RoomNumber, uint RoomSize)
    //    {
    //        return new Room { Id = RoomId, Type = RoomType, Number = RoomNumber, Size = RoomSize };
    //    }
    //    public static void UpdateRoom(Room room, uint? RoomId = null, ClassType? RoomType = null,
    //                                    uint? RoomNumber = null, uint? RoomSize = null)
    //    {
    //        room.Id = RoomId ?? room.Id;
    //        room.Type = RoomType ?? room.Type;
    //        room.Number = RoomNumber ?? room.Number;
    //        room.Size = RoomSize ?? room.Size;
    //    }
    //    public static uint? GetRoomId(Room room)
    //    {
    //        return room.Id;
    //    }

    //    public static uint? GetRoomNumber(Room room)
    //    {
    //        return room.Number;
    //    }
    //    public static uint? GetRoomSize(Room room)
    //    {
    //        return room.Size;
    //    }
    //    public static ClassType? GetRoomType(Room room)
    //    {
    //        return room.Type;
    //    }
    //    public static void Serialize(string fileName, Room room)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Room));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, room);
    //        }
    //    }
    //    public static Room Deserialize(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Room));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Room)serializer.Deserialize(fs);
    //        }
    //    }
    //    public static void SerializeArray(string fileName, Room[] rooms)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Room[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            serializer.Serialize(fs, rooms);
    //        }
    //    }
    //    public static Room[] DeserializeArray(string fileName)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Room[]));
    //        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
    //        {
    //            return (Room[])serializer.Deserialize(fs);
    //        }
    //    }
    //}

    class RoomRepo
    {
        private readonly static ScheduleDbContext db;
        static RoomRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Rooms CreateRoom(long RoomId, ClassType RoomType, long RoomNumber, long RoomSize)
        {
            return new Rooms { Id = RoomId, Type = RoomType, Number = RoomNumber, Size = RoomSize };
        }
        public static Rooms CreateRoom(ClassType RoomType, long RoomNumber, long RoomSize)
        {
            return new Rooms { Type = RoomType, Number = RoomNumber, Size = RoomSize };
        }
        public static void UpdateRoom(Rooms room, long RoomId = 0, ClassType? RoomType = null,
                                        long RoomNumber = 0, long RoomSize = 0)
        {
            room.Id = RoomId == 0 ? room.Id : RoomId;
            room.Type = RoomType ?? room.Type;
            room.Number = RoomNumber == 0 ? room.Number : RoomNumber;
            room.Size = RoomSize == 0 ? room.Size : RoomSize;
        }
        public static long GetRoomId(Rooms room)
        {
            return room.Id;
        }

        public static long? GetRoomNumber(Rooms room)
        {
            return room.Number;
        }
        public static long? GetRoomSize(Rooms room)
        {
            return room.Size;
        }
        public static ClassType? GetRoomType(Rooms room)
        {
            return room.Type;
        }
        public static void Serialize(string fileName, Rooms room)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rooms));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, room);
            }
        }
        public static Rooms Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rooms));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Rooms)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Rooms[] rooms)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rooms[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, rooms);
            }
        }
        public static Rooms[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rooms[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Rooms[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Rooms room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Rooms room)
        {
            if (db.Rooms.Contains(room))
            {
                db.Rooms.Remove(room);
            }
        }
        public static void RemoveFromDb(long id)
        {
            var room = db.Rooms.Where(r => r.Id == id).FirstOrDefault();
            if (room != null)
            {
                db.Rooms.Remove(room);
            }
        }
        public static void UpdateInDb(Rooms room)
        {
            var roomToUpdate = db.Rooms.Where(r => r.Id == room.Id).FirstOrDefault();
            if (roomToUpdate != null)
            {
                db.Rooms.Update(room);
            }
        }
        public static List<Rooms> GetRoomsFromDb()
        {
            return db.Rooms.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Rooms.ToArray());
        }
    }
}
