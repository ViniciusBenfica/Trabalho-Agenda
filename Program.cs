using System;

namespace AgendaTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaCircular listaCircular = new ListaCircular();

            listaCircular.recuperarContatos();

            bool sair = false;
            int opção;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite um numero correspondente a:");
                Console.WriteLine("1- Adicionar um contato.");
                Console.WriteLine("2- Abrir lista telefonica.");
                Console.WriteLine("3- Salvar e sair.");
                opção = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opção)
                {
                    case 1:
                        listaCircular.entradaDados();
                        break;
                    case 2:
                        No no = listaCircular.inicio;
                        bool empty = listaCircular.listaVazia();

                        ConsoleKeyInfo key;
                        Console.Clear();

                        if (no != null)
                        {
                            ListaCircular.exibirContatos(no.dado);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Você não possui contatos.");
                        }
                        key = Console.ReadKey();

                        while (key.Key != ConsoleKey.Escape)
                        {
                            if (empty)
                            {
                                Console.Clear();
                                Console.WriteLine("Lista vazia, aperte ESC.");
                            }
                            else
                            {
                                switch (key.Key)
                                {
                                    case ConsoleKey.LeftArrow:
                                        no = no.anterior;
                                        Console.Clear();
                                        ListaCircular.exibirContatos(no.dado);
                                        break;

                                    case ConsoleKey.RightArrow:
                                        no = no.proximo;
                                        Console.Clear();
                                        ListaCircular.exibirContatos(no.dado);
                                        break;

                                    case ConsoleKey.Insert:
                                        Console.Clear();
                                        Console.WriteLine("Atualizar contato.");
                                        listaCircular.atualizarContato(no);
                                        Console.Clear();
                                        Console.WriteLine("Contato atualizado.");
                                        ListaCircular.exibirContatos(no.dado);
                                        break;

                                    case ConsoleKey.Delete:
                                        no = listaCircular.excluirContato(no);
                                        if (no != null)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Contato Deletado.");
                                            ListaCircular.exibirContatos(no.dado);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lista vazia, aperte ESC.");
                                            empty = true;
                                        }
                                        break;
                                }
                            }
                            key = Console.ReadKey();
                        }
                        break;
                    case 3:
                        listaCircular.salvarLista();
                        sair = true;
                        break;

                }
            } while (!sair);
        }
    }
}
