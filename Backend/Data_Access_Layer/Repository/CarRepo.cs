using Data_Access_Layer.Db;
using Data_Access_Layer.Entity;
using Data_Access_Layer.IRepository;
using Data_Access_Layer.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDbContext appDbContext;

        public CarRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<CarEntity>?> GetCarsAync(string carMaker, string carModel, string carRentPrice)
        {
            if (carMaker == null && carModel == null && carRentPrice != null)
            {
                var cars = await appDbContext.Cars.Where(x => x.RentalPrice == carRentPrice).ToListAsync();
                return cars;
            }
            else if (carMaker == null && carModel != null && carRentPrice == null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Model == carModel).ToListAsync();
                return cars;
            }
            else if (carMaker != null && carModel == null && carRentPrice == null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Maker == carMaker).ToListAsync();
                return cars;
            }
            else if (carMaker != null && carModel != null && carRentPrice == null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Model == carModel && x.Maker == carMaker).ToListAsync();
                return cars;
            }
            else if (carMaker == null && carModel != null && carRentPrice != null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Model == carModel && x.RentalPrice == carRentPrice).ToListAsync();
                return cars;
            }
            else if (carMaker != null && carModel == null && carRentPrice != null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Maker == carMaker && x.RentalPrice == carRentPrice).ToListAsync();
                return cars;
            }
            else if (carMaker != null && carModel != null && carRentPrice != null)
            {
                var cars = await appDbContext.Cars.Where(x => x.Model == carModel && x.Maker == carMaker && x.RentalPrice == carRentPrice).ToListAsync();
                return cars;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<CarRentalAgreementEntity>?> GetCarsByIdAsync(int id)
        {
            var cars = await appDbContext.Agreements.Where(x => x.CarId == id).ToListAsync();
            return cars;
        }
        public async Task<CarEntity> GetCarByIdAsync(int id)
        {
            var car = await appDbContext.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            return car;
        }
        public async Task BookCarAsync(CarRentalAgreementEntity car)
        {
            await appDbContext.Agreements.AddAsync(car);
            await appDbContext.SaveChangesAsync();
        }
        public async Task<CarRentalAgreementEntity> UpdateAsync(int id)
        {
            var agreement = await appDbContext.Agreements.FirstOrDefaultAsync(x => x.AgreementId == id);
            if (agreement == null)
            {
                return null;
            }
            agreement.IsRequestedForReturn = true;
            await appDbContext.SaveChangesAsync();
            return agreement;
        }
        public async Task<List<CarRentalAgreementEntity>> GetAllAgreementsAsync()
        {
            var agreements = await appDbContext.Agreements.ToListAsync();
            return agreements;
        }
        public async Task<CarRentalAgreementEntity> DeleteAgreementAsync(int id)
        {
            var agreement = await appDbContext.Agreements.FindAsync(id);
            if (agreement == null)
            {
                return null;
            }
            appDbContext.Agreements.Remove(agreement);
            await appDbContext.SaveChangesAsync();
            return agreement;
        }
        public async Task AddCarAsync(CarEntity car)
        {
            await appDbContext.Cars.AddAsync(car);
            await appDbContext.SaveChangesAsync();
        }
        public async Task<CarEntity> UpdateCarAsync(int id,CarEntity car)
        {
            var carData = await appDbContext.Cars.FindAsync(id);
            if (carData == null)
            {
                return null;
            }
            carData.Maker = car.Maker;
            carData.Model = car.Model;
            carData.RentalPrice = car.RentalPrice;
            await appDbContext.SaveChangesAsync();
            return carData;
        }
        public async Task<CarEntity> DeleteCarAsync(int id)
        {
            var car = await appDbContext.Cars.FindAsync(id);
            if (car == null)
            {
                return null;
            }
            appDbContext.Cars.Remove(car);
            await appDbContext.SaveChangesAsync();
            return car;
        }
        public async Task<List<CarEntity>> GetAllCarAsync()
        {
            var cars=await appDbContext.Cars.ToListAsync();
            return cars;
        }
        public async Task<List<CarRentalAgreementEntity>> GetAgreementByUserIdAsync(int id)
        {
            var agreements = await appDbContext.Agreements.Where(x => x.UserId == id).ToListAsync();
            return agreements;
        }
    }
}
