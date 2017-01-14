using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public class SucessorVazioTres : RegrasCalculoNoSucessor
    {
        public override IEnumerable<No> AchaSucessor(No no)
        {
            var resultado = new List<No>();

            AdicionaSucessor((NoQuebraCabeca)no, resultado, 0);
            AdicionaSucessor((NoQuebraCabeca)no, resultado, 4);
            AdicionaSucessor((NoQuebraCabeca)no, resultado, 6);

            return resultado;
        }

        public override bool Match(No no)
        {
            return ((NoQuebraCabeca)no).EspacoVazioIndex == 3;
        }
    }
}
