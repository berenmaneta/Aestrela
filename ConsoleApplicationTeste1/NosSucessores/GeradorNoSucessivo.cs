using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationTeste1.SuccessorNodes;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public class GeradorNoSucessivo : GeradorNoSucessor
    {

        public IEnumerable<No> Executar(No noCorrente)
        {
            var node = noCorrente as NoQuebraCabeca;

            var regrasSucessor =
                new List<RegrasGeradorNoSucessivo>
                    {
                        new SucessorVazioUm(),
                        new SucessorVazioDois(),
                        new SucessorVazioTres(),
                        new SucessorVazioQuatro(),
                        new SucessorVazioCinco(),
                        new SucessorVazioSeis(),
                        new SucessorVazioSete(),
                        new SucessorVazioOito(),
                        new SucessorVazioZero()
                    };

            return regrasSucessor
                .Single(r => r.Match(node))
                .AchaSucessor(node);
        }
    }
}