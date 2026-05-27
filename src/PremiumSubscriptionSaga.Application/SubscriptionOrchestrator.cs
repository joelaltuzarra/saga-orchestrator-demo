using PremiumSubscriptionSaga.Application.Exceptions;
using PremiumSubscriptionSaga.Domain;

namespace PremiumSubscriptionSaga.Application
{
    public class SubscriptionOrchestrator
    {
        private readonly IEnumerable<ISagaStep> _steps;

        public SubscriptionOrchestrator(IEnumerable<ISagaStep> steps)
        {
            _steps = steps;
        }

        public async Task ExecuteSagaAsync(SagaContext context)
        {
            var executedSteps = new Stack<ISagaStep>();
            try
            {
                foreach (var step in _steps)
                {
                    await step.ExecuteAsync(context);
                    executedSteps.Push(step);
                }

                Console.WriteLine("Saga completada exitosamente.");
            }
            catch (StepException ex)
            {
                Console.WriteLine($"Error en la ejecución del paso: {ex.Message}. Iniciando compensación...");
                context.HasFailed = true;
                while (executedSteps.Count > 0)
                {
                    var step = executedSteps.Pop();
                    await step.CompensateAsync(context);
                }

                Console.WriteLine("Saga completada con errores.\n");
            }
        }
    }
}
