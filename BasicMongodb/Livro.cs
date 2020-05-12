using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BasicMongodb
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public int Ano { get; set; }

        public int Paginas { get; set; }

        public List<string> Assuntos { get; set; }
    }
}
