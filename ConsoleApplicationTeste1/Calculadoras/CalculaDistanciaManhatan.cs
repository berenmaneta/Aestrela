using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.Calculators
{
    public class CalculaDistanciaManhatan : CalculaValorH
    {
        private const float FatorCusto = 1.0f;

        public float Executar(No objetivo, No no)
        {
            float resultado = 0.0f;
            var noCorrente = no as NoQuebraCabeca;
            var noObjetivo = objetivo as NoQuebraCabeca;

            for (int i = 0; i < 9; i++)
            {
                if (noObjetivo == null) continue;
                int numeroCorrente = noObjetivo.Espaco[i];
                int indexCorrente = AchaIndexCorrente(numeroCorrente, noCorrente);

                resultado = DistanciaAteObjetivo(resultado, i, indexCorrente);
            }

            return resultado;
        }

        private static float DistanciaAteObjetivo(float resultado, int i, int indexCorrente)
        {
            if (indexCorrente == i + 0)
                return resultado;

            if (indexCorrente == i + 1 || indexCorrente == i + 3)
                resultado += FatorCusto;
            else if (indexCorrente == i + 2 || indexCorrente == i + 4 || indexCorrente == i + 6)
                resultado += 2 * FatorCusto;
            else if (indexCorrente == i + 5 || indexCorrente == i + 7)
                resultado += 3 * FatorCusto;
            else if (indexCorrente == i + 8)
                resultado += 4 * FatorCusto;
            return resultado;
        }

        private static int AchaIndexCorrente(int objetivo, NoQuebraCabeca corrente)
        {
            for (int j = 0; j < 9; j++)
            {
                if (corrente.Espaco[j] == objetivo)
                {
                    return j;
                }
            }

            return -1;
        }
    }
}