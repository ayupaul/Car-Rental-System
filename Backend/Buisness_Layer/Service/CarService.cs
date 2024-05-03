using AutoMapper;
using Buisness_Layer.Iservice;
using Buisness_Layer.Model;
using Data_Access_Layer.Entity;
using Data_Access_Layer.IRepository;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepo carRepo;
        private readonly IMapper mapper;

        public CarService(ICarRepo carRepo,IMapper mapper)
        {
            this.carRepo = carRepo;
            this.mapper = mapper;
        }
        public async Task<List<CarModel>> GetCarsAsync(string carMaker, string carModel, string carRentPrice)
        {
            var cars=await carRepo.GetCarsAync(carMaker, carModel, carRentPrice);
            var carList = mapper.Map<List<CarModel>>(cars);
            return carList;
        }
        public async Task<List<CarRentalAgreementModel>> GetCarsByIdAsync(int id)
        {
            var cars = await carRepo.GetCarsByIdAsync(id);
            var carList = mapper.Map<List<CarRentalAgreementModel>>(cars);
            return carList;
        }
        public async Task<CarModel> GetCarByIdAsync(int id)
        {
            var car=await carRepo.GetCarByIdAsync(id);
            var carModel=mapper.Map<CarModel>(car);
            return carModel;
        }
        public async Task BookCarAsync(CarRentalAgreementModel model)
        {
            var car = mapper.Map<CarRentalAgreementEntity>(model);
            await carRepo.BookCarAsync(car);
        }
        public async Task<CarRentalAgreementModel> UpdateAsync(int id)
        {
            var agreement=await carRepo.UpdateAsync(id);
            var agreementModel = mapper.Map<CarRentalAgreementModel>(agreement);
            return agreementModel;
        }
        public async Task<List<CarRentalAgreementModel>> GetAllAgreementsAsync()
        {
            var agreements=await carRepo.GetAllAgreementsAsync();
            var agreementsModel = mapper.Map<List<CarRentalAgreementModel>>(agreements);
            return agreementsModel;
        }
       public async Task<CarRentalAgreementModel> DeleteAgreementAsync(int id)
        {
            var agreement=await carRepo.DeleteAgreementAsync(id);
            var agreementModel = mapper.Map<CarRentalAgreementModel>(agreement);
            return agreementModel;
        }
        public async Task AddCarAsync(CarModel car)
        {
            var carEntity=mapper.Map<CarEntity>(car);
            await carRepo.AddCarAsync(carEntity);
        }
       public async Task<CarModel> UpdateCarAsync(int id, CarModel car)
        {
            var carEntity=mapper.Map<CarEntity>(car);
            var carModel = await carRepo.UpdateCarAsync(id, carEntity);
            var updatedCarEntity=mapper.Map<CarModel>(carModel);
            return updatedCarEntity;
        }
       public async Task<CarModel> DeleteCarAsync(int id)
        {
            var car=await carRepo.DeleteCarAsync(id);
            var carModel=mapper.Map<CarModel>(car);
            return carModel;
        }
       public async Task<List<CarModel>> GetAllCarAsync()
        {
            var cars=await carRepo.GetAllCarAsync();
            var carsModel=mapper.Map<List<CarModel>>(cars);
            return carsModel;
        }
        public async Task<List<CarRentalAgreementModel>> GetAgreementByUserIdAync(int id)
        {
            var agreements=await carRepo.GetAgreementByUserIdAsync(id);
            var agreementsModel=mapper.Map<List<CarRentalAgreementModel>>(agreements);
            return agreementsModel;
        }
    }
}
