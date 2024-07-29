using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class MCQ : Question
    {

        public int NumberOfChoices { get; set; }

        public MCQ()
        {

        }

        public MCQ(Header header, string body, double mark, int numberOfChoices) : base(header, body, mark)
        {
            NumberOfChoices = numberOfChoices;
            AnswerList = new Answers[NumberOfChoices];
        }

        public override string ToString()
        {
            return $"{this.Headerr} Question \t \t \t \t Mark: {this.Mark}\n{this.Body}";
        }

        public override void ShowQuestion()
        {

            Console.Write($"{this.Headerr} Question: ");
            Console.WriteLine($"{this.Body} \t Mark: {this.Mark}");
            if (AnswerList?.Length != 0)
            {
                for (int i = 0; i < AnswerList.Length; i++)
                {
                    Console.WriteLine($"{AnswerList[i].AnswerId}. {AnswerList[i].AnswerText}");
                }
            }
        }
    }
}
