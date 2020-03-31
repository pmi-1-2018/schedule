using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schedule.Entities;
using schedule.Repos;

namespace schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Class[] c = new Class[225];
            for (uint i = 0; i < 15; i++)
            {
                for (uint j = 0; j < 15; j++)
                {
                    c[i * 15 + j] = ClassRepo.CreateClass(i * 15 + j, 0, j, i, i, DayOfWeek.Sunday, 0);
                }
            }
            ClassRepo.SerializeArray("class.xml", c);

            ClassType[] classType = { ClassType.Lecture, ClassType.Computer, ClassType.Ordinary };


            Room[] r = new Room[15];
            for (uint i = 1; i <= 15; i++)
            {
                r[i-1] = RoomRepo.CreateRoom(i, classType[i % 3], i, 25);
            }
            RoomRepo.SerializeArray("room.xml", r);


            Dictionary<uint, Subject> dick = new Dictionary<uint, Subject>();
            for (uint i = 0; i < 15; i++)
            {
                dick.Add(i, SubjectRepo.CreateSubject(i, "subject" + Convert.ToString(i), classType[i % 3]));
            }
        }
    }
}
