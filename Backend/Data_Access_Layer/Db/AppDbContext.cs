using Data_Access_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Db
{
    public class AppDbContext:DbContext
    {
        

        public AppDbContext(DbContextOptions options) :base(options)
        {
           
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CarRentalAgreementEntity> Agreements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() {Id=1, Email = "palayush@gmail.com", Password = "Ayush123@", Role = "Admin" });
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() {Id=2, Email = "user1@gmail.com", Password = "User1234@", Role = "User" });
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() {Id=3, Email = "user2@gmail.com", Password = "User2345@", Role = "User" });
            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity() { CarId = 10, Maker = "Maruti Suzuki", Model = "Maruti Suzuki Swift", RentalPrice = "50$" }
                );
            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity() { CarId = 11, Maker = "Maruti Suzuki", Model = "Maruti Suzuki Vitara Brezza", RentalPrice = "60$" }
                );
            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity() { CarId = 20, Maker = "Ford", Model = "Ford Mustang", RentalPrice = "100$"}
                );
            modelBuilder.Entity<CarEntity>().HasData(
                new CarEntity() { CarId = 21, Maker = "Ford", Model = "Ford Escape", RentalPrice = "80$" }
                );
           
        }

    }
}
