using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PeluqueriaSim
{
    internal class Program
    {
        private static Semaphore semaforo = new Semaphore(5, 5);
        private static Random random = new Random();
        private static object lockConsola = new object();
        private static Dictionary<int, long> tiemposEspera = new Dictionary<int, long>();
        private static Stopwatch tiempoTotal = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("5 peluqueros disponibles");


            tiempoTotal.Start();
            Thread[] clientes = new Thread[20];

            for(int i = 0; i < 20; i++)
            {
                int numeroCliente = i + 1;
                clientes[i] = new Thread(() => AtenderCliente(numeroCliente));
            }

            for (int i = 0; i < 20; i++)
            {
                clientes[i].Start();

                int tiempoLlegada;
                lock (lockConsola) { tiempoLlegada = random.Next(500, 2001); }
                Thread.Sleep(tiempoLlegada);
            }

            foreach (Thread cliente in clientes)
            {
                cliente.Join();
            }

            MostrarEstadisticas();
        }

        static void AtenderCliente(int numeroCliente)
        {
            Stopwatch tiempoEspera = new Stopwatch();
            tiempoEspera.Start();

            lock (lockConsola)
            {
                Console.WriteLine($"Cliente {numeroCliente} llega al centro de atención.");
            }

            semaforo.WaitOne();

            tiempoEspera.Stop();

            lock (lockConsola)
            {
                tiemposEspera[numeroCliente] = tiempoEspera.ElapsedMilliseconds;
            }

            lock (lockConsola)
            {
                Console.WriteLine($"--> Cliente {numeroCliente} está siendo atendido en una cabina.");
            }

            int tiempoAtencion;
            lock (lockConsola) { tiempoAtencion = random.Next(2000, 14001); }
            Thread.Sleep(tiempoAtencion);

            lock (lockConsola)
            {
                Console.WriteLine($"<-- Cliente {numeroCliente} terminó su atención y deja la cabina.");
            }

            semaforo.Release();
        }

        static void MostrarEstadisticas()
        {
            Console.WriteLine($"\n1. TIEMPO TOTAL DE TRABAJO:");
            Console.WriteLine($"   {tiempoTotal.ElapsedMilliseconds / 1000.0:F2} segundos ({tiempoTotal.ElapsedMilliseconds} ms)");

            Console.WriteLine($"\n2. TIEMPO DE ESPERA POR CLIENTE:");

            long totalEspera = 0;
            long esperaMaxima = 0;
            long esperaMinima = long.MaxValue;

            var listaOrdenada = tiemposEspera.OrderBy(x => x.Key).ToList();
            foreach (var kvp in listaOrdenada)
            {
                int cliente = kvp.Key;
                long espera = kvp.Value;

                Console.WriteLine($"   Cliente {cliente,2}: {espera / 1000.0,6:F2} segundos ({espera,5} ms)");

                totalEspera += espera;
                if (espera > esperaMaxima) esperaMaxima = espera;
                if (espera < esperaMinima) esperaMinima = espera;
            }

            double esperaPromedio = totalEspera / (double)tiemposEspera.Count;
        }
    }
}
