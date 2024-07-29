using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class Answers 
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answers(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public Answers()
        {

        }

        public override string ToString()
        {
            return $"{AnswerId}- {AnswerText} \n";
        }

    }
}
