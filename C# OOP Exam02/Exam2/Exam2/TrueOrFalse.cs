using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class TrueOrFalse : Question
    {

        public TrueOrFalse(Header header, string body, double mark) :base(header, body, mark)
        {
            AnswerList = new Answers[2];
            AnswerList[0] = new Answers(1, "True");
            AnswerList[1] = new Answers(2, "False");
        }
        public override void ShowQuestion()
        {

            Console.Write($"{this.Headerr} Question: ");
            Console.WriteLine($"{this.Body} \t Mark: {this.Mark}");
        }

    }
}