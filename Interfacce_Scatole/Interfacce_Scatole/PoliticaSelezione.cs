using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_Scatole
{
    public abstract class PoliticaSelezione
    {
        protected double soglia;
        public PoliticaSelezione(double soglia)
        {
            this.soglia = soglia;
        }
        public abstract bool Selezione(FiguraGeometrica f);
    }
}
