using Examination_System.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    internal class MCQOneChoice : QuestionBase
    {

        public override string HeaderOfQuestion => "Choose One Answer Question";

        #region Constructor
        public MCQOneChoice()
        {
            AnswerArr = new Answer[3];
        } 
        #endregion

        //Take inputs from User and store it in Answer Class
        public override void InputQuestion()
        {

            //Common Method in Base
            base.InputQuestion();


            //Choices of MCQ
            Console.WriteLine("The Choice of Question: ");

            for (int i = 0; i < 3; i++)    
            {
                AnswerArr[i] = new Answer()
                { AnswerID=i+1 };

                do
                {
                    Console.Write($"Please Enter the Choise Number {i+1}: ");
                    AnswerArr[i].AnswerText = Console.ReadLine()??"";
                } while (string.IsNullOrWhiteSpace(AnswerArr[i].AnswerText));
                

            }
            Console.WriteLine("-------------------");
            //The Right Choice
            int RightAnswerID;
            do
            {
                Console.Write("Please Specify The Right Choice Of Question: ");
            } while (!int.TryParse(Console.ReadLine(),out RightAnswerID)|| (RightAnswerID != 1&& RightAnswerID != 2 && RightAnswerID != 3));

            //Store The Right Answer 
            RightAnswer.AnswerID= RightAnswerID;
            RightAnswer.AnswerText= AnswerArr[RightAnswerID-1].AnswerText;

            
        }


    }
}
