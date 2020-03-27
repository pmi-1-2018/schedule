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
            Group g = GroupRepo.CreateGroup(1, "pmi", 19);
            GroupRepo.Serialize("g.xml", g);

            
        }
    }
}
