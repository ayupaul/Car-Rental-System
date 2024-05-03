using Buisness_Layer.Model;
using Data_Access_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Iservice
{
    public interface ICarService
    {
        Task<List<CarModel>> GetCarsAsync(string carMaker,string carModel,string carRentPrice);
        Task<List<CarRentalAgreementModel>> GetCarsByIdAsync(int id);
        Task<CarModel> GetCarByIdAsync(int id);
        Task BookCarAsync(CarRentalAgreementModel car);
        Task<CarRentalAgreementModel> UpdateAsync(int id);
        Task<List<CarRentalAgreementModel>> GetAllAgreementsAsync();
        Task<CarRentalAgreementModel> DeleteAgreementAsync(int id);
        Task AddCarAsync(CarModel car);
        Task<CarModel> UpdateCarAsync(int id, CarModel car);
        Task<CarModel> DeleteCarAsync(int id);
        Task<List<CarModel>> GetAllCarAsync();
        Task<List<CarRentalAgreementModel>> GetAgreementByUserIdAync(int id);
    }
}
