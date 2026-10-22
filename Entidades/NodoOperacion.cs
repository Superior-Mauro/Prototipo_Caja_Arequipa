#nullable disable
using BilleteraCajaArequipa;

namespace Prototipo___Caja_Arequipa.Dependencias
{
    // 2. Nodo dinámico fundamental
    public class NodoOperacion
    {
        public Operacion Datos { get; set; }
        public NodoOperacion Siguiente { get; set; } // Puntero al siguiente elemento

        public NodoOperacion(Operacion datos)
        {
            Datos = datos;
            Siguiente = null;
        }
    }
}