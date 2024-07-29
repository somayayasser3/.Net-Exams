using System;
using System.Diagnostics;
using System.Threading;

namespace Exam2
{
    class Program
    {
        public static void GetDataFromUserForExam()
        {
            bool flag;
            SubjectEnum Sub;
            do
            {
                Console.WriteLine("Please Enter the Subject Name: ");
                flag = Enum.TryParse<SubjectEnum>(Console.ReadLine(), true, out Sub);
            }while (!flag);

            int ExamNumber;
            do
            {
                Console.WriteLine("Please Enter The Type Of The Exam (1 for Practical | 2 for Final) ");
                flag = int.TryParse(Console.ReadLine(), out ExamNumber);
            } while (!flag || !(ExamNumber <= 2) || ExamNumber <= 0);

            int ExamTime;
            do
            {
                Console.WriteLine("Please Enter The Time Of The Exam from (30 min to 180 min) ");
                flag = int.TryParse(Console.ReadLine(), out ExamTime);
            } while (!flag || (ExamTime == 0) /*|| ExamTime > 180 || ExamTime < 30*/ );

            int NumofQuestions;
            do
            {
                Console.WriteLine("Please Enter The Number Of Questions ");
                flag = int.TryParse(Console.ReadLine(), out NumofQuestions );
            } while (!flag || NumofQuestions <= 0);

            Exam Pexam = new PracticalExam(ExamTime, NumofQuestions); // as a default for abstract Exam Class
            Subject subject = new Subject((int)Sub, Sub, Pexam );
            Exam exam = subject.CreateExam(Pexam, ExamNumber);
            Console.Clear();
            if (ExamNumber == 1)
                GetDataOfQuestionFromUserForPracticalExam(exam);
            else
                GetDataOfQuestionFromUserForFinalExam(exam);
            Console.WriteLine("Do You Want to Start The Exam [Yes|No]");
            string YorN = Console.ReadLine();
            Console.Clear();
            int YourAnswer;
            if (string.Equals(YorN, "Yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Exam Time: {exam.TimeOfExam} Mins");
                TimeSpan start = DateTime.Now.TimeOfDay;
                Console.WriteLine($"Start: {start}");
                TimeSpan Limit = TimeSpan.FromMinutes(exam.TimeOfExam);
                TimeSpan end = start.Add(Limit);
                Console.WriteLine($"End: {end}");
                TimeSpan t = DateTime.Now.TimeOfDay;
                for (int k = 0; k < exam.NumberOfQuestions; k++)
                {
                    if (t.Subtract(end) < TimeSpan.FromSeconds(0))
                    {

                        exam.Questions[k].ShowQuestion();
                        // Console.WriteLine(exam.Questions[k]);

                        do
                        {
                            Console.WriteLine("Please Enter Your AnswerId: ");
                            int.TryParse(Console.ReadLine(), out YourAnswer);


                        } while (!flag || YourAnswer > exam.Questions[k].AnswerList.Length);
                        exam.Questions[k].UserAnswer = YourAnswer;
                        t = DateTime.Now.TimeOfDay;
                    }
                    else
                    {
                        Console.WriteLine("Time Out!");
                        break;
                    }
                }

                exam.ShowExam();
                Console.WriteLine($"Time: {t.Subtract(start)}");
                Console.WriteLine("Thank You!");
            }
            else
                Environment.Exit(0);
        }

        public static void GetMCQData(Exam exam, int index)
        {
            bool flag;
            Console.WriteLine("\t \t \t MCQ Question");
            Console.WriteLine($"Please Enter Question Body  #{index+1}");
            string body = Console.ReadLine();
            double Mark;
            do
            {
                Console.WriteLine("Please Enter The Mark Of Question");
                flag = double.TryParse(Console.ReadLine(), out Mark);
            } while (!flag || Mark <= 0);
            int Choices;
            do
            {
                Console.WriteLine("Please Enter The Number of Choices");
                flag = int.TryParse(Console.ReadLine(), out Choices);
            } while (!flag || Choices <= 0);
            exam.Questions[index] = new MCQ(Header.MCQ, body, Mark, Choices);
            exam.Questions[index].AnswerList = new Answers[Choices];
            if (exam?.Questions[index]?.AnswerList?.Length != 0)
            {
                for (int j = 0; j < exam.Questions[index].AnswerList.Length; j++)
                {
                    Console.WriteLine($"Please Enter Choice #{ j + 1 }");
                    exam.Questions[index].AnswerList[j]= new Answers(j + 1, Console.ReadLine());
                }
            }
            int RightAnswerID;
            do
            {
                Console.WriteLine("Please Enter The Right Answer ID");
                flag = int.TryParse(Console.ReadLine(), out RightAnswerID);
            } while (!flag || RightAnswerID <= 0 || RightAnswerID > exam.Questions[index].AnswerList.Length);
            exam.Questions[index].RightAnswer = RightAnswerID;
            Console.Clear();
            
        }

        public static void GetTrueOrFalseData(Exam exam, int index)
        {
            Console.WriteLine("\t \t \t TrueOrFalse Question");
            bool flag;
            Console.WriteLine($"Please Enter Question Body #{index + 1}");
            string body = Console.ReadLine();
            double Mark;
            do
            {
                Console.WriteLine("Please Enter The Mark Of Question");
                flag = double.TryParse(Console.ReadLine(), out Mark);
            } while (!flag || Mark <= 0);
            exam.Questions[index] = new TrueOrFalse(Header.TrueOrFalse, body, Mark);

            int RightAnswerID;
            do
            {
                Console.WriteLine("Please Enter The Right Answer ID ( 1 for True , 2 for False)");
                flag = int.TryParse(Console.ReadLine(), out RightAnswerID);
            } while (!flag || RightAnswerID <= 0 || RightAnswerID > 2);
            exam.Questions[index].RightAnswer = RightAnswerID;
             Console.Clear();
        }

        public static void GetDataOfQuestionFromUserForPracticalExam(Exam exam)
        {
            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                  GetTrueOrFalseData(exam,i);
            }
        }
        public static void GetDataOfQuestionFromUserForFinalExam(Exam exam)
        {
            bool flag;
            int QuesNum;
            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                do
                {
                    Console.WriteLine($"Please Enter The Type Of Question #{i+1} (1 for MCQ , 2 for True|False)");
                    flag = int.TryParse(Console.ReadLine(), out QuesNum);
                } while (!flag && (QuesNum != 1 || QuesNum != 2 || QuesNum == 0));
                Console.Clear();
                if (QuesNum == 1)
                    GetMCQData(exam,i);
                else
                    GetTrueOrFalseData(exam,i);
            }
        }
        static void Main(string[] args)
        {
            GetDataFromUserForExam();
            Console.ReadKey();
        }
    }
}
