using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_Scatole
{
    public class PerimetroMinimo : PoliticaSelezione
    {
        public PerimetroMinimo (double soglia) : base(soglia) { }
        public override bool Selezione(FiguraGeometrica f)
        {
            return f.GetPerimetro() >= soglia;
        }
    }
}
