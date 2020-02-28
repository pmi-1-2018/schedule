using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule
{
    public enum SubjectType
    {
        Comuter,
        Lecture,
        Ordinary,
    }
    class Subject
    {
        public string Name { get; set; }
        public SubjectType SubjectType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
