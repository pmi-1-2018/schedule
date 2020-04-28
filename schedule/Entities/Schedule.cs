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
        public List<Room> Rooms { get; set; }
        public List<Class> Classes { get; set; }
        public Dictionary<uint?, Subject> Subjects { get; set; }
        public Schedule(List<Room> rooms, List<Class> classes, Dictionary<uint?, Subject> subjects)
        {
            schedule = new List<Class>();
            Rooms = rooms;
            Classes = classes;
            Subjects = subjects;
        }

        public void CreateSchedule()
        {
            //розбити на 2 лісти.
            List<Room> LectureRoom = new List<Room>();
            List<Room> ComputerRoom = new List<Room>();
            List<Room> DefaultRoom = new List<Room>();
            foreach (Room r in Rooms)
            {
                if (r.Type == ClassType.Lecture)
                    LectureRoom.Add(r);
                else if (r.Type == ClassType.Computer)
                    ComputerRoom.Add(r);
                else
                    DefaultRoom.Add(r);
            }
            Random rnd = new Random();
            foreach (Class c in Classes)
            {
                if (Subjects[c.SubjectId].Type == ClassType.Computer)
                {
                    int index = rnd.Next(ComputerRoom.Count);
                    c.RoomId = ComputerRoom[index].Id;
                }
                else if (Subjects[c.SubjectId].Type == ClassType.Lecture)
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
            int n = 20;
            List<List<Class>> ClassesPerDay = new List<List<Class>>();
            for (int i = 0; i < n; i++)
            {
                ClassesPerDay.Add(new List<Class>());
            }
            while(true)
            {
                if (generate(Classes, n, ClassesPerDay))
                    break;
            }
            for (int i = 0; i < n; i++)
            {
                foreach (var cl in ClassesPerDay[i])
                {
                    cl.Day = (DayOfWeek)(i / 4 + 1);
                    cl.Number = (uint?)i % 4 + 1;
                    schedule.Add(cl);
                }
            }
            ClassRepo.SerializeArray("schedule.xml", schedule.ToArray());
        }

        private bool generate(List<Class> Classes, int n, List<List<Class>> ClassesPerDay)
        {
            Random rnd = new Random();
            foreach (Class c in Classes)
            {
                List<int> l = new List<int>();
                for (int k = 0; k < n; k++) { l.Add(k); }
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
                    ClassesPerDay[l[index]].Add(c);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
