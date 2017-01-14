using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public class SucessorVazioZero : RegrasCalculoNoSucessor
    {
        public override IEnumerable<No> AchaSucessor(No no)
        {
            var resultado = new List<No>();

            AdicionaSucessor((NoQuebraCabeca)no, resultado, 1);
            AdicionaSucessor((NoQuebraCabeca)no, resultado, 3);

            return resultado;
        }

        public override bool Match(No no)
        {
            return ((NoQuebraCabeca)no).EspacoVazioIndex == 0;
        }
    }
}