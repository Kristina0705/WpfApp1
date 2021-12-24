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
        private int tip;
        public string Name { get { return name; } set { name = value; } }
        public string Opisanie { get { return opisanie; } set { opisanie = value; } }
        public int Tip { get { return tip; } set { tip = value; } }

        //public List<Question> Questions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public List<Result> Results { get; set; }

        public Test() 
        {
            //
            Questions = new List<Question>();
        }
        public Test(string name, string opisanie, int tip)
        {
            //
            Questions = new List<Question>();
            this.name = name;
            this.opisanie = opisanie;
            this.tip = tip;
        }
        public override string ToString()
        {
            return  Name;
        }
    }
    
}
