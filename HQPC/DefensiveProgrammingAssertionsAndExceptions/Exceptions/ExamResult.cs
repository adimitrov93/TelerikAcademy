using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade cannot be less than 0.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "Minimum grade cannot be less than 0.");
        }

        if (minGrade >= maxGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Maximum grade must be bigger than minimum grade.");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("comments", "Comments cannot be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
