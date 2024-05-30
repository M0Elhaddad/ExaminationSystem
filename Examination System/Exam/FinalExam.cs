using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    public class FinalExam :Exam
    {
        public FinalExam(int numberOfQuestion, int timeOfExam):base(numberOfQuestion, timeOfExam)
        {
        }
        public override void CreateQuestionArr()
        {
            QuestionArr = new QuestionBase[NumberOfQuestions];

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int TypeofQuestion;
                //take Type of Question from The user (True | False) Or (MCQ)
                do
                {
                    Console.Write($"Please Choose The Type Of Question Number ({i + 1}): ( 1 for True or false || 2 for MCQ ):");
                } while (!int.TryParse(Console.ReadLine(), out TypeofQuestion) || (TypeofQuestion != 1 && TypeofQuestion != 2));
                Console.Clear();
                //If Type of Exam is (True | False)
                if (TypeofQuestion == 1)
                {
                    Console.WriteLine($"---------------------Question Number {i + 1} ---------------------");
                    QuestionArr[i] = new TFQuestion();
                    //Go to Method in TFQuseton Class To Create True or False Qusetion
                    QuestionArr[i].InputQuestion();

                }
                //If Type of Exam is (MCQ)
                else
                {
                    Console.WriteLine($"---------------------Question Number {i + 1} ---------------------");
                    //Go to Method in MCQOneChoise To Create MCQ Question
                    QuestionArr[i] = new MCQOneChoice();
                    QuestionArr[i].InputQuestion();
                }
                Console.Clear();
            }
        }

        //To Show The Exam After Created
        public override void ShowExam()
        {
            Console.Clear();
            int TotalMarks = 0, Grade = 0;

            foreach(QuestionBase Question in QuestionArr)
            {
                //Print To String in QuestionBase Class
                Console.WriteLine(Question.ToString());

                //Print The Answers of Qusetion 
                for (int i = 0; i < Question.AnswerArr.Length; i++)
                    Console.Write(Question.AnswerArr[i]);

                Console.WriteLine("\n-----------------------------");

                int UserAnswerID;
                //Take The Answer From The Student
                if (Question.GetType().Name == "MCQOneChoice")
                     while ((!int.TryParse(Console.ReadLine(), out UserAnswerID)) || (UserAnswerID != 1 && UserAnswerID != 2 && UserAnswerID != 3));
              
                else
                    while ((!int.TryParse(Console.ReadLine(), out UserAnswerID)) || (UserAnswerID != 1 && UserAnswerID != 2 ));
                //Store The Answer was Taken from The student 
                Question.UserAnswer.AnswerID = UserAnswerID;
                Question.UserAnswer.AnswerText = Question.AnswerArr[UserAnswerID - 1].AnswerText;

                Console.WriteLine("===================================");

                TotalMarks += Question.Mark;

            }
            Console.Clear();
            //To Make Font Color Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Answers:");
            for(int i = 0; i < QuestionArr.Length;i++)
            {
                // If the Right Answer Equal The User Answer increse The Grade by Mark of Question
                if (QuestionArr[i].RightAnswer.AnswerID == QuestionArr[i].UserAnswer.AnswerID)
                    Grade += QuestionArr[i].Mark;
                //Print Body of question And Student Answer
                Console.WriteLine($"Q {i + 1})\t {QuestionArr[i].BodyOfQuestion}: {QuestionArr[i].UserAnswer.AnswerText} ");
            }
            //Print Grade of Student
            Console.WriteLine($"Your Exam Grade is {Grade} from {TotalMarks}");
        }

    }
}
