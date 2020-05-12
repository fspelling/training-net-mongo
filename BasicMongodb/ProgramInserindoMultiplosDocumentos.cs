using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        public static async Task InserindoMultiplosDocumentos()
        {
            var livros = new List<Livro>();
            livros.Add(LivroUtils.IncluirLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"));
            livros.Add(LivroUtils.IncluirLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"));
            livros.Add(LivroUtils.IncluirLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"));
            livros.Add(LivroUtils.IncluirLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"));
            livros.Add(LivroUtils.IncluirLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"));
            livros.Add(LivroUtils.IncluirLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"));
            livros.Add(LivroUtils.IncluirLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"));
            livros.Add(LivroUtils.IncluirLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"));
            livros.Add(LivroUtils.IncluirLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"));
            livros.Add(LivroUtils.IncluirLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"));
            livros.Add(LivroUtils.IncluirLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"));
            livros.Add(LivroUtils.IncluirLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"));
            livros.Add(LivroUtils.IncluirLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação"));

            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            await mongodb.Collection.InsertManyAsync(livros);

            Console.WriteLine("Livros inseridos no banco");
        }
    }
}
