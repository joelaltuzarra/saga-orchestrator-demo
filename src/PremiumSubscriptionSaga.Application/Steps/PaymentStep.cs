using PremiumSubscriptionSaga.Application.Exceptions;
using PremiumSubscriptionSaga.Domain;

namespace PremiumSubscriptionSaga.Application.Steps
{
    public class PaymentStep : ISagaStep
    {
        public string Name => "PaymentStep";

        public Task CompensateAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Compensación: Revirtiendo el pago para la transaccion {context.PaymentTransactionId}.");
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Procesando el pago para el plan {context.PlanName} y usuario {context.UserId}.");

            if(context.Amount <= 0)
            {
                throw new StepException("El monto del pago debe ser mayor a cero.");
            }

            context.PaymentTransactionId = Guid.NewGuid().ToString();
            return Task.CompletedTask;
        }
    }
}
