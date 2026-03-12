using System.Diagnostics;

namespace ProgAssincrona
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ExecutarComTasks ();
            sw.Stop();
            Console.WriteLine($"Operação Gastou {sw.ElapsedMilliseconds} milissegundos");
        }


        static void RealizarOperacao(int op, string nome, string sobrenome)
        {
            Console.WriteLine($"Iniciando Operação {op}...");
            for (int i = 0; i < 1000000000; i++)
            {
                var p = new Pessoa(nome, sobrenome, 16);
            }
            Console.WriteLine($"Finalizando Operação {op}!");
        }

        private static void ExecutarSequencial()
        {
            RealizarOperacao(1, "Flavio", "Noim");
            RealizarOperacao(2, "Gustavo", "Silvério");
            RealizarOperacao(3, "Kauã", "Aquino");
        }

        static void ExecutarComThreads()
        {
            var t1 = new Thread(() =>
            {
                RealizarOperacao(1, "Flavio", "Noim");
            });
            var t2 = new Thread(() =>
            {
                RealizarOperacao(2, "Gustavo", "Silvério");
            });
            var t3 = new Thread(() =>
            {
                RealizarOperacao(3, "Kauã", "Aquino");
            });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();
        }

        static void ExecutarComTasks()
        {

            var t1 = Task<int>.Run(() =>
            {
                RealizarOperacao(1, "Flavio", "Noim");
                return 1;
            });
            var t2 = Task<int>.Run(() =>
            {
                RealizarOperacao(2, "Gustavo", "Silvério");
                return 2;
            });
            var t3 = Task<int>.Run(() =>
            {
                RealizarOperacao(3, "Kauã", "Aquino");
                return 3;
            });
            Console.WriteLine($"Tarefa {t1.Result} Finalizou.");
            Console.WriteLine($"Tarefa {t2.Result} Finalizou.");
            Console.WriteLine($"Tarefa {t3.Result} Finalizou.");

        }
    }
}



