using DIO.SERIES.Classes;


using System;


namespace DIO.SERIES
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            string opcao = ObterOpcaoUsuario();
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSerier();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                       VisualizarSerie();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ListarSerier()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada");
                return;
            }

            foreach (var item in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", item.RetornaId(), item.RetornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Series");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }


            Console.WriteLine("Digite o genero entre as Opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o descrição: ");
            string descricao = Console.ReadLine();


            Series series = new Series(id: repositorio.ProximoId(),
                genero: (Genero)genero,
                titulo: titulo,
                ano: ano,
                descricao: descricao);
            repositorio.Insere(series);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Series");

            Console.WriteLine("Digite o id da serie: ");
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            }


            Console.WriteLine("Digite o genero entre as Opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o descrição: ");
            string descricao = Console.ReadLine();


            Series series = new Series(id: indice,
                genero: (Genero)genero,
                titulo: titulo,
                ano: ano,
                descricao: descricao);
            repositorio.Atualiza(indice,series);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(indice);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indice = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indice);

            Console.WriteLine(serie.ToString());
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO bem vindo");
            Console.WriteLine("Informe a Opção desejada: ");

            Console.WriteLine("1- Listar Series: ");
            Console.WriteLine("2- Inserir Serie: ");
            Console.WriteLine("3- Atualizar Serie: ");
            Console.WriteLine("4- Excluir Serie: ");
            Console.WriteLine("5- Visualizar Serie: ");
            Console.WriteLine("c- Limpar Tela: ");
            Console.WriteLine("x- Sair: ");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
