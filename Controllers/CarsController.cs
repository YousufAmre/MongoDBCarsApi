using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDBCarsApi.Models;
using MongoDBCarsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCarsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController: ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cars cars)
        {
            var id = await _carRepository.Create(cars);
            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var car = await _carRepository.Get(ObjectId.Parse(id));
            return new JsonResult(car);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> Get()
        {
            var cars = await _carRepository.Get();
            return cars.ToList();
        }

        [HttpGet("ByMake/{make}")]
        public async Task<IActionResult> GetByMake(string make)
        {
            var cars = await _carRepository.GetByMake(make);
            return new JsonResult(cars);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Cars cars)
        {
            var result = await _carRepository.Update(ObjectId.Parse(id), cars);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _carRepository.Delete(ObjectId.Parse(id));
            return new JsonResult(result);
        }

    }
}
