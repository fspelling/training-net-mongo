using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicMongodb
{
    public partial class Program
    {
        private static IMongoClient mongoClient;

        private static async Task InserindoDocumentMongo()
        {
            // Conectando com o servidor
            mongoClient = new MongoClient("mongodb://localhost:19003");

            // Acessando o database
            var bibliotecasDB = mongoClient.GetDatabase("bibliotecas");

            // Acessando a collection e inserindo o document
            var livrosCollection = bibliotecasDB.GetCollection<BsonDocument>("livros");
            await livrosCollection.InsertOneAsync(GerarDocument());

            Console.WriteLine("Document inserido no banco");
        }

        private static async Task InserindoLivroMongo()
        {
            // Conectando com o servidor
            mongoClient = new MongoClient("mongodb://localhost:19003");

            // Acessando o database
            var bibliotecasDB = mongoClient.GetDatabase("bibliotecas");

            // Instanciando objeto da Livro
            var livro = new Livro
            {
                Titulo = "Sob a redoma",
                Autor = "Stephen King",
                Ano = 2012,
                Paginas = 679,
                Assuntos = new List<string> { "Ficção Científica", "Terror", "Ação" }
            };

            // Acessando a collection e inserindo o document
            var livrosCollection = bibliotecasDB.GetCollection<Livro>("livros");
            await livrosCollection.InsertOneAsync(livro);

            Console.WriteLine("Livro inserido no banco");
        }
    }
}
