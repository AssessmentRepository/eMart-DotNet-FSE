using eMart.BusinessLayer;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
  public  class BoundaryTest
    {
        private Mock<IMongoCollection<Buyer>> _buyermockCollection;
        private Mock<IMongoCollection<Products>> _productsmockCollection;
        private Mock<IMongoCollection<Seller>> _sellermockCollection;
        private Mock<IMongoDBContext> _mockContext;
        private Buyer _buyer;
        private Seller _seller;
        private Products _products;
        private Category _category;
        private SubCategory _subcategory;
        private readonly IList<Buyer> _buyerlist;
        // MongoSettings declaration
        private Mock<IOptions<Mongosettings>> _mockOptions;

        public BoundaryTest()
        {
            _buyermockCollection = new Mock<IMongoCollection<Buyer>>();
            _buyermockCollection.Object.InsertOne(_buyer);
            _sellermockCollection = new Mock<IMongoCollection<Seller>>();
            _sellermockCollection.Object.InsertOne(_seller);
            _productsmockCollection = new Mock<IMongoCollection<Products>>();
            _productsmockCollection.Object.InsertOne(_products);
            _buyer = new Buyer
            {
                UserName = "buyer1",
                Password = "123456",
                Email = "buyer@gmail.com",
                mobileNumber = 9876543210,
                CreatedTime = DateTime.Now
            };
            _category = new Category
            {
                CategoryName = "Electrical",
                BreifDetails = "Good-Product"
            };
            _subcategory = new SubCategory
            {
                SubCategoryName = "Mobiles",
                CategoryId = _category.CategoryId,
                BreifDetails = "Good_Products",
                GST = 18
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
            _products = new Products
            {
                CategoryId = _category.CategoryId,
                SubCategoryId = _subcategory.SubCategoryId,
                Price = 10000,
                ProductName = "samSungF7",
                Description = "GoodProducts",
                StockNumber = 1,
                remarks = "good"
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
        public async Task BoundaryTestfor_ValidProductValidPrice()
        {
            //mocking
            _productsmockCollection.Setup(op => op.InsertOneAsync(_products, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name)).Returns(_productsmockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);

            //Act
            await userRepo.AddProducts(_products);
            var result = await userRepo.GetProductsbyId(_products.ProductsId);

            Assert.InRange(_products.Price, 50, 90000000000);
            Assert.InRange(result.Price, 50, 90000000000);
        }

        [Fact]
        public async Task BoundaryTestfor_ValidSellerGST()
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

            Assert.InRange(_seller.GSTIN.ToString().Length, 15, 15);
            Assert.InRange(result.GSTIN.ToString().Length, 15, 15);
        }


        [Fact]
        public async Task BoundaryTestfor_ValidBuyerId()
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

            Assert.InRange(_buyer.BuyerId.Length, 20, 30);
        }
        [Fact]
        public async Task BoundaryTestfor_ValidSellerId()
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

            Assert.InRange(_seller.SellerId.Length, 20, 30);
        }

        [Fact]
        public async Task BoundaryTestFor_BuyerPhoneNumberLengthAsync()
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

            var MinLength = 10;
            var MaxLength = 10;

            //Action
            var actualLength = _buyer.mobileNumber.ToString().Length;

            //Assert
            Assert.InRange(result.mobileNumber.ToString().Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }
        [Fact]
        public async Task BoundaryTestFor_SellerPhoneNumberLengthAsync()
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
           // await userRepo.Register(_seller);
            var result = await userRepo.GetSellersById(_seller.SellerId);

            var MinLength = 10;
            var MaxLength = 10;

            //Action
            var actualLength = _seller.ContactNumber.ToString().Length;

            //Assert
            Assert.InRange(result.ContactNumber.ToString().Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }

    }
}
