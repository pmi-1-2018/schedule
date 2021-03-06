﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schedule.Entities;
using schedule.Repos;
using schedule.Enums;


namespace schedule
{
    public class Schedule
    {
        public List<Class> ResSchedule { get; set; } = new List<Class>();
        public List<Room> Rooms { get; set; }
        public List<Class> Classes { get; set; } = new List<Class>();
        public Dictionary<long, Subject> DictionaryOfSubjects { get; set; } = new Dictionary<long, Subject>();
        public Dictionary<long, Group> DictionaryOfGroups { get; set; } = new Dictionary<long, Group>();
        public List<Group> Groups { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<GroupSubject> GroupSubjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }

        public Schedule()
        {
        }
        public void CreatingClasses()
        {
            foreach (var group in Groups)
            {
                DictionaryOfGroups.Add(group.Id, group);
            }
            foreach (var subject in Subjects)
            {
                DictionaryOfSubjects.Add(subject.Id, subject);
            }
            foreach (var subj in Subjects)
            {
                List<long?> SubjectTeacher = new List<long?>();
                List<long?> SubjectGroup = new List<long?>();
                foreach (var teacher in TeacherSubjects)
                {
                    if (subj.Id == teacher.SubjectId)
                    {
                        SubjectTeacher.Add(teacher.TeacherId);
                    }
                }
                foreach (var group in GroupSubjects)
                {
                    if (subj.Id == group.SubjectId)
                    {
                        SubjectGroup.Add(group.GroupId);
                    }
                }
                int i = 0;
                foreach (var Group in SubjectGroup)
                {
                    Classes.Add(ClassRepo.CreateClass(0, (long)Group, subj.Id, (long)SubjectTeacher[i], DayOfWeek.Sunday, 0));
                    i++;
                    i %= SubjectTeacher.Count;
                }
            }
        }

        public void Dividing(List<Class> FirstGroup, List<Class> SecondGroup)
        {

            foreach (var item in Classes)
            {
                string GroupName = DictionaryOfGroups[item.GroupId].Name;
                long Course = Convert.ToInt64(GroupName[GroupName.Length - 2]) - 48;
                if (Course <= 3)
                {
                    FirstGroup.Add(item);
                }
                else
                {
                    SecondGroup.Add(item);
                }
            }
        }

        public void CreateSchedule(ProgramMode pm)
        {
            ResetAlgorithm();
            if (pm == ProgramMode.XML)
            {
                this.GetDataFromXML();
            }
            else
            {
                this.GetDataFromDb();
            }

            this.CreatingClasses();

            List<Class> FirstGroup = new List<Class>();
            List<Class> SecondGroup = new List<Class>();
            this.Dividing(FirstGroup, SecondGroup);

            this.create(0, FirstGroup);
            this.create(3, SecondGroup);

            if (pm == ProgramMode.Database)
            {
                ClassRepo.AddToDb(ResSchedule);
            }
            else if(pm == ProgramMode.XML)
            {
                ClassRepo.SerializeArray("../../schedule/Data/classes.xml", ResSchedule.ToArray());
            }
            else
            {
                ClassRepo.AddToDb(ResSchedule);
                ClassRepo.SerializeDb("../../schedule/Data/classes.xml");
            }
        }


