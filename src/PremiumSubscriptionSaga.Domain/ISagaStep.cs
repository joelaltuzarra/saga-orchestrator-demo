namespace PremiumSubscriptionSaga.Domain
{
    public interface ISagaStep
    {
        string Name { get; }
        Task ExecuteAsync(SagaContext context);
        Task CompensateAsync(SagaContext context);
    }
}
