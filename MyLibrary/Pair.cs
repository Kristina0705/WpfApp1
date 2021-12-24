using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Pair
    {
        public int Id { get; set; }
        //public int ResultId { get; set; }
        public virtual Result Result { get; set; }
        //public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        //public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        
        public Pair()
        {
        }
            
    }
}
