# Simulación de Peluquería - Threads y Semaphore

Programa desarrollado en C# para simular el funcionamiento de una peluquería con cinco peluqueros disponibles para atender a los clientes.

Cada cliente se representa mediante un Thread, mientras que un Semaphore controla el acceso a las cinco cabinas disponibles. De esta forma, se permite atender simultáneamente hasta cinco clientes y se hace esperar a los demás hasta que se libere un espacio.

Los clientes llegan en intervalos aleatorios de entre 2 y 8 segundos, mientras que el tiempo de atención de cada peluquero varía entre 2 y 14 segundos.

# Tecnologías utilizadas

C#

.NET

Thread

Semaphore

System.Threading

# Configuración e instalación

Instalar un entorno compatible con C# y con el framework utilizado por el proyecto.

Abrir la solución o el proyecto ubicado en la carpeta PeluqueriaSim.

Verificar que el entorno tenga disponibles las dependencias necesarias.

Ejecutar el programa desde el entorno de desarrollo.

# Funcionamiento

La simulación permite observar cómo se administran recursos limitados cuando varios procesos intentan utilizarlos al mismo tiempo. El semáforo evita que se exceda la capacidad de atención de la peluquería.
