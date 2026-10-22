#nullable disable
using BilleteraCajaArequipa;
using Prototipo___Caja_Arequipa.Dependencias;

namespace Prototipo___Caja_Arequipa.Estructuras
{
    // 3. Estructura 1: Cola para picos de llegada (FIFO)
    public class ColaTransacciones
    {
        private NodoOperacion frente;
        private NodoOperacion final;

        public void Encolar(Operacion op)
        {
            NodoOperacion nuevoNodo = new NodoOperacion(op);
            if (frente == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        public Operacion Desencolar()
        {
            if (frente == null) return null;

            Operacion op = frente.Datos;
            frente = frente.Siguiente;
            if (frente == null) final = null;

            return op;
        }
    }
}