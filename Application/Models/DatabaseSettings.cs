using System;
using Microsoft.Extensions.Configuration;

namespace Application.Models
{
    public interface IDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

        void ReadFromEnvironment();

        IConfiguration GetConfiguration();
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        private const string _collectionName = "CollectionName";
        private const string _connectionString = "ConnectionString";
        private const string _databaseName = "DatabaseName";

        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public void ReadFromEnvironment()
        {
            CollectionName = Environment.GetEnvironmentVariable(_collectionName);
            ConnectionString = Environment.GetEnvironmentVariable(_connectionString);
            DatabaseName = Environment.GetEnvironmentVariable(_databaseName);

            if (String.IsNullOrEmpty(CollectionName) ||
                String.IsNullOrEmpty(ConnectionString) ||
                String.IsNullOrEmpty(DatabaseName))
            {
                throw new EnvironmentNotSet("Database variables not set");
            }
        }

        public IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddEnvironmentVariables(_collectionName)
                .AddEnvironmentVariables(_connectionString)
                .AddEnvironmentVariables(_databaseName)
                .Build();
        }
    }
}