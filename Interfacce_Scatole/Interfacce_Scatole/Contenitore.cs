using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_Scatole
{
    public class Contenitore
    {
        private List<FiguraGeometrica> figureGeometriche = new List<FiguraGeometrica>();

        public List<FiguraGeometrica> FigureGeometrica
        {
            get
            {
                return figureGeometriche;
            }
        }

        public Contenitore() { }
        public void AggiungiFigura(FiguraGeometrica f) => figureGeometriche.Add(f);

        public void ElencaFigure()
        {
            foreach (FiguraGeometrica f in figureGeometriche)
            {
                f.GetDescrizione();
            }
        }
        public void Svuota() => figureGeometriche.Clear();
       
    }
}
