using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public class SucessorVazioDois : RegrasCalculoNoSucessor
    {
        public override IEnumerable<No> AchaSucessor(No no)
        {
            var result = new List<No>();

            AdicionaSucessor((NoQuebraCabeca)no, result, 1);
            AdicionaSucessor((NoQuebraCabeca)no, result, 5);

            return result;
        }

        public override bool Match(No no)
        {
            return ((NoQuebraCabeca)no).EspacoVazioIndex == 2;
        }
    }
}

