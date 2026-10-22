#nullable disable
using BilleteraCajaArequipa;
using Prototipo___Caja_Arequipa.Dependencias;

namespace Prototipo___Caja_Arequipa.Estructuras
{
    // 5. Estructura 3: Lista enlazada simple para el historial general
    public class ListaHistorial
    {
        private NodoOperacion inicio;
        private NodoOperacion fin;

        public void Registrar(Operacion op)
        {
            NodoOperacion nuevoNodo = new NodoOperacion(op);
            if (inicio == null)
            {
                inicio = nuevoNodo;
                fin = nuevoNodo;
            }
            else
            {
                fin.Siguiente = nuevoNodo;
                fin = nuevoNodo;
            }
        }

        public void ImprimirHistorial()
        {
            Console.WriteLine("\n=== HISTORIAL GENERAL DE MOVIMIENTOS ===");
            NodoOperacion actual = inicio;
            if (actual == null)
            {
                Console.WriteLine("El historial está vacío.");
            }
            while (actual != null)
            {
                Console.WriteLine(actual.Datos.ToString());
                actual = actual.Siguiente;
            }
            Console.WriteLine("========================================\n");
        }
    }
}