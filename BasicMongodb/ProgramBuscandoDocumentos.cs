using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        public static async Task BuscandoDocumentos()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var livros = await mongodb.Collection.Find(_ => true).ToListAsync();

            livros.ForEach(livro => Console.WriteLine(livro.ToJson()));
        }

        public static async Task BuscandoDocumentosFiltro()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var livros = await mongodb.Collection.Find(new BsonDocument { { "Autor", "Stephen Kinga" } }).ToListAsync();

            livros.ForEach(livro => Console.WriteLine(livro.ToJson()));
        }

        public static async Task BuscandoDocumentosFiltroClasseNet()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");

            Console.WriteLine("Listando documentos do autor...");
            var livros = await mongodb.Collection.Find(l => l.Autor == "Stephen Kinga").ToListAsync();
            livros.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da ano...");
            var livrosAno = await mongodb.Collection.Find(l => l.Ano >= 2000).ToListAsync();
            livrosAno.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da ano e pagina...");
            var livrosPagina = await mongodb.Collection.Find(l => l.Ano >= 2000 && l.Paginas > 200).ToListAsync();
            livrosPagina.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da assunto...");
            var livrosAssunto = await mongodb.Collection.Find(l => l.Assuntos.Contains("Ação")).ToListAsync();
            livrosAssunto.ForEach(livro => Console.WriteLine(livro.ToJson()));
        }

        public static async Task BuscandoDocumentosFiltroClasseMongo()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var builderFilter = Builders<Livro>.Filter;

            Console.WriteLine("Listando documentos do autor...");
            var livros = await mongodb.Collection.Find(builderFilter.Eq(l => l.Autor, "Stephen Kinga")).ToListAsync();
            livros.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da ano...");
            var livrosAno = await mongodb.Collection.Find(builderFilter.Gte(l => l.Ano, 2000)).ToListAsync();
            livrosAno.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da ano e pagina...");
            var livrosPagina = await mongodb.Collection.Find(builderFilter.Gte(l => l.Ano, 2000) & 
                                                             builderFilter.Gte(l => l.Paginas, 200)).ToListAsync();
            livrosPagina.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos da assunto...");
            var livrosAssunto = await mongodb.Collection.Find(builderFilter.AnyEq(l => l.Assuntos, "Ação")).ToListAsync();
            livrosAssunto.ForEach(livro => Console.WriteLine(livro.ToJson()));
        }

        public static async Task BuscandoDocumentosSortLimit()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");

            Console.WriteLine("Listando documentos sort...");
            var livrosSort = await mongodb.Collection.Find(l => l.Ano >= 2000).SortBy(s => s.Titulo).ToListAsync();
            livrosSort.ForEach(livro => Console.WriteLine(livro.ToJson()));

            Console.WriteLine("Listando documentos limit...");
            var livrosLimit = await mongodb.Collection.Find(l => l.Ano >= 2000).SortBy(s => s.Titulo).Limit(3).ToListAsync();
            livrosLimit.ForEach(livro => Console.WriteLine(livro.ToJson()));
        }
    }
}
