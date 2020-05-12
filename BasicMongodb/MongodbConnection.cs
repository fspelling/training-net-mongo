using MongoDB.Driver;

namespace BasicMongodb
{
    public class MongodbConnection<T>
    {
        private readonly string _collectionName;

        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public IMongoCollection<T> Collection
        {
            get
            {
                return Database.GetCollection<T>(_collectionName);
            }
        }

        public MongodbConnection(string coonectionString, string database, string collectionName)
        {
            Client = new MongoClient(coonectionString);
            Database = Client.GetDatabase(database);
            _collectionName = collectionName;
        }
    }
}
