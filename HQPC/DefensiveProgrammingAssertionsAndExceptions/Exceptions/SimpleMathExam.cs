using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "Problems solved count cannot be less than 0. Must be between 0 and 2 inclusively.");
        }

        if (problemsSolved > 2)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "Problems solved count cannot be more than 2. Must be between 0 and 2 inclusively.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: something done.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Good result: everything done.");
        }
    }
}
