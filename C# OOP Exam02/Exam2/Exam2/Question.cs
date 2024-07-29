using System;
using System.Collections.Generic;
using System.Text;
namespace Exam2
{
    internal abstract class Question 
    {
        public  Header Headerr { get; set; } // ==> (1 for MCQ) , (2 for True Or False)
        public  string Body { get; set; }
        public  double Mark { get; set; }
        public  Answers[] AnswerList { get; set; }
        public  int RightAnswer { get; set; }
        public int UserAnswer { get; set; }
        public Question(Header header, string body, double mark)
        {
            Headerr = header;
            Body = body;
            Mark = mark;
        }

        public Question()
        {

        }

        //public override string ToString()
        //{
        //    return $"{this.Headerr} Question \t \t \t \t Mark: {this.Mark}\n{this.Body}";
        //}
        public abstract void ShowQuestion();
        public double ShowUserGrade()
        {
            double Grade = 0;
            if (this.UserAnswer == RightAnswer) Grade += Mark;
            else Grade += 0;
            return Grade;
        }

    }
}
