using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

            Schedule s = new Schedule();
            s.CreateSchedule(ProgramMode.Database);
            //TestDataGenerator.GenerateGrours();
            //TestDataGenerator.GenerateRooms();
            //TestDataGenerator.GenerateSubjects();
            //TestDataGenerator.GenerateTeachers();
            //TestDataGenerator.GenerateGroupSubjects();
            //TestDataGenerator.GenerateTeacherSubjects();
            //var a = GroupRepo.GetGroupsFromDb();
            //foreach (var el in a)
            //{
            //    Console.WriteLine($"{el.Name} {el.Size}");
            //}
        }
    }
}
