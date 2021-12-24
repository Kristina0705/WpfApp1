using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Modeles
{
    public class DBManager
    {
        private MobileContext uc = new MobileContext();

        public List<Test> GetTests()
        {
            return uc.Tests.ToList();
        }

        public List<Question> GetQuestions()
        {
            return uc.Questions.ToList();
        }

        public List<Question> GetQuestionsFromTest(Test test)
        {
            return test.Questions.ToList();
        }

        public void AddResult(Result result)
        {
            uc.Results.Add(result);
            uc.SaveChanges();
        }
    }
}
