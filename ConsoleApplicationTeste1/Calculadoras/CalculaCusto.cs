using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.Calculators
{
    public class CalculaCusto : CalculaValorG
    {
        private const float FatorCusto = 0.265f; // Tentativa e pesquisa online

        public float Executar(No no)
        {
            return no.G + FatorCusto;
        }

    }

}