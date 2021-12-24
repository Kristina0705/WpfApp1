using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Result
    {
        private DateTime startTime, endTime;
        public int Id { get; set; }

        public DateTime StartTime { get { return startTime; } set { startTime = value; } }
        public DateTime EndTime { get { return endTime; } set { endTime = value; } }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        //Навигационное свойство
        public int TestId { get; set; }
        public Test Test { get; set; }
        
        public Result()
        {
            Pairs = new List<Pair>();
        }
        public Result(DateTime startTime, DateTime endTime)
        {
            Pairs = new List<Pair>();
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public virtual ICollection<Pair> Pairs { get; set; }

        
    }
}
