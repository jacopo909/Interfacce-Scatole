using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_Scatole
{
    public class Cerchio : FiguraGeometrica
    {
        public double Raggio { get; set; }
        public Cerchio(double raggio) : base(raggio)
        {
            Raggio = raggio;   
        }

        public override string GetDescrizione() => "Figura Cerchio" +
            $"\nValore: {valore}";
        public override double GetPerimetro() => Raggio += Math.PI;
        public override double GetArea() => (Raggio * Raggio) * Math.PI;
        
    }
}
