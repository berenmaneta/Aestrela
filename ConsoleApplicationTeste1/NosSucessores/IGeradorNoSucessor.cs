using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste1.SuccessorNodes
{
    public interface GeradorNoSucessor
    {
        IEnumerable<No> Executar(No no);
    }
}