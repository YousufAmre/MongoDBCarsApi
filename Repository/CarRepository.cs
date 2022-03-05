using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCarsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCarsApi.Repository
{
    public class CarRepository: ICarRepository
    {
        private readonly IMongoCollection<Cars> _cars;

        public CarRepository(IMongoClient client)
        {
            var database = client.GetDatabase("CarsDB");
            var collection = database.GetCollection<Cars>(nameof(Cars));
            _cars = collection;
        }

        public async Task<ObjectId> Create(Cars cars)
        {
            await _cars.InsertOneAsync(cars);
            return cars.Id;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, objectId);
            var result = await _cars.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public async Task<Cars> Get(ObjectId objectId)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, objectId);
            var car = await _cars.Find(filter).FirstOrDefaultAsync();
            return car;
        }

        public async Task<IEnumerable<Cars>> Get()
        {
            var cars = await _cars.Find(_ => true).ToListAsync();
            return cars;
        }

        public async Task<IEnumerable<Cars>> GetByMake(string make)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Make, make);
            var cars = await _cars.Find(filter).ToListAsync();
            return cars;
        }

        public async Task<bool> Update(ObjectId objectId, Cars cars)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Cars>.Update
                .Set(c => c.Make, cars.Make)
                .Set(c => c.Model, cars.Model)
                .Set(c => c.TopSpeed, cars.TopSpeed);
            var result = await _cars.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;
        }
    }
}
