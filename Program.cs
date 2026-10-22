#nullable disable
using Prototipo___Caja_Arequipa.Dependencias;
using Prototipo___Caja_Arequipa.Estructuras;
using System;
using System.Collections.Generic;

namespace BilleteraCajaArequipa.Logica
{

    // 6. Programa principal (Simulación en Consola)
    class Program
    {
        static void Main(string[] args)
        {
            ColaTransacciones cola = new ColaTransacciones();
            PilaReversiones pila = new PilaReversiones();
            ListaHistorial historial = new ListaHistorial();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== BILLETERA CAJA AREQUIPA - SIMULADOR INTERACTIVO ===");
                Console.WriteLine("1. Recibir nueva transacción del usuario (Encolar - FIFO)");
                Console.WriteLine("2. Procesar siguiente en la cola (Desencolar y Apilar)");
                Console.WriteLine("3. Revertir último abono errado (Desapilar - LIFO)");
                Console.WriteLine("4. Consultar registro completo (Mostrar Lista Enlazada)");
                Console.WriteLine("5. Salir del simulador");
                Console.Write("\nSeleccione una opción (1-5): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el monto de la nueva transferencia: S/ ");
                        // Se valida que el numero sea mayor a 0, para que no ingrese montos negativos o 0 en las transacciones.
                        if (decimal.TryParse(Console.ReadLine(), out decimal monto) && monto > 0 && monto <= 100000)
                        {
                            // Generamos un código aleatorio para la operación
                            string codigo = "OP" + new Random().Next(1000, 9999);
                            Operacion nuevaOp = new Operacion(codigo, monto, "Transferencia Entrante");

                            cola.Encolar(nuevaOp);
                            Console.WriteLine($"\n[ÉXITO] Operación {codigo} por S/ {monto} encolada correctamente en la memoria.");
                        }
                        else
                        {
                            Console.WriteLine("\n[ERROR] Por favor ingrese un monto numérico válido.");
                        }
                        break;

                    case "2":
                        Operacion procesada = cola.Desencolar();
                        if (procesada != null)
                        {
                            pila.Apilar(procesada);         // Preparamos para un posible reverso
                            historial.Registrar(procesada); // Histórico inmutable
                            Console.WriteLine($"\n[PROCESADO] La operación {procesada.CodigoOperacion} de S/ {procesada.Monto} fue procesada y registrada.");
                        }
                        else
                        {
                            Console.WriteLine("\n[INFO] La cola de llegadas está vacía. No hay nada que procesar.");
                        }
                        break;

                    case "3":
                        Operacion revertida = pila.Desapilar();
                        if (revertida != null)
                        {
                            Console.WriteLine($"\n[REVERSIÓN EXITOSA] Se deshizo el abono: {revertida.CodigoOperacion} por S/ {revertida.Monto}");

                            // Guardamos la evidencia del reverso en la lista enlazada
                            Operacion reversaHistorial = new Operacion("REV-" + revertida.CodigoOperacion, revertida.Monto, "Reversión");
                            historial.Registrar(reversaHistorial);
                        }
                        else
                        {
                            Console.WriteLine("\n[INFO] No hay operaciones recientes en la pila para revertir.");
                        }
                        break;

                    case "4":
                        historial.ImprimirHistorial();
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("\nCerrando simulador...");
                        break;

                    default:
                        Console.WriteLine("\n[ERROR] Opción no válida. Intente de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}