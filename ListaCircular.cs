using System;
using System.IO;

namespace AgendaTelefonica
{
    public class ListaCircular
    {
        public No inicio;

        public ListaCircular()
        {
            inicio = null;
        }

        //Controle
        public bool listaVazia()
        {
            return (inicio == null);
        }
        public void recuperarContatos()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\vinic\OneDrive\Área de Trabalho\Trabalho Lista Circular\Contatos.txt");

                int i = 0;

                while (i < lines.Length)
                {
                    Contato contato = new Contato();

                    string[] auxiliar = lines[i].Split("_");
                    contato.nome = auxiliar[0];
                    contato.email = auxiliar[1];
                    contato.numero = Convert.ToInt32(auxiliar[2]);
                    this.adicionaNaLista(contato);
                    i++;
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
            }
        }

        //Funçoes da lista
        public void entradaDados()
        {
            Console.WriteLine("Adicionar um contato.\n");

            Contato contato = new Contato();

            Console.Write("Nome: "); contato.nome = Console.ReadLine();
            Console.Write("Email: "); contato.email = Console.ReadLine();
            Console.Write("Numero: "); contato.numero = Convert.ToInt32(Console.ReadLine());

            this.adicionaNaLista(contato);
        }
        public void adicionaNaLista(Contato contato)
        {
            No auxiliar = inicio;
            var novoNo = new No(contato);

            switch (inicio)
            {
                case null:
                    auxiliar = novoNo;
                    auxiliar.anterior = auxiliar;
                    auxiliar.proximo = auxiliar;
                    inicio = auxiliar;
                    break;
                default:
                    auxiliar = auxiliar.anterior;
                    auxiliar.proximo = novoNo;
                    novoNo.anterior = auxiliar;
                    novoNo.proximo = inicio;
                    inicio.anterior = novoNo;
                    break;
            }
        }
        public void salvarLista()
        {
            if (this.listaVazia())
            {
                StreamWriter file = new StreamWriter("Contatos.txt");
                file.Close();
            }
            else
            {
                No no = inicio;
                StreamWriter file = new StreamWriter("Contatos.txt");
                do
                {
                    file.WriteLine($"{no.dado.nome}_{no.dado.email}_{no.dado.numero}");
                    no = no.proximo;
                } while (no != inicio);
                file.Close();
            }
        }
        public static void exibirContatos(Contato contato)
        {
            Console.WriteLine("Lista Telefonica");
            Console.WriteLine("ESQUERDA/DIREITA - navegar | INSERT - Atualizar | DELETE - Apagar | ESC - Sair da navegação\n");

            Console.WriteLine($"Nome: {contato.nome}");
            Console.WriteLine($"E-mail: {contato.email}");
            Console.WriteLine($"Numero: {contato.numero}");
        }
        public void atualizarContato(No no)
        {
            string[] atualizaContato = new string[3];
            Console.Write("Nome: ");
            atualizaContato[0] = Console.ReadLine();
            Console.Write("Email: ");
            atualizaContato[1] = Console.ReadLine();
            Console.Write("Numero: ");
            atualizaContato[2] = Console.ReadLine();

            no.dado.nome = atualizaContato[0];
            no.dado.email = atualizaContato[1];
            no.dado.numero = Convert.ToInt32(atualizaContato[2]);
        }
        public No excluirContato(No no)
        {
            if (no == inicio && no.proximo == inicio)
            {
                inicio = null;
                return null;
            }

            bool flag = false;
            if (no == inicio)
            {
                flag = true;
            }
            No anterior = no.anterior;
            No proximo = no.proximo;

            anterior.proximo = proximo;
            proximo.anterior = anterior;

            if (flag)
            {
                inicio = proximo;
            }

            return proximo;
        }

    }
}