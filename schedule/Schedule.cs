using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schedule.Entities;
using schedule.Repos;

namespace schedule
{
    class Schedule
    {
        public List<Class> ResSchedule { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Class> Classes { get; set; }
        public Dictionary<uint?, Subject> Subjects { get; set; }
        public List<Group> Groups { get; set; }
        public List<GroupSubject> GroupSubjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }
        public Schedule(List<Room> rooms, List<Class> classes, Dictionary<uint?, Subject> subjects)
        {
            ResSchedule = new List<Class>();
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
                    ResSchedule.Add(cl);
                }
            }
            ClassRepo.SerializeArray("schedule.xml", ResSchedule.ToArray());
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

        public void GetData()
        {
            Groups = GroupRepo.DeserializeArray("../../Data/groups.xml").ToList();
            Teachers = TeacherRepo.DeserializeArray("../../Data/teachers.xml").ToList();
            Rooms = RoomRepo.DeserializeArray("../../Data/rooms.xml").ToList();
            GroupSubjects = GroupSubjectRepo.DeserializeArray("../../Data/group_subjects.xml").ToList();
            TeacherSubjects = TeacherSubjectRepo.DeserializeArray("../../Data/teacher_subjects.xml").ToList();
            var subjects = SubjectRepo.DeserializeArray("../../Data/subjects.xml");
            foreach(var subject in subjects)
            {
                Subjects.Add(subject.Id, subject);
            }
            Classes = ClassRepo.DeserializeArray("../../Dara/classes.xml").ToList();
        }

        public void GenerateTestData()
        {
            Class[] c = new Class[100];
            for (uint i = 0; i < 10; i++)
            {
                for (uint j = 0; j < 10; j++)
                {
                    c[i * 10 + j] = ClassRepo.CreateClass(i * 10 + j, 0, j, i, i, DayOfWeek.Sunday, 0);
                }
            }
            ClassRepo.SerializeArray("class.xml", c);

            ClassType[] classType = { ClassType.Lecture, ClassType.Computer, ClassType.Ordinary };


            Room[] r = new Room[15];
            for (uint i = 1; i <= 15; i++)
            {
                r[i - 1] = RoomRepo.CreateRoom(i, classType[i % 3], i, 25);
            }
            RoomRepo.SerializeArray("room.xml", r);
        }
    }
}
