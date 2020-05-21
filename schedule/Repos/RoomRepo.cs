using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using schedule.Entities;
using schedule.Enums;

namespace schedule.Repos
{
    class RoomRepo
    {
        private readonly static ScheduleDbContext db;
        static RoomRepo()
        {
            db = new ScheduleDbContext();
        }
        public static Room CreateRoom(long RoomId, ClassType RoomType, long RoomNumber, long RoomSize)
        {
            return new Room { Id = RoomId, Type = RoomType, Number = RoomNumber, Size = RoomSize };
        }
        public static Room CreateRoom(ClassType RoomType, long RoomNumber, long RoomSize)
        {
            return new Room { Type = RoomType, Number = RoomNumber, Size = RoomSize };
        }
        public static void UpdateRoom(Room room, long RoomId = 0, ClassType? RoomType = null,
                                        long RoomNumber = 0, long RoomSize = 0)
        {
            room.Id = RoomId == 0 ? room.Id : RoomId;
            room.Type = RoomType ?? room.Type;
            room.Number = RoomNumber == 0 ? room.Number : RoomNumber;
            room.Size = RoomSize == 0 ? room.Size : RoomSize;
        }
        public static long GetRoomId(Room room)
        {
            return room.Id;
        }

        public static long? GetRoomNumber(Room room)
        {
            return room.Number;
        }
        public static long? GetRoomSize(Room room)
        {
            return room.Size;
        }
        public static ClassType? GetRoomType(Room room)
        {
            return room.Type;
        }
        public static void Serialize(string fileName, Room room)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Room));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, room);
            }
        }
        public static Room Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Room));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Room)serializer.Deserialize(fs);
            }
        }
        public static void SerializeArray(string fileName, Room[] rooms)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Room[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, rooms);
            }
        }
        public static Room[] DeserializeArray(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Room[]));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Room[])serializer.Deserialize(fs);
            }
        }

        public static void AddToDb(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }
        public static void AddToDb(List<Room> rooms)
        {
            db.Rooms.AddRange(rooms);
            db.SaveChanges();
        }
        public static void RemoveFromDb(Room room)
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
        public static void UpdateInDb(Room room)
        {
            var roomToUpdate = db.Rooms.Where(r => r.Id == room.Id).FirstOrDefault();
            if (roomToUpdate != null)
            {
                db.Rooms.Update(room);
            }
        }
        public static List<Room> GetRoomsFromDb()
        {
            return db.Rooms.ToList();
        }

        public static void SerializeDb(string filename)
        {
            SerializeArray(filename, db.Rooms.ToArray());
        }
    }
}
