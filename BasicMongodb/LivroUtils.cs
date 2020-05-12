using System.Collections.Generic;

namespace BasicMongodb
{
    public static class LivroUtils
    {
        public static Livro IncluirLivro(string Titulo, string Autor, int Ano, int Paginas, string Assuntos)
        {
            Livro Livro = new Livro();
            Livro.Titulo = Titulo;
            Livro.Autor = Autor;
            Livro.Ano = Ano;
            Livro.Paginas = Paginas;
            string[] vetAssunto = Assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();

            for (int i = 0; i <= vetAssunto.Length - 1; i++) vetAssunto2.Add(vetAssunto[i].Trim());

            Livro.Assuntos = vetAssunto2;
            return Livro;
        }
    }
}
