using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectid,string subjectname)
        {
            SubjectId = subjectid;
            SubjectName = subjectname;
        }
        //Method To Create Exam
        public void CreateExam()
        {
            int TypeofExam, TimeOfExam, NumberOfQuestions;
            //Take The type of Exam from the User
            do
            {
                Console.Write("Please Enter The Type of Exam You Want To Create (1 for Practical||2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out TypeofExam) || (TypeofExam != 1 && TypeofExam != 2));
            //Take The Time of Exam from the User
            do
            {
                Console.Write("Please Enter The Time of Exam in Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out TimeOfExam) || TimeOfExam < 1);
            //Take The Number of Question from the User
            do
            {
                Console.Write("Please Enter The Number Of Questions You Want To Create: ");
            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions) || NumberOfQuestions < 1);

            Console.Clear();

            if (TypeofExam == 1)
            {
                //Dynamic Binding 
                Exam = new PracticalExam(NumberOfQuestions, TimeOfExam);
            }
            else
            {
                //Dynamic Binding 
                Exam = new FinalExam(NumberOfQuestions, TimeOfExam);
            }

            Console.Clear();

            Exam.CreateQuestionArr();
        }

    }
}
