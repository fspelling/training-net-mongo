using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        private static async Task InserindoLivroMongoEncapsulado()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            await mongodb.Collection.InsertOneAsync(new Livro
            {
                Titulo = "Sob a estranha",
                Autor = "Stephen Kinga",
                Ano = 2014,
                Paginas = 200,
                Assuntos = new List<string> { "Ação" }
            });

            Console.WriteLine("Livro inserido no banco");
        }
    }
}
