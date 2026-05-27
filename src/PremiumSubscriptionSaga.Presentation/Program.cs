using PremiumSubscriptionSaga.Application;
using PremiumSubscriptionSaga.Application.Steps;
using PremiumSubscriptionSaga.Domain;

Console.WriteLine("Caso 1 exitoso\n");
var steps = new List<ISagaStep>
{
    new ValidatorStep(),
    new PaymentStep(),
    new ProvisioningStep(),
    new NotificationStep()
};

var orchestrator = new SubscriptionOrchestrator(steps);
var context = new SagaContext { UserId = "user123", PlanName = "Enterprise", Amount = 100 };

Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

Console.WriteLine("Caso 2 No selecciona un plan\n");
context = new SagaContext { UserId = "user123", PlanName = "", Amount = 100 };

Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

Console.WriteLine("Caso 3 No tiene una cuenta activa\n");
context = new SagaContext { UserId = "", PlanName = "Enterprise", Amount = 100 };

Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

Console.WriteLine("Caso 4 Monto del pago inválido\n");
context = new SagaContext { UserId = "user123", PlanName = "Enterprise", Amount = -50 };

Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

Console.WriteLine("Caso 5 Error en la provisión\n");
context = new SagaContext { UserId = "Error provision", PlanName = "Enterprise", Amount = 100 };
Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

Console.WriteLine("Caso 6 Error en la notificación\n");
context = new SagaContext { UserId = "Error notificacion", PlanName = "Enterprise", Amount = 100 };
Console.WriteLine("Iniciando el proceso de suscripción premium...\n");
await orchestrator.ExecuteSagaAsync(context);

