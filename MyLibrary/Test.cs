using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Test
    {
        public int Id { get; set; }
        private string name, opisanie;
        public string Name { get { return name; } set { name = value; } }
        public string Opisanie { get { return opisanie; } set { opisanie = value; } }
        public Test() 
        { 
        }
        public Test(string name, string opisanie)
        {
            this.name = name;
            this.opisanie = opisanie;
        }
    }
    
}
