using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplicationTeste1
{
    public interface No
    {
        float F { get; set; } // G + H
        float G { get; set; } // Custo do caminho até o momento
        float H { get; set; } // Custo heurístico até o objetivo
        No Pai { get; set; }

        bool EstadoIgual(No node);
    }
}
