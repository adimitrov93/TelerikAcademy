using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException("firstName", "First name cannot be null or empty.");
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException("lastName", "Last name cannot be null or empty.");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new NullReferenceException("Exams is null.");
        }

        if (this.Exams.Count == 0)
        {
            throw new Exception("The list of exams is empty.");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new NullReferenceException("Exams is null.");
        }

        if (this.Exams.Count == 0)
        {
            throw new Exception("The list of exams is empty.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = ((double)examResults[i].Grade - examResults[i].MinGrade) / (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
