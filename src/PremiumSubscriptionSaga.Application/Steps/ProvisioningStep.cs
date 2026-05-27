using PremiumSubscriptionSaga.Application.Exceptions;
using PremiumSubscriptionSaga.Domain;

namespace PremiumSubscriptionSaga.Application.Steps
{
    public class ProvisioningStep : ISagaStep
    {
        public string Name => "ProvisioningStep";

        public Task CompensateAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Compensación: Revirtiendo la provisión del recurso {context.ProvisionedResourceId}.");
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Provisionando recurso para el usuario {context.UserId}.");
            if (context.UserId == "Error provision")
            {
                throw new StepException("El usuario no tiene una cuenta activa o no es elegible para la provisión.");
            }

            context.ProvisionedResourceId = Guid.NewGuid().ToString();
            return Task.CompletedTask;
        }
    }
}
