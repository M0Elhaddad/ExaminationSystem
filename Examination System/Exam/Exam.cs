using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    public abstract class Exam
    {
        #region Properties
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionBase[] QuestionArr { get; set; }
        #endregion

        #region Constructor
        public Exam(int numberOfQuestion, int ExamTime)
        {
            TimeOfExam = ExamTime;
            NumberOfQuestions = numberOfQuestion;
        }
        #endregion

        public abstract void ShowExam();
            
        public abstract void CreateQuestionArr();

    }
}
