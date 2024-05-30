using Examination_System.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    internal class TFQuestion : QuestionBase
    {
        public override string HeaderOfQuestion => "True | False Question";
        public TFQuestion()
        {
            AnswerArr = new Answer[2];
            AnswerArr[0] = new Answer() { AnswerID = 1, AnswerText = "True" };
            AnswerArr[1] = new Answer() { AnswerID = 2, AnswerText = "False" };

        }

        public override void InputQuestion()
        {
            
            //Common Function in Base
            base.InputQuestion();

            //True and False Qusetion
            int RightAnswerId;
            Console.WriteLine("-------------------");
            do
            {
                Console.Write("Please Enter The Right Answer of question (1 for true and 2 for False): ");
            } while (!int.TryParse(Console.ReadLine(), out RightAnswerId) || (RightAnswerId != 1 && RightAnswerId != 2));

            //Store The Right Answer 
            RightAnswer.AnswerID = RightAnswerId;
            RightAnswer.AnswerText = AnswerArr[RightAnswerId - 1].AnswerText;

        }
        

        public override string ToString()
        {
            return $"{HeaderOfQuestion}\t Mark({Mark})\n{BodyOfQuestion}";
        }
    }
}
