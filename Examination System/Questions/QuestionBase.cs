using Examination_System.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public abstract class QuestionBase
    {
        #region Properties

        public abstract string HeaderOfQuestion { get; }
        public string? BodyOfQuestion { get ; set; }
        public int Mark { get ; set ; }
        public Answer[] AnswerArr { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }
        #endregion


        #region Constructor
        public QuestionBase()
        {
            RightAnswer= new Answer();
            UserAnswer = new Answer();
        }
        #endregion


        //abstract Method
        public virtual void InputQuestion()
        {
            //Contain a Common Code between TFQuestion and MCQ

            //Header
            Console.WriteLine(HeaderOfQuestion);
            Console.WriteLine("=========================");
            //Body 
            do
            {
                Console.WriteLine("Please Enter The Body Of Qusetion:");
                BodyOfQuestion = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(BodyOfQuestion));

            int mark;
            //Mark 
            do
            {
                Console.WriteLine("Enter The Mark of Question:");
            } while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1);
            Mark = mark;
        }


        

       
        public override string ToString()
        {
            return $"{HeaderOfQuestion} \t\t Marks:({Mark}) \n{BodyOfQuestion} \n";
        }
        
    }
}
