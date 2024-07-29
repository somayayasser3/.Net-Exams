using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2
{
    internal class Subject
    {

        public int SubjectId { get; set; }
        public SubjectEnum SubjectName { get; set; }
        public Exam Examm { get; set; }

        public Subject()
        {

        }

        public Subject(int subjectId, SubjectEnum subjectName, Exam examm)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Examm = examm;
        }

        public Exam CreateExam(Exam exam, int Option)
        {
            if (Option == 1)
            {
                exam = new PracticalExam(exam.TimeOfExam, exam.NumberOfQuestions);
            }
            else if (Option == 2)
            {
                exam = new FinalExam(exam.TimeOfExam, exam.NumberOfQuestions);
            }
            return exam;
        }
    }
}
