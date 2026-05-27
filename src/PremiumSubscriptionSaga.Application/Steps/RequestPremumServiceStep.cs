using PremiumSubscriptionSaga.Application.Exceptions;
using PremiumSubscriptionSaga.Domain;

namespace PremiumSubscriptionSaga.Application.Steps
{
    public class RequestPremumServiceStep : ISagaStep
    {
        public string Name => "RequestPremumServiceStep";

        public Task CompensateAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Compensación: Baja al servicio Premium para el usuario {context.UserId}.");
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(SagaContext context)
        {
            Console.WriteLine($"[{Name}] Verificando cuenta activa y elegibilidad para el usuario {context.UserId}.");

            if(string.IsNullOrEmpty(context.UserId))
            {
                throw new StepException("El usuario no tiene una cuenta activa o no es elegible.");
            }

            if(string.IsNullOrEmpty(context.PlanName))
            {
                throw new StepException("El usuario no ha seleccionado un plan válido.");
            }

            Console.WriteLine($"[{Name}] Alta al servicio Premium para el usuario {context.UserId}.");

            return Task.CompletedTask;
        }
    }
}
