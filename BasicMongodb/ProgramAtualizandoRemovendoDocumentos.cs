using MongoDB.Driver;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        public static async Task AtualizandoDocumentos()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var livros = await mongodb.Collection.Find(l => l.Titulo == "20000 Léguas Submarinas").ToListAsync();

            livros.ForEach(async livro =>
            {
                livro.Paginas = 4000;
                await mongodb.Collection.ReplaceOneAsync(l => l.Titulo == "20000 Léguas Submarinas", livro);
            });
        }

        public static async Task AtualizandoDocumentosMongo()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var builderUpdate = Builders<Livro>.Update;
            await mongodb.Collection.UpdateManyAsync(l => l.Paginas >= 400, builderUpdate.Set(l => l.Ano, 2000));
        }

        public static async Task DeleteDocumentos()
        {
            var mongodb = new MongodbConnection<Livro>("mongodb://localhost:19003", "bibliotecas", "livros");
            var builderUpdate = Builders<Livro>.Update;
            await mongodb.Collection.DeleteManyAsync(l => l.Paginas >= 1000);
        }
    }
}
