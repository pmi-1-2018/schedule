using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schedule.Entities;
using schedule.Repos;

namespace schedule
{
    class Program
    {
        public class ApplicationContext : DbContext
        {
            public DbSet<Class> Classes { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Room> Rooms { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Teacher> Teachers { get; set; }
            public DbSet<GroupSubject> GroupSubjects { get; set; }
            public DbSet<TeacherSubject> TeacherSubjects { get; set; }

            public ApplicationContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=scheduledb;Username=postgres;Password=1111");
            }
        }
        static void Main(string[] args)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Class @class = new Class() { Day = DayOfWeek.Friday, GroupId = 1, Id = 1, Number = 1, RoomId = 1, SubjectId = 1, TeacherId = 1 };
                db.Classes.Add(@class);
                db.SaveChanges();
            }
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



        }
    }
}
