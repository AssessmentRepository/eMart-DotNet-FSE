using eMart.BusinessLayer;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using eMart.Tests.Exceptions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace eMart.Tests.TestCases
{
    public class ExceptionalTest
    {
        private Mock<IMongoCollection<Buyer>> _buyermockCollection;
        private Mock<IMongoCollection<Seller>> _sellermockCollection;
        private Mock<IMongoDBContext> _mockContext;
        private Buyer _buyer;
        private Seller _seller;

        private readonly IList<Buyer> _buyerlist;
        // MongoSettings declaration
        private Mock<IOptions<Mongosettings>> _mockOptions;

        public ExceptionalTest()
        {
            _buyermockCollection = new Mock<IMongoCollection<Buyer>>();
            _buyermockCollection.Object.InsertOne(_buyer);
            _sellermockCollection = new Mock<IMongoCollection<Seller>>();
            _sellermockCollection.Object.InsertOne(_seller);
            _buyer = new Buyer
            {
                UserName = "buyer1",
                Password = "123456",
                Email = "buyer@gmail.com",
                mobileNumber = 9876543210,
                CreatedTime = DateTime.Now
            };

            _seller = new Seller
            {
                UserName = "seller1",
                Password = "123456",
                CompanyName = "SamSung",
                GSTIN = 987656565657575,
                BriefAboutCompany = "Good Company",
                Postal_Address = "delhi 110001",
                WebSite = "website",
                Email = "buyer@gmail.com",
                ContactNumber = 9876543210
            };


            _mockContext = new Mock<IMongoDBContext>();
            //MongoSettings initialization
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _buyerlist = new List<Buyer>();
            _buyerlist.Add(_buyer);
        }
        Mongosettings settings = new Mongosettings()
        {
            Connection = "mongodb://localhost:27017",
            DatabaseName = "guestbook"
        };

        [Fact]
        public async void CreateNewBuyer_Null_Failure()
        {
            // Arrange
            _buyer = null;

            //Act 
            var bookRepo = new BuyerRepository(_mockContext.Object);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => bookRepo.RegisterAsync(_buyer));
        }

        [Fact]
        public async void CreateNewSeller_Null_Buyer_Failure()
        {
            // Arrange
            _seller = null;

            //Act 
            var bookRepo = new SellerRepository(_mockContext.Object);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => bookRepo.Register(_seller));
        }

        [Fact]
        public async Task ExceptionTestFor_InValidBuyerRegister()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<UserAlreadyExistException>(async () => await userRepo.RegisterAsync(_buyer));
            Assert.Equal("Already Exist", ex.Messages);

        }
        [Fact]
        public async Task ExceptionTestFor_InValidSellerRegister()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);

            //Act
            //Assert
            var ex = await Assert.ThrowsAsync<UserAlreadyExistException>(async () => await userRepo.Register(_seller));
            Assert.Equal("Already Exist", ex.Messages);
        }

    }
}
