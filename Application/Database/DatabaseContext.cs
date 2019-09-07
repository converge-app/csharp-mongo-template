using Application.Models;
using MongoDB.Driver;

namespace Application.Database {
    public interface IDatabaseContext {
        IMongoCollection<Model> Models { get; }

        bool IsConnectionOpen ();
    }

    public class DatabaseContext : IDatabaseContext {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public DatabaseContext (IDatabaseSettings settings) {
            settings.ReadFromEnvironment ();
            client = new MongoClient (settings.ConnectionString);
            database = client.GetDatabase (settings.DatabaseName);
        }

        public IMongoCollection<Model> Models => database.GetCollection<Model> ("Models");

        public bool IsConnectionOpen () {
            return database != null;
        }
    }
}