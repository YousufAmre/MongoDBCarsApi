using MongoDB.Bson;
using MongoDBCarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCarsApi.Repository
{
    public interface ICarRepository
    {
        public Task<ObjectId> Create(Cars cars);

        public Task<bool> Delete(ObjectId objectId);

        public Task<Cars> Get(ObjectId objectId);

        public Task<IEnumerable<Cars>> Get();

        public Task<IEnumerable<Cars>> GetByMake(string make);

        public Task<bool> Update(ObjectId objectId, Cars cars);
    }
}
