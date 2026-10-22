#nullable disable
using BilleteraCajaArequipa;

namespace Prototipo___Caja_Arequipa.Dependencias
{
    // 1. Entidad de negocio
    public class Operacion
    {
        public string CodigoOperacion { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaHora { get; set; }

        public Operacion(string codigo, decimal monto, string tipo)
        {
            CodigoOperacion = codigo;
            Monto = monto;
            Tipo = tipo;
            FechaHora = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{CodigoOperacion}] - {Tipo} : S/ {Monto} ({FechaHora:HH:mm:ss})";
        }
    }
}