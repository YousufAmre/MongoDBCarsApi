using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCarsApi.Models
{
    public class Cars
    {
        public ObjectId Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int TopSpeed { get; set; }
    }
}
