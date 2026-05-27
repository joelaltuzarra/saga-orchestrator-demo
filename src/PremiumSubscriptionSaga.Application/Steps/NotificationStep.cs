using PremiumSubscriptionSaga.Application.Exceptions;
using PremiumSubscriptionSaga.Domain;

namespace PremiumSubscriptionSaga.Application.Steps
{
    public class NotificationStep : ISagaStep
    {
        public string Name => "NotificationStep";
        public Task CompensateAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Compensación: Revocando acceso y enviando notificación de fallo al usuario {context.UserId}.");
            return Task.CompletedTask;
        }
        public Task ExecuteAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Activando acceso y enviando notificación de éxito al usuario {context.UserId}.");

            if(context.UserId == "Error notificacion")
            {
                throw new StepException("Error en la notificación.");
            }

            return Task.CompletedTask;
        }
    }
}
