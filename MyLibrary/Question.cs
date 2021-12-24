using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Question
    {
        public int Id { get; set; }
        private string vopros;
        public string Vopros { get { return vopros; } set { vopros = value; } }

        //Навигационное свойство
        
        public int TestId { get; set; }
        public Test Test { get; set; }

        //public List<Answer> Answers { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }

        public Question()
        {
            //
            Answers = new List<Answer>();
            Pairs = new List<Pair>();
        }
        public Question(string vopros)
        {
            //
            Answers = new List<Answer>();
            Pairs = new List<Pair>();
            this.vopros = vopros;
        }
        public override string ToString()
        {
            return Vopros;
        }
    }
}
