using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_Scatole
{
    public class Selettore : Contenitore
    {
       
        PoliticaSelezione politica;
        public void ScansionaContenitore(Contenitore c)
        {
            if (politica != null)
                foreach (FiguraGeometrica f in c.FigureGeometrica)
                {
                    if (politica.Selezione(f))
                        AggiungiFigura(f);
                }
        }
        public void ImpostaPolitica(PoliticaSelezione politica)
        {
            this.politica = politica;
        }
    }
}
