using Buisness_Layer.Iservice;
using Buisness_Layer.Model;
using Data_Access_Layer.Db;
using Data_Access_Layer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class CarController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly ICarService carService;

        public CarController(AppDbContext appDbContext,ICarService carService)
        {
            this.appDbContext = appDbContext;
            this.carService = carService;
        }
        
        [HttpPost("search")]
        public async Task<IActionResult> SearchCars(CarModel car)
        {
            var carMaker = car.Maker;
            var carModel = car.Model;
            var carRentPrice = car.RentalPrice;
            
            var cars=await carService.GetCarsAsync(carMaker, carModel,carRentPrice);
            return Ok(cars);
        }
        [HttpPost("alreadyBooked")]
        public async Task<IActionResult> AlreadyBooked(CarRentalAgreementModel carRentalAgreement)
        {
            var startDate = carRentalAgreement.StartDate;
            var endDate = carRentalAgreement.EndDate;
            var carId = carRentalAgreement.CarId;
            if (startDate == null || endDate == null || carId == null)
            {
                return BadRequest();
            }
            //var cars = await appDbContext.Agreements.Where(x => x.CarId == carId).ToListAsync();
            var cars=await carService.GetCarsByIdAsync(carId);
            foreach(var car in cars)
            {
                if(DateTime.TryParse(car.StartDate, out DateTime carStartDate)&& DateTime.TryParse(car.EndDate, out DateTime carEndDate)&& DateTime.TryParse(startDate, out DateTime agreementStartDate)&& DateTime.TryParse(endDate, out DateTime agreementEndDate))
                {
                    if((carStartDate<=agreementStartDate && agreementStartDate<=carEndDate)||(carStartDate<=agreementEndDate&&agreementEndDate<=carEndDate))
                    {
                        return Ok(true);
                        
                    }
                    
                }
            }
            return Ok(false);
        }
        [HttpGet("carById/{id}")]
        public async Task<IActionResult> CarById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            //var car = await appDbContext.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            var car=await carService.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpPost("bookCar")]
        public async Task<IActionResult> BookCar([FromBody] CarRentalAgreementModel carRentalAgreement)
        {
            if (carRentalAgreement == null)
            {
                return BadRequest();
            }
            carRentalAgreement.IsRequestedForReturn = false;
            //await appDbContext.Agreements.AddAsync(carRentalAgreement);
            //await appDbContext.SaveChangesAsync();
            await carService.BookCarAsync(carRentalAgreement);
            return Ok(new {Message="Booked Successfully"});
        }
        [HttpGet("getAgreements/{id}")]
        public async Task<IActionResult> GetAgreementOnUserId([FromRoute] int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            //var agreements=await appDbContext.Agreements.Where(x => x.UserId == id).ToListAsync();
            var agreements=await carService.GetAgreementByUserIdAync(id);
            if (agreements == null)
            {
                return NotFound();
            }
            return Ok(agreements);
        }
        [HttpPut("requestForReturn/{id}")]
        public async Task<IActionResult> RequestForReturn([FromRoute] int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            //var agreement=await appDbContext.Agreements.FirstOrDefaultAsync(x=>x.AgreementId==id);
            var agreement = await carService.UpdateAsync(id);
            if(agreement == null)
            {
                return NotFound();
            }
            //agreement.IsRequestedForReturn = true;
            //await appDbContext.SaveChangesAsync();
            return Ok(new {Message="Request For return initiated"});
        }
        [HttpGet("getAllAgreements")]
        public async Task<IActionResult> GetAllAgreements()
        {
            //var agreements = await appDbContext.Agreements.ToListAsync();
            var agreements = await carService.GetAllAgreementsAsync();
            if(agreements== null)
            {
                return NotFound();
            }
            return Ok(agreements);
        }
        [HttpDelete("approveReturn/{id}")]
        public async Task<IActionResult> ApproveReturn([FromRoute] int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            //var agreement = await appDbContext.Agreements.FindAsync(id);
            var agreement = await carService.DeleteAgreementAsync(id);
            if(agreement == null)
            {
                return NotFound();
            }
            //appDbContext.Agreements.Remove(agreement);
            // await appDbContext.SaveChangesAsync();
            return Ok(new {Message="Agreement completed successfully"});
        }
        [HttpPost("addCar")]
        public async Task<IActionResult> AddCar([FromBody] CarModel car)
        {
            if(car == null)
            {
                return BadRequest();
            }
            //await appDbContext.Cars.AddAsync(car);
            //await appDbContext.SaveChangesAsync();
            await carService.AddCarAsync(car);
            return Ok(new { Message = "Car Added Successfully..." });
        }
        [HttpPut("updateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id,CarModel car)
        {
            if (id==null || car==null)
            {
                return null;
            }
            //var carData = await appDbContext.Cars.FindAsync(id);
            //if(carData == null)
            //{
            //    return NotFound();
            //}
            //carData.Maker= car.Maker;
            //carData.Model=car.Model;
            //carData.RentalPrice=car.RentalPrice;
            //await appDbContext.SaveChangesAsync();
            var carData = await carService.UpdateCarAsync(id, car);
            if (carData == null)
            {
                return NotFound();
            }
            return Ok(carData);
            
        }
        [HttpDelete("deleteCar/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            //var car=await appDbContext.Cars.FindAsync(id);
            //if(car==null)
            //{
            //    return NotFound();
            //}
            //appDbContext.Cars.Remove(car);
            //await appDbContext.SaveChangesAsync();
            var car=await carService.DeleteCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(new { Message = "Deleted Successfully..." });
        }
        [HttpGet("getAllCar")]
        public async Task<IActionResult> GetAllCar()
        {
            var cars=await carService.GetAllCarAsync();
            return Ok(cars);
        }
    }
}