        private void create(int DayShuffle, List<Class> Group)
        {
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
            foreach (Class c in Group)
            {
                if (DictionaryOfSubjects[c.SubjectId].Type == ClassType.Computer)
                {
                    int index = rnd.Next(ComputerRoom.Count);
                    c.RoomId = ComputerRoom[index].Id;
                }
                else if (DictionaryOfSubjects[c.SubjectId].Type == ClassType.Lecture)
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
            List<Class> CalculatedClasses = new List<Class>();
            while (true)
            {
                if (generate(Group, n, CalculatedClasses))
                    break;
            }
            foreach (var cl in CalculatedClasses)
            {
                cl.Number += DayShuffle;
                ResSchedule.Add(cl);
            }

        }
        private bool generate(List<Class> c, int n, List<Class> CalculatedClasses)
        {
            Random rnd = new Random();
            for (int i = 0; i < c.Count; i++)
            {
                int Possible = (1 << n) - 1;
                for (int j = 0; j < CalculatedClasses.Count; j++)
                {
                    if (CalculatedClasses[j].GroupId == c[i].GroupId || CalculatedClasses[j].RoomId == c[i].RoomId || CalculatedClasses[j].TeacherId == c[i].TeacherId)
                    {
                        Possible &= (~(1 << (((int)CalculatedClasses[j].Day-1) * 3 + (int)CalculatedClasses[j].Number - 1)));
                    }
                }
                if(Possible == 0)
                {
                    CalculatedClasses.Clear();
                    return false;
                }
                else
                {
                    int count = countSetBits(Possible);
                    int index = rnd.Next(count-1)+1;
                    index = findIndex(Possible, index)-1;
                    c[i].Day = (DayOfWeek)(index / 3 + 1);
                    c[i].Number = (long?)index % 3 + 1;
                    CalculatedClasses.Add(c[i]);
                }
            }
            return true;
        }

        private static int countSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        private static int findIndex(int n, int k)
        {
            int index = 0;
            while (k > 0)
            {
                index++;
                if ((n & 1) == 1)
                {
                    k--;
                }
                n >>= 1;
            }
            return index;
        }
        public void GetDataFromXML()
        {
            Groups = GroupRepo.DeserializeArray("../../schedule/Data/groups.xml").ToList();
            Teachers = TeacherRepo.DeserializeArray("../../schedule/Data/teachers.xml").ToList();
            Rooms = RoomRepo.DeserializeArray("../../schedule/Data/rooms.xml").ToList();
            GroupSubjects = GroupSubjectRepo.DeserializeArray("../../schedule/Data/group_subjects.xml").ToList();
            TeacherSubjects = TeacherSubjectRepo.DeserializeArray("../../schedule/Data/teacher_subjects.xml").ToList();
            Subjects = SubjectRepo.DeserializeArray("../../schedule/Data/subjects.xml").ToList();
        }
        public void GetDataFromDb()
        {
            Groups = GroupRepo.GetGroupsFromDb();
            Teachers = TeacherRepo.GetTeachersFromDb();
            Rooms = RoomRepo.GetRoomsFromDb();
            GroupSubjects = GroupSubjectRepo.GetGroupSubjectsFromDb();
            TeacherSubjects = TeacherSubjectRepo.GetTeacherSubjectsFromDb();
            Subjects = SubjectRepo.GetSubjectsFromDb();
        }
        public List<Class> GetClassesFromFile()
        {
            var ClassesFromFile = ClassRepo.DeserializeArray("../../schedule/Data/classes.xml").ToList();
            for (int i = 0; i < ClassesFromFile.Count; i++)
            {
                ClassesFromFile[i].Group = Groups.SingleOrDefault(g => g.Id == ResSchedule[i].GroupId);
                ClassesFromFile[i].Teacher = Teachers.SingleOrDefault(t => t.Id == ResSchedule[i].TeacherId);
                ClassesFromFile[i].Room = Rooms.SingleOrDefault(r => r.Id == ResSchedule[i].RoomId);
                ClassesFromFile[i].Subject = Subjects.SingleOrDefault(s => s.Id == ResSchedule[i].SubjectId);
            }
            return ClassesFromFile;
        }
        public List<Class> GetClassesFromDb()
        {
            return ClassRepo.GetClassesFromDb();
        }
        private void ResetAlgorithm()
        {
            ResSchedule?.Clear();
            Rooms?.Clear();
            Classes?.Clear();
            DictionaryOfSubjects?.Clear();
            DictionaryOfGroups?.Clear();
            Groups?.Clear();
            Subjects?.Clear();
            GroupSubjects?.Clear();
            Teachers?.Clear();
            TeacherSubjects?.Clear();
            ClassRepo.DeleteAllFromDb();
    }
    }
}
