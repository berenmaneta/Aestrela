using System.Linq;

namespace ConsoleApplicationTeste1
{
    public class NoQuebraCabeca : No
    {
        private int _espacoVazioIndex;

        public NoQuebraCabeca()
        {
            _espacoVazioIndex = -1;
        }

        public int[] Espaco { get; set; }

        public int EspacoVazioIndex
        {
            get
            {
                if (_espacoVazioIndex == -1)
                    _espacoVazioIndex = AchaPosicaoVazio(this);

                return _espacoVazioIndex;
            }
        }

        public float F { get; set; }
        public float G { get; set; }
        public float H { get; set; }

        public No Pai { get; set; }

        public bool EstadoIgual(No node)
        {
            var noTeste = node as NoQuebraCabeca;

            return noTeste != null && Espaco.SequenceEqual(noTeste.Espaco);
        }

        private static int AchaPosicaoVazio(NoQuebraCabeca node)
        {
            int espacoVazio = -1;

            for (int i = 0; i < 9; i++)
            {
                if (node.Espaco[i] == 0)
                {
                    espacoVazio = i;
                    break;
                }
            }

            return espacoVazio;
        }
    }
}