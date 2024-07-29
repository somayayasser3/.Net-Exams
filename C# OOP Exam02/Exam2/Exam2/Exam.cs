using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal abstract class Exam
    {
        public Question [] Questions { get; set; }
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Exam()
        {

        }

        public Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            // Questions = new Question[NumberOfQuestions];
        }

        public abstract void ShowExam();

    }
}
