using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class FinalExam : Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
                Questions = new Question[NumberOfQuestions];
        }
        public override void ShowExam()
        {
            Console.Clear();
            double UG = 0;
            double EG = 0;
            int i = 1;
            foreach (Question question in Questions)
            {
                Console.Write($"Question {i}: ");
                question.ShowQuestion();
                // Console.WriteLine($"Question {i}: {question}");
                Console.WriteLine($"Your Answer: {question.UserAnswer}");
                Console.WriteLine($"Right Answer: {question.RightAnswer}");
                UG += question.ShowUserGrade();
                EG += question.Mark;
                i++;
            }

            Console.WriteLine($"Your Grade = {UG} from {EG}");
        }


    }
}
