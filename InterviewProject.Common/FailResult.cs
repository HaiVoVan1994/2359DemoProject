namespace InterviewProject.Common
{
    public class FailResult<T> : RequestResult<T>
    {
        public FailResult(string reason)
        {
            FailureReason = reason;
        }

        public string FailureReason { get; }
    }
}
