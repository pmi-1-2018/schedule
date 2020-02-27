using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    class Subject
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class Lecture : Subject
    {


    }

}
