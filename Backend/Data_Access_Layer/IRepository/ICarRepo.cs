using Data_Access_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.IRepository
{
    public interface ICarRepo
    {
        Task<List<CarEntity>?> GetCarsAync(string carMaker, string carModel, string carRentPrice);
        Task<List<CarRentalAgreementEntity>?> GetCarsByIdAsync(int id);
        Task<CarEntity> GetCarByIdAsync(int id);
        Task BookCarAsync(CarRentalAgreementEntity car);
        Task<CarRentalAgreementEntity> UpdateAsync(int id);
        Task<List<CarRentalAgreementEntity>> GetAllAgreementsAsync();
        Task<CarRentalAgreementEntity> DeleteAgreementAsync(int id);
        Task AddCarAsync(CarEntity car);
        Task<CarEntity> UpdateCarAsync(int id, CarEntity car);
        Task<CarEntity> DeleteCarAsync(int id);
        Task<List<CarEntity>> GetAllCarAsync();
        Task<List<CarRentalAgreementEntity>> GetAgreementByUserIdAsync(int id);
    }
}
