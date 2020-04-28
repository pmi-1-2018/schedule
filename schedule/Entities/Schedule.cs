using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Entities
{
    class Schedule
    {
        public List<Class> schedule { get; set; }
        public Schedule(List<Room> rooms, List<Class> classes, Dictionary<uint?, Subject> dick)
        {
            schedule = new List<Class>();
            //розбити на 2 лісти.
            List<Room> LectureRoom =  new List<Room>();
            List<Room> ComputerRoom = new List<Room>();
            List<Room> DefaultRoom =  new List<Room>();
            foreach(Room r in rooms)
            {
                if (r.Type == ClassType.Lecture)
                    LectureRoom.Add(r);
                else if (r.Type == ClassType.Computer)
                    ComputerRoom.Add(r);
                else
                    DefaultRoom.Add(r);
            }
            Random rnd = new Random();
            foreach(Class c in classes)
            {
                if (dick[c.SubjectId].Type == ClassType.Computer)
                {
                    int index = rnd.Next(ComputerRoom.Count);
                    c.RoomId = ComputerRoom[index].Id;
                }
                else if (dick[c.SubjectId].Type == ClassType.Lecture)
                {
                    int index = rnd.Next(LectureRoom.Count);
                    c.RoomId = LectureRoom[index].Id;
                }
                else
                {
                    int index = rnd.Next(DefaultRoom.Count);
                    c.RoomId = DefaultRoom[index].Id;
                }
            }
            int n = 15;
            List<List<Class>> ClassesPerDay = new List<List<Class>>();
            for (int i = 0; i < n; i++)
            {
                ClassesPerDay.Add(new List<Class>());
            }
            foreach (Class c in classes)
            {
                List<int> l = new List<int>();
                for (int i = 0; i < n; i++) { l.Add(i); }
                for (int i = 0; i < n; i++)
                {
                    bool can = true;
                    for (int j = 0; j < ClassesPerDay[i].Count; j++)
                    {
                        if (ClassesPerDay[i][j].GroupId == c.GroupId || ClassesPerDay[i][j].RoomId == c.RoomId || ClassesPerDay[i][j].TeacherId == c.TeacherId)
                        {
                            can = false;
                            break;
                        }
                    }
                    if (!can)
                        l.Remove(i);
                }
                if (l.Count != 0)
                {
                    int index = rnd.Next(l.Count);
                    ClassesPerDay[index].Add(c);
                }
                else
                {
                    int a = 0;
                    //треба перегенерувати.
                }
            }
            for (int i = 0; i < n; i++)
            {
                foreach(var cl in ClassesPerDay[i])
                {
                    cl.Day = (DayOfWeek)(i / 5);
                    cl.Number = (uint?)i % 5;
                    schedule.Add(cl);
                }
            }
        }
    }
}
