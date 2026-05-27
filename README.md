# Saga Orchestrator Demo
Este repositorio contiene un proyecto de portafolio, demostrando el **Patron Saga** usando un enfoque Orquestador construido con **.NET 10** y principios de **Clean Architecture**

## 📖 Caso de Uso: Proceso de Registro y Activación de Suscripción Premium
El proyecto simula la suscripción de un usuario a un plan "Enterprise". El Orquestador gestiona la ejecución y compensación de 4 instrumentos principales:

1. **Instrumento A (RequestPremumService):** Verifica si el usuario tiene una cuenta activa y realiza la solicitud del servicio premium.
2. **Instrumento B (Payment):** Reserva el cobro en la pasarela de pagos.
3. **Instrumento C (Provisioning):** Reserva recursos en el clúster (Ej. Kubernetes).
4. **Instrumento D (Notification):** Envía el correo de bienvenida y activa el acceso.

<img width="997" height="442" alt="saga-orchestrator drawio" src="https://github.com/user-attachments/assets/1b365d13-96ae-4a26-9701-3fe4ac6cbba5" />

## 🏛️ Arquitectura
El proyecto está dividido en tres capas principales (Domain, Application y Presentation).

<img width="1457" height="687" alt="saga" src="https://github.com/user-attachments/assets/90349722-2266-40c8-b506-99dc1d1754e6" />

## 🚀 Cómo levantar el proyecto

Requisitos previos:
- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.

1. Clona este repositorio:

git clone https://github.com/joelaltuzarra/saga-orchestrator-demo.git cd saga-orchestrator-demo

2. Ejecuta el proyecto de presentación:

dotnet run --project src/PremiumSubscriptionSaga.Presentation

3. Observa en la consola cómo el Orquestador atrapa el error y ejecuta automáticamente los métodos `CompensateAsync` de los pasos anteriores en orden inverso (C -> B -> A).

## 🧪 Cómo probarlo

### 1. Escenario de Éxito (Happy Path)
De forma predeterminada, correr el comando anterior ejecutará los cuatro instrumentos de manera secuencial y la saga se completará exitosamente.

### 2. Escenario de Fallo y Compensación
Para probar la compensación, debes forzar un fallo. 



- Caso 1 Exito
- Caso 2 No selecciona un plan
- Caso 3 No tiene cuenta activa
- Caso 4 Monto del pago inválido
- Caso 5 Error en la provisión
- Caso 6 Error en la notificación
