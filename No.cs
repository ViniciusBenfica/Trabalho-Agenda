namespace AgendaTelefonica
{
    public class No
    {
        public Contato dado;
        public No proximo;
        public No anterior;

        public No(Contato contato)
        {
            dado = contato;
            proximo = null;
            anterior = null;
        }
    }
}