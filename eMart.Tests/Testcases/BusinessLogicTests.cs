using eMart.BusinessLayer;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eMart.Tests.TestCases
{
    public class BusinessLogicTests
    {
        private Mock<IMongoCollection<Buyer>> _buyermockCollection;
        private Mock<IMongoCollection<Seller>> _sellermockCollection;
        private Mock<IMongoDBContext> _mockContext;
        private Buyer _buyer;
        private Seller _seller;

        private readonly IList<Buyer> _buyerlist;
        // MongoSettings declaration
        private Mock<IOptions<Mongosettings>> _mockOptions;

        public BusinessLogicTests()
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
        public async Task Testfor_ValidBuyerEmailAsync()
        {
            //mocking
            _buyermockCollection.Setup(op => op.InsertOneAsync(_buyer, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Buyer>(typeof(Buyer).Name)).Returns(_buyermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);


            //Act
            await userRepo.RegisterAsync(_buyer);
            var result = await userRepo.GetBuyerByIdAsync(_buyer.BuyerId);

            ////Action
            bool CheckEmail = Regex.IsMatch(result.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            bool isEmail = Regex.IsMatch(_buyer.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            //Assert
            Assert.True(isEmail);
            Assert.True(CheckEmail);
        }

        [Fact]
        public async Task Testfor_ValidSellerEmailAsync()
        { //mocking
            _sellermockCollection.Setup(op => op.InsertOneAsync(_seller, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Seller).Name)).Returns(_sellermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);


            //Act
            await userRepo.Register(_seller);
            var result = await userRepo.GetSellersById(_seller.SellerId);


            ////Action
            bool CheckEmail = Regex.IsMatch(result.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            bool isEmail = Regex.IsMatch(_buyer.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            //Assert
            Assert.True(isEmail);
            Assert.True(CheckEmail);
        }

        [Fact]
        public async Task TestFor_validNameLengthAsync()
        {
            //mocking
            _buyermockCollection.Setup(op => op.InsertOneAsync(_buyer, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Buyer>(typeof(Buyer).Name)).Returns(_buyermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            await userRepo.RegisterAsync(_buyer);
            var result = await userRepo.GetBuyerByIdAsync(_buyer.BuyerId);

            var MinLength = 3;
            var MaxLength = 50;

            //Action
            var actualLength = _buyer.UserName.Length;

            //Assert
            Assert.InRange(result.UserName.Length, MinLength, MaxLength);
            Assert.InRange(result.UserName.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }

        [Fact]
        public async Task TestFor_validSellerUserNameLengthAsync()
        {
            //mocking
            _sellermockCollection.Setup(op => op.InsertOneAsync(_seller, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Seller).Name)).Returns(_sellermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);

            //Act
            await userRepo.Register(_seller);
            var result = await userRepo.GetSellersById(_seller.SellerId);

            var MinLength = 3;
            var MaxLength = 50;

            //Action
            var actualLength = _seller.UserName.Length;

            //Assert
            Assert.InRange(result.UserName.Length, MinLength, MaxLength);
            Assert.InRange(result.UserName.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }

        [Fact]
        public async Task TestFor_NotNull_ValidBuyerUserNameAsync()
        {
            //mocking
            _buyermockCollection.Setup(op => op.InsertOneAsync(_buyer, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Buyer>(typeof(Buyer).Name)).Returns(_buyermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);


            //Act
            await userRepo.RegisterAsync(_buyer);
            var result = await userRepo.GetBuyerByIdAsync(_buyer.BuyerId);

            bool getisUserName = Regex.IsMatch(result.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            bool isUserName = Regex.IsMatch(_buyer.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isUserName);
            Assert.True(getisUserName);
        }

        [Fact]
        public async Task TestFor_NotNull_ValidSellerUserNameAsync()
        {
            //mocking
            _sellermockCollection.Setup(op => op.InsertOneAsync(_seller, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Seller).Name)).Returns(_sellermockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);


            //Act
            await userRepo.Register(_seller);
            var result = await userRepo.GetSellersById(_seller.SellerId);

            bool getisUserName = Regex.IsMatch(result.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            bool isUserName = Regex.IsMatch(_seller.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isUserName);
            Assert.True(getisUserName);
        }


    }
}
