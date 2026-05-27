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

<img width="1457" height="687" alt="saga" src="https://github.com/user-attachments/assets/90349722-2266-40c8-b506-99dc1d1754e6" />
