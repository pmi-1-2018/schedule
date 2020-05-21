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

            Schedule s = new Schedule(ProgramMode.Database);
            s.CreateSchedule(ProgramMode.Database);
        }
    }
}
