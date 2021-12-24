using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Answer
    {
        private string title;
        public int Id { get; set; }

        public string Title { get { return title; } set { title = value; } }
        //Навигационное свойство
        public virtual ICollection<Pair> Pairs { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public Answer()
        {
            Pairs = new List<Pair>();
        }
        public Answer(string answer)
        {
            this.title = answer;
            Pairs = new List<Pair>();
        }
    }
}
