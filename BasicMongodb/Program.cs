using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        static async Task Main(string[] args)
        {
            //await ManipulandoDocuments();
            //await InserindoDocumentMongo();
            //await InserindoLivroMongo();
            //await InserindoLivroMongoEncapsulado();
            //await InserindoMultiplosDocumentos();
            //await BuscandoDocumentos();
            //await BuscandoDocumentosFiltro();
            //await BuscandoDocumentosFiltroClasseMongo();
            //await BuscandoDocumentosSortLimit();
            //await AtualizandoDocumentos();
            //await AtualizandoDocumentosMongo();
            await DeleteDocumentos();
        }
    }
}
