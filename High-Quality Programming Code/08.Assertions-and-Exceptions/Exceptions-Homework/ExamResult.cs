using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade can not be less than zero");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimal grade can not be less than zero");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade can not be less than minimal grade");
        }
        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("Comments can not be null or empty");
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
