using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schedule.Entities;
using schedule.Enums;
using schedule.Repos;

namespace schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(ApplicationContext db = new ApplicationContext())
            //{
            //    Class @class = new Class() { Day = DayOfWeek.Friday, GroupId = 1, Id = 1, Number = 1, RoomId = 1, SubjectId = 1, TeacherId = 1 };
            //    db.Classes.Add(@class);
            //    db.SaveChanges();
            //}
            //Class[] c = new Class[100];
            //for (uint i = 0; i < 10; i++)
            //{
            //    for (uint j = 0; j < 10; j++)
            //    {
            //        c[i * 10 + j] = ClassRepo.CreateClass(i * 10 + j, 0, j, i, i, DayOfWeek.Sunday, 0);
            //    }
            //}
            //ClassRepo.SerializeArray("class.xml", c);

            //ClassType[] classType = { ClassType.Lecture, ClassType.Computer, ClassType.Ordinary };


            //Room[] r = new Room[15];
            //for (uint i = 1; i <= 15; i++)
            //{
            //    r[i - 1] = RoomRepo.CreateRoom(i, classType[i % 3], i, 25);
            //}
            //RoomRepo.SerializeArray("room.xml", r);

            //List<Room> oral = RoomRepo.DeserializeArray("room.xml").ToList();
            //List<Class> cal = ClassRepo.DeserializeArray("class.xml").ToList();

            //Dictionary<uint?, Subject> dick = new Dictionary<uint?, Subject>();
            //for (uint i = 0; i < 10; i++)
            //{
            //    dick.Add(i, SubjectRepo.CreateSubject(i, "subject" + Convert.ToString(i), classType[i % 3]));
            //}
            //Schedule s = new Schedule(oral, cal, dick);
            //s.CreateSchedule();

            // groups
            Group g1 = GroupRepo.CreateGroup("ПМІ-21", 20);
            GroupRepo.AddToDb(g1);
            Group g2 = GroupRepo.CreateGroup("ПМІ-22", 20);
            GroupRepo.AddToDb(g2);
            Group g3 = GroupRepo.CreateGroup("ПМІ-23", 20);
            GroupRepo.AddToDb(g3);

            // rooms
            Room r1 = RoomRepo.CreateRoom(ClassType.Ordinary, 366, 25);
            RoomRepo.AddToDb(r1);
            Room r2 = RoomRepo.CreateRoom(ClassType.Lecture, 111, 80);
            RoomRepo.AddToDb(r2);
            Room r3 = RoomRepo.CreateRoom(ClassType.Ordinary, 367, 25);
            RoomRepo.AddToDb(r3);
            Room r4 = RoomRepo.CreateRoom(ClassType.Ordinary, 70, 25);
            RoomRepo.AddToDb(r4);
            Room r5 = RoomRepo.CreateRoom(ClassType.Computer, 1192, 25);
            RoomRepo.AddToDb(r5);
            Room r6 = RoomRepo.CreateRoom(ClassType.Computer, 1191, 25);
            RoomRepo.AddToDb(r6);
            Room r7 = RoomRepo.CreateRoom(ClassType.Ordinary, 73, 25);
            RoomRepo.AddToDb(r7);
            Room r8 = RoomRepo.CreateRoom(ClassType.Computer, 117, 20);
            RoomRepo.AddToDb(r8);
            Room r9 = RoomRepo.CreateRoom(ClassType.Computer, 2723, 20);
            RoomRepo.AddToDb(r9);
            Room r10 = RoomRepo.CreateRoom(ClassType.Computer, 116, 20);
            RoomRepo.AddToDb(r10);
            Room r11 = RoomRepo.CreateRoom(ClassType.Ordinary, 145, 25);
            RoomRepo.AddToDb(r11);
            Room r12 = RoomRepo.CreateRoom(ClassType.Lecture, 439, 120);
            RoomRepo.AddToDb(r12);
            Room r13 = RoomRepo.CreateRoom(ClassType.Ordinary, 366, 25);
            RoomRepo.AddToDb(r13);
            Room r14 = RoomRepo.CreateRoom(ClassType.Ordinary, 365, 25);
            RoomRepo.AddToDb(r14);
            Room r15 = RoomRepo.CreateRoom(ClassType.Computer, 270, 25);
            RoomRepo.AddToDb(r15);
            Room r16 = RoomRepo.CreateRoom(ClassType.Computer, 118, 25);
            RoomRepo.AddToDb(r16);
            Room r17 = RoomRepo.CreateRoom(ClassType.Ordinary, 261, 25);
            RoomRepo.AddToDb(r17);

            // teachers
            Teacher t1 = TeacherRepo.CreateTeacher("Квасниця");
            TeacherRepo.AddToDb(t1);
            Teacher t2 = TeacherRepo.CreateTeacher("Пелюшкевич");
            TeacherRepo.AddToDb(t2);
            Teacher t3 = TeacherRepo.CreateTeacher("Притула");
            TeacherRepo.AddToDb(t3);
            Teacher t4 = TeacherRepo.CreateTeacher("Рикалюк");
            TeacherRepo.AddToDb(t4);
            Teacher t5 = TeacherRepo.CreateTeacher("Жировецький");
            TeacherRepo.AddToDb(t5);
            Teacher t6 = TeacherRepo.CreateTeacher("Стойко");
            TeacherRepo.AddToDb(t6);
            Teacher t7 = TeacherRepo.CreateTeacher("Костів");
            TeacherRepo.AddToDb(t7);
            Teacher t8 = TeacherRepo.CreateTeacher("Сибіль");
            TeacherRepo.AddToDb(t8);
            Teacher t9 = TeacherRepo.CreateTeacher("Літинський");
            TeacherRepo.AddToDb(t9);
            Teacher t10 = TeacherRepo.CreateTeacher("Клакович");
            TeacherRepo.AddToDb(t10);
            Teacher t11 = TeacherRepo.CreateTeacher("Галамага");
            TeacherRepo.AddToDb(t11);
            Teacher t12 = TeacherRepo.CreateTeacher("Дреботій");
            TeacherRepo.AddToDb(t12);
            Teacher t13 = TeacherRepo.CreateTeacher("Заболоцький");
            TeacherRepo.AddToDb(t13);
            Teacher t14 = TeacherRepo.CreateTeacher("Малець");
            TeacherRepo.AddToDb(t14);

            // subjects
            Subject s1 = SubjectRepo.CreateSubject("ТЕОРІЯ АЛГОРИТ.", ClassType.Lecture);
            SubjectRepo.AddToDb(s1);
            Subject s2 = SubjectRepo.CreateSubject("ТЕОРІЯ АЛГОРИТ.", ClassType.Computer);
            SubjectRepo.AddToDb(s2);
            Subject s3 = SubjectRepo.CreateSubject("КОМП. ІНФ. мережі", ClassType.Lecture);
            SubjectRepo.AddToDb(s3);
            Subject s4 = SubjectRepo.CreateSubject("КОМП. ІНФ. мережі", ClassType.Computer);
            SubjectRepo.AddToDb(s4);
            Subject s5 = SubjectRepo.CreateSubject("Програмування", ClassType.Lecture);
            SubjectRepo.AddToDb(s5);
            Subject s6 = SubjectRepo.CreateSubject("Програмування", ClassType.Computer);
            SubjectRepo.AddToDb(s6);
            Subject s7 = SubjectRepo.CreateSubject("БД ТА ІС", ClassType.Lecture);
            SubjectRepo.AddToDb(s7);
            Subject s8 = SubjectRepo.CreateSubject("БД ТА ІС", ClassType.Computer);
            SubjectRepo.AddToDb(s8);
            Subject s9 = SubjectRepo.CreateSubject("ВИР. ПРАК.(обч.)", ClassType.Computer);
            SubjectRepo.AddToDb(s9);
            Subject s10 = SubjectRepo.CreateSubject("ТІМС", ClassType.Lecture);
            SubjectRepo.AddToDb(s10);
            Subject s11 = SubjectRepo.CreateSubject("ТІМС", ClassType.Ordinary);
            SubjectRepo.AddToDb(s11);

            // GroupSubject

            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    GroupSubject gs = GroupSubjectRepo.CreateGroupSubject(i, j, 60);
                    GroupSubjectRepo.AddToDb(gs);
                }
            }

            // TeacherSubject
            TeacherSubject ts1 = TeacherSubjectRepo.CreateTeacherSubject(1, 11, 300);
            TeacherSubjectRepo.AddToDb(ts1);
            TeacherSubject ts2 = TeacherSubjectRepo.CreateTeacherSubject(2, 11, 300);
            TeacherSubjectRepo.AddToDb(ts2);
            TeacherSubject ts3 = TeacherSubjectRepo.CreateTeacherSubject(3, 10, 300);
            TeacherSubjectRepo.AddToDb(ts3);
            TeacherSubject ts4 = TeacherSubjectRepo.CreateTeacherSubject(4, 3, 300);
            TeacherSubjectRepo.AddToDb(ts4);
            TeacherSubject ts5 = TeacherSubjectRepo.CreateTeacherSubject(4, 4, 300);
            TeacherSubjectRepo.AddToDb(ts5);
            TeacherSubject ts6 = TeacherSubjectRepo.CreateTeacherSubject(5, 4, 300);
            TeacherSubjectRepo.AddToDb(ts6);
            TeacherSubject ts7 = TeacherSubjectRepo.CreateTeacherSubject(5, 8, 300);
            TeacherSubjectRepo.AddToDb(ts7);
            TeacherSubject ts8 = TeacherSubjectRepo.CreateTeacherSubject(6, 6, 300);
            TeacherSubjectRepo.AddToDb(ts8);
            TeacherSubject ts9 = TeacherSubjectRepo.CreateTeacherSubject(7, 2, 300);
            TeacherSubjectRepo.AddToDb(ts9);
            TeacherSubject ts10 = TeacherSubjectRepo.CreateTeacherSubject(7, 8, 300);
            TeacherSubjectRepo.AddToDb(ts10);
            TeacherSubject ts11 = TeacherSubjectRepo.CreateTeacherSubject(8, 1, 300);
            TeacherSubjectRepo.AddToDb(ts11);
            TeacherSubject ts12 = TeacherSubjectRepo.CreateTeacherSubject(9, 7, 300);
            TeacherSubjectRepo.AddToDb(ts12);
            TeacherSubject ts13 = TeacherSubjectRepo.CreateTeacherSubject(10, 5, 300);
            TeacherSubjectRepo.AddToDb(ts13);
            TeacherSubject ts14 = TeacherSubjectRepo.CreateTeacherSubject(10, 6, 300);
            TeacherSubjectRepo.AddToDb(ts14);
            TeacherSubject ts15 = TeacherSubjectRepo.CreateTeacherSubject(11, 9, 300);
            TeacherSubjectRepo.AddToDb(ts15);
            TeacherSubject ts16 = TeacherSubjectRepo.CreateTeacherSubject(12, 9, 300);
            TeacherSubjectRepo.AddToDb(ts16);
            TeacherSubject ts17 = TeacherSubjectRepo.CreateTeacherSubject(12, 6, 300);
            TeacherSubjectRepo.AddToDb(ts17);
            TeacherSubject ts18 = TeacherSubjectRepo.CreateTeacherSubject(13, 4, 300);
            TeacherSubjectRepo.AddToDb(ts18);
            TeacherSubject ts19 = TeacherSubjectRepo.CreateTeacherSubject(13, 8, 300);
            TeacherSubjectRepo.AddToDb(ts19);
            TeacherSubject ts20 = TeacherSubjectRepo.CreateTeacherSubject(14, 8, 300);
            TeacherSubjectRepo.AddToDb(ts20);
            TeacherSubject ts21 = TeacherSubjectRepo.CreateTeacherSubject(6, 9, 300);
            TeacherSubjectRepo.AddToDb(ts21);


        }
    }
}
