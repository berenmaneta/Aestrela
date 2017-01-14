using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApplicationTeste1.Calculators;
using ConsoleApplicationTeste1.SuccessorNodes;

namespace ConsoleApplicationTeste1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                var objetivo = new NoQuebraCabeca { Espaco = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 } };
                var inicio = new NoQuebraCabeca { Espaco = new int[9] };

                Console.WriteLine("Entre com um estado válido no formato: 867254301");
                string entradaUsuario = Console.ReadLine();


                if (entradaUsuario != null)
                {
                    int i = 0;

                    foreach (char s in entradaUsuario)
                    {
                        int tile;


                        if (!int.TryParse(s.ToString(), out tile)) continue;

                        inicio.Espaco[i++] = tile;
                    }

                    var caminho = new EncontraCaminho(
                        new GeradorNoSucessivo(),
                        new CalculaCusto(),
                        new CalculaDistanciaManhatan());

                    No resultado = caminho.Executar(inicio, objetivo);
                    ExibeSolucao(resultado);

                    Console.ReadKey();
                }
            } while (Console.ReadLine() != "Sair");
        }

        private static void ExibeSolucao(No no)
        {

            if (no != null)
            {
                var pilha = new Stack<No>();

                do
                {
                    pilha.Push(no);
                } while ((no = no.Pai) != null);

                var passo = 0;

                foreach (NoQuebraCabeca noSolucao in pilha)
                {
                    Console.Clear();

                    Console.WriteLine("");

                    string espacos = noSolucao.Espaco
                        .Aggregate("", (current, i) => current + i.ToString());

                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine("  {0} {1} {2}",
                            espacos[i] == '0' ? '_' : espacos[i],
                            espacos[i + 1] == '0' ? '_' : espacos[i + 1],
                            espacos[i + 2] == '0' ? '_' : espacos[i + 2]);
                        i = i + 2;
                    }

                    Thread.Sleep(500);
                    passo++;
                }

                Console.WriteLine("");
                Console.WriteLine("{0} passos", passo);
            }
            else
            {
                Console.WriteLine("Sem solução");
            }

        }
    }
}
