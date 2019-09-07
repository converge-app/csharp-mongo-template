using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application {
    public class StartupDevelopment {
        public StartupDevelopment (IConfiguration configuration) {
            // ElasticSearch
            Environment.SetEnvironmentVariable ("ELASTICSEARCH_URI", "http://localhost:9200");

            // Database
            Environment.SetEnvironmentVariable ("CollectionName", "Models");
            Environment.SetEnvironmentVariable ("ConnectionString", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable ("DatabaseName", "ApplicationDb");

            _startup = new Startup (configuration);
        }

        private Startup _startup;
        public void ConfigureServices (IServiceCollection services) {
            _startup.ConfigureServices (services);
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            _startup.Configure (app, env);
        }
    }
}