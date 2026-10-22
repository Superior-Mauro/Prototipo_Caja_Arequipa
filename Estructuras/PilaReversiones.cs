#nullable disable
using BilleteraCajaArequipa;
using Prototipo___Caja_Arequipa.Dependencias;

namespace Prototipo___Caja_Arequipa.Estructuras
{
    // 4. Estructura 2: Pila para reversiones rápidas (LIFO)
    public class PilaReversiones
    {
        private NodoOperacion cima;

        public void Apilar(Operacion op)
        {
            NodoOperacion nuevoNodo = new NodoOperacion(op);
            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;
        }

        public Operacion Desapilar()
        {
            if (cima == null) return null;

            Operacion op = cima.Datos;
            cima = cima.Siguiente;
            return op;
        }
    }
}