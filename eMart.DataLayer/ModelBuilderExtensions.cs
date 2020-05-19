using eMart.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMart.DataLayer
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            UserSampleData(modelBuilder);
        }

        public static void UserSampleData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Charan",
                    PhoneNumber = 9566632200,
                    Email = "charan@gmail.com",
                    Password = "123456",
                }, new User
                {
                    Id = 2,
                    Name = "Naveen",
                    PhoneNumber = 9856342200,
                    Email = "naveen@gmail.com",
                    Password = "123456",
                }
                );
        }
    }
}
