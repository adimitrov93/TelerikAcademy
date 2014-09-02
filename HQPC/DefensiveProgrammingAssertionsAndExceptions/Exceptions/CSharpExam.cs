using System;

public class CSharpExam : Exam
{
    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("score", "Score cannot be less than 0.");
        }
        else if (score > 100)
        {
            throw new ArgumentOutOfRangeException("score", "Score cannot be more than 100.");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
