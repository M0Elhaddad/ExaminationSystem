using Examination_System.Exam;
using Examination_System.Questions;
using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;


            Subject sub1=new Subject(10,"C#");
            sub1.CreateExam();
            
            char C ;
            do
            {
                Console.Write("IF You Want To Start The Exam Enter ( y ): ");

            } while (!char.TryParse(Console.ReadLine(), out C)||(C!='y' && C!='Y'));

            if(C == 'y'|| C =='Y')
            {
                Stopwatch sw =new Stopwatch();
                sw.Start();
                sub1.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }

            Console.ReadKey();
        }
    }
}
