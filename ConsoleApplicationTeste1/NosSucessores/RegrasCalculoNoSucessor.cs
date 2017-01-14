using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public class RegrasCalculoNoSucessor : RegrasGeradorNoSucessivo
    {

        public virtual IEnumerable<No> AchaSucessor(No no)
        {
            return null;
        }

        public virtual bool Match(No node)
        {
            return false;
        }

        protected static void AdicionaSucessor(NoQuebraCabeca no,
                                           ICollection<No> resultado,
                                           int espacoTroca)
        {
            var novoEstado = no.Espaco.Clone() as int[];
            if (novoEstado == null) return;
            novoEstado[no.EspacoVazioIndex] = novoEstado[espacoTroca];
            novoEstado[espacoTroca] = 0;

            if (!IgualEstadoPai(no.Pai, novoEstado))
                resultado.Add(new NoQuebraCabeca { Espaco = novoEstado, Pai = no });
        }

        private static bool IgualEstadoPai(No no, IEnumerable<int> estado)
        {
            return no != null && estado.SequenceEqual(((NoQuebraCabeca)no).Espaco);
        }
    }
}