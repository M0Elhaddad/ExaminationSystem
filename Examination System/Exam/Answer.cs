using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    public class Answer
    {
        #region Properties
        public int AnswerID { get; set; }
        public string? AnswerText { get; set; } 

        #endregion


        public override string ToString()
        {
            return $"{AnswerID}.  {AnswerText}\t\t";
        }


    }
}
