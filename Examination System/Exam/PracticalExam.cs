using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    public class PracticalExam :Exam
    {
        #region Constractor
        public PracticalExam(int numberOfQuestion, int timeOfExam) : base(numberOfQuestion, timeOfExam)
        {

        } 
        #endregion

        public override void CreateQuestionArr()
        {
            QuestionArr = new MCQOneChoice[NumberOfQuestions];
            for(int i = 0;i < NumberOfQuestions;i++)
            {
                QuestionArr[i]= new MCQOneChoice();
                QuestionArr[i].InputQuestion();
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            Console.Clear() ;
            foreach(QuestionBase Question in QuestionArr)
            {
                //Print To String in QuestionBase Class
                Console.WriteLine(Question);
                //Print The Answers of Qusetion 
                for (int i = 0; i < Question.AnswerArr.Length; i++)
                    Console.Write(Question.AnswerArr[i]);

                Console.WriteLine("\n-----------------------------");

                //Take The Answer From The Student
                int UserAnswerID;
                while ((!int.TryParse(Console.ReadLine(), out UserAnswerID)) || (UserAnswerID != 1 && UserAnswerID != 2 && UserAnswerID != 3));

                //Store The Answer was Taken from The student 
                Question.UserAnswer.AnswerID = UserAnswerID;
                Question.UserAnswer.AnswerText = Question.AnswerArr[UserAnswerID - 1].AnswerText;

                Console.WriteLine("======================================");

            }


            Console.Clear() ;

            //To Make Font Color Green
            Console.ForegroundColor = ConsoleColor.Green;


            //Print The Right Answer Of Qusetion
            Console.WriteLine("Right Answers:");
            for (int i = 0;i< QuestionArr.Length;i++)
            {
                Console.WriteLine($"Right Answer Of Question ({i + 1}) : {QuestionArr[i].RightAnswer.AnswerText}");
            }
        }
    }
}
