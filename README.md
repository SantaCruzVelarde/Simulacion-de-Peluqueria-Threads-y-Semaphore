# Simulación de Peluquería - Threads y Semaphore

Programa realizado para simular el funcionamiento de una peluquería con cinco peluqueros disponibles para atender clientes.

Los clientes llegan de manera aleatoria y cada uno representa un Thread. Para controlar el acceso a las cinco cabinas disponibles se utiliza un Semaphore, permitiendo que solamente cinco clientes sean atendidos al mismo tiempo.

**Tecnologías utilizadas**

C# 

Threads

Semaphore

**Funcionamiento**

Los clientes llegan en intervalos aleatorios de entre 2 y 8 segundos. Cada peluquero tarda entre 2 y 14 segundos en atender a un cliente.

Cuando las cinco cabinas están ocupadas, los nuevos clientes deben esperar hasta que alguna quede disponible.
