using System;
using Application.Database;
using Application.Models;
using MongoDB.Driver;

namespace Application.Repositories {

    public interface IModelRepository {

    }
    public class ModelRepository : IModelRepository {
        private readonly IDatabaseContext dbContext;
        private IMongoCollection<Model> models;

        public ModelRepository (IDatabaseContext dbContext) {
            this.dbContext = dbContext;
            if (dbContext.IsConnectionOpen ()) {
                models = dbContext.Models;
            }
        }
    }
}