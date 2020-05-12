using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        private static async Task ManipulandoDocuments()
        {
            await Task.Factory.StartNew(() =>
            {
                var document1 = GerarDocument();

                Console.WriteLine($"{nameof(document1)} = {document1}");
                Console.ReadLine();
            });
        }

        private static BsonDocument GerarDocument() =>
            new BsonDocument()
            {
                { "titulo", "Guerra dos Tronos" },
                        { "autor", "George R R Martin" },
                        { "ano", 1999 },
                        { "paginas", 856 },
                        { "assunto", new BsonArray() { "Fantasia", "Acao" } }
            };
    }
}
