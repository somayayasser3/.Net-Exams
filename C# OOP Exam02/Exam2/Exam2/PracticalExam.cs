using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class PracticalExam : Exam
    {
        // public TrueOrFalse[] TrueOrFalseQuestions { get; set; }

        public PracticalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
            Questions = new TrueOrFalse[NumberOfQuestions];
        }
        public override void ShowExam()
        {
            Console.Clear();
            double UG = 0;
            double EG = 0;
            int i = 1;
            foreach(TrueOrFalse Ques in Questions)
            {
                Console.Write($"Question {i}: ");
                Ques.ShowQuestion();
                // Console.WriteLine($"Question {i}: {Ques}");
                Console.WriteLine($"Right Answer: {Ques.RightAnswer}");
                UG += Ques.ShowUserGrade();
                EG += Ques.Mark;
                i++;
            }

            Console.WriteLine($"Your Grade = {UG} from {EG}");
        }
    }
}
