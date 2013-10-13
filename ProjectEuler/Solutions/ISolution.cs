namespace Solutions
{
    public interface ISolution
    {
        string ProblemId { get; }
        string Execute();
    }
}
