namespace PremiumSubscriptionSaga.Domain
{
    public class SagaContext
    {
        public string UserId { get; set; } = string.Empty;
        public string PlanName { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string PaymentTransactionId { get; set; } = string.Empty;
        public string ProvisionedResourceId { get; set; } = string.Empty;
        public bool HasFailed { get; set; }
    }
}
