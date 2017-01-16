using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationTeste1.Calculators;
using ConsoleApplicationTeste1.SuccessorNodes;

namespace ConsoleApplicationTeste1
{
    public class EncontraCaminho
    {
        private readonly GeradorNoSucessor _geradorNoSucessor;
        private readonly CalculaValorG _calculaValorG;
        private readonly CalculaValorH _calculaValorH;

        public EncontraCaminho(GeradorNoSucessor _geradorNoSucessor,
                          CalculaValorG _calculaValorG,
                          CalculaValorH _calculaValorH)
        {
            this._geradorNoSucessor = _geradorNoSucessor;
            this._calculaValorG = _calculaValorG;
            this._calculaValorH = _calculaValorH;
        }


        public int Ciclos { get; private set; }

        public No Executar(No noInicio, No noObjetivo)
        {
            Ciclos = 0;

            var abertos = new List<No> { noInicio };
            var fechados = new List<No>();

            while (abertos.Count > 0)
            {
                Ciclos++;
                No currentNode = SelecionaMelhorNoAberto(abertos);

                abertos.Remove(currentNode);
                fechados.Add(currentNode);

                IEnumerable<No> successorNodes =
                    _geradorNoSucessor.Executar(currentNode);

                foreach (No successorNode in successorNodes)
                {
                    if (successorNode.EstadoIgual(noObjetivo))
                        return successorNode;

                    successorNode.G = _calculaValorG.Executar(currentNode);
                    successorNode.H = _calculaValorH.Executar(noObjetivo, successorNode);
                    successorNode.F = successorNode.G + successorNode.H;

                    if (melhorNoAberto(successorNode, abertos))
                        continue;

                    abertos.Add(successorNode);
                }
            }

            return null;
        }

        private static No SelecionaMelhorNoAberto(IEnumerable<No> abertos)
        {
            return abertos.OrderBy(n => n.F).First();
        }

        private static bool melhorNoAberto(No successor, IEnumerable<No> list)
        {
            return list.FirstOrDefault(n => n.G.Equals(successor.G)
                    && n.F < successor.F) != null;
        }
    }
}
