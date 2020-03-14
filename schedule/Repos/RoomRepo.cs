using System.Xml.Serialization;
using schedule.Entities;
using System.IO;

namespace schedule.Repos
{
    class RoomRepo
    {
        public static Room CreateRoom(uint RoomId, ClassType RoomType, uint RoomNumber, uint RoomSize)
        {
            return new Room { Id = RoomId, Type = RoomType, Number = RoomNumber, Size = RoomSize };
        }
        public static void UpdateRoom(Room room, uint? RoomId = null, ClassType? RoomType = null,
                                        uint? RoomNumber = null, uint? RoomSize = null)
        {
            room.Id = RoomId ?? room.Id;
            room.Type = RoomType ?? room.Type;
            room.Number = RoomNumber ?? room.Number;
            room.Size = RoomSize ?? room.Size;
        }
        public static uint? GetRoomId(Room room)
        {
            return room.Id;
        }

        public static uint? GetRoomNumber(Room room)
        {
            return room.Number;
        }
        public static uint? GetRoomSize(Room room)
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
    }
}
