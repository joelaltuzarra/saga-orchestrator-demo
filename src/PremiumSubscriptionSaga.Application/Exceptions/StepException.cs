namespace PremiumSubscriptionSaga.Application.Exceptions
{
    public class StepException : Exception
    {
        public StepException(string message) : base(message)
        {
        }
    }
}
