using eMart.BusinessLayer;
using eMart.BusinessLayer.Repositories;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace eMart.Tests.TestCases
{
    public class FuctionalTests
    {
        private Mock<IMongoCollection<Buyer>> _buyermockCollection;
        private Mock<IMongoCollection<Seller>> _sellermockCollection;
        private Mock<IMongoCollection<Products>> _productsmockCollection;
        private Mock<IMongoCollection<Transactions>> _transactionsmockCollection;
        private Mock<IMongoCollection<PurchasedHistory>> _historymockCollection;
        private Mock<IMongoCollection<Category>> _categorymockCollection;
        private Mock<IMongoCollection<SubCategory>> _subcategorymockCollection;
        private Mock<IMongoDBContext> _mockContext;

        private Buyer _buyer;
        private Products _products;
        private Seller _seller;
        private Category _category;
        private SubCategory _subcategory;
        private readonly List<Buyer> _buyerlist;
        private readonly List<Seller> _sellerlist;
        private readonly List<Products> _productslist;
        private Transactions _transaction;
        private PurchasedHistory _history;
        // MongoSettings declaration
        private Mock<IOptions<Mongosettings>> _mockOptions;

        public FuctionalTests()
        {
            _buyermockCollection = new Mock<IMongoCollection<Buyer>>();
            _buyermockCollection.Object.InsertOne(_buyer);
            _sellermockCollection = new Mock<IMongoCollection<Seller>>();
            _sellermockCollection.Object.InsertOne(_seller);
            _productsmockCollection = new Mock<IMongoCollection<Products>>();
            _productsmockCollection.Object.InsertOne(_products);
            _categorymockCollection = new Mock<IMongoCollection<Category>>();
            _categorymockCollection.Object.InsertOne(_category);
            _subcategorymockCollection = new Mock<IMongoCollection<SubCategory>>();
            _subcategorymockCollection.Object.InsertOne(_subcategory);
            _transactionsmockCollection = new Mock<IMongoCollection<Transactions>>();
            _transactionsmockCollection.Object.InsertOne(_transaction);
            _historymockCollection = new Mock<IMongoCollection<PurchasedHistory>>();
            _historymockCollection.Object.InsertOne(_history);

            _buyer = new Buyer
            {
                UserName = "buyer2",
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

            _category = new Category {
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

            _products = new Products
            {
                CategoryId = _category.CategoryId,
                SubCategoryId = _subcategory.SubCategoryId,
                Price = 10000,
                ProductName = "samSungF7",
                Description = "GoodProducts",
                StockNumber = 1,
                remarks = "good",
                Manufacturer = "SamSung"
            };
            _transaction = new Transactions()
            {
                BuyerId = _buyer.BuyerId,
                sellerId = _seller.SellerId,
                TransactionsType = "cash",
                TransactionsDateTime = new DateTime(2020, 05, 01),
                Remarks = "Success"
            };
            _history = new PurchasedHistory()
            {
                BuyerId = _buyer.BuyerId,
                SellerId = _seller.SellerId,
                TransactionId = _transaction.TransactionsId,
                PoductsId = _products.ProductsId,
                NumberOfProducts = 1,
                DateAndTime = new DateTime(2020, 01, 23),
                remarks = "good"
            };

             _mockContext = new Mock<IMongoDBContext>();
            //MongoSettings initialization
            _mockOptions = new Mock<IOptions<Mongosettings>>();
            _buyerlist = new List<Buyer>();
            _buyerlist.Add(_buyer);
            _sellerlist = new List<Seller>();
            _sellerlist.Add(_seller);
            _productslist = new List<Products>();
            _productslist.Add(_products);
        }

        Mongosettings settings = new Mongosettings()
        {
            Connection = "mongodb://localhost:27017",
            DatabaseName = "guest"
        };


        [Fact]
        public async Task TestFor_GetAllBuyer()
        {
            //Arrange
            //Mock MoveNextAsync
            Mock<IAsyncCursor<Buyer>> _userCursor = new Mock<IAsyncCursor<Buyer>>();
            _userCursor.Setup(_ => _.Current).Returns(_buyerlist);
            _userCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            //Mock FindSync
            _buyermockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Buyer>>(),
            It.IsAny<FindOptions<Buyer, Buyer>>(),
             It.IsAny<CancellationToken>())).Returns(_userCursor.Object);

            //Mock GetCollection
            _mockContext.Setup(c => c.GetCollection<Buyer>(typeof(Buyer).Name)).Returns(_buyermockCollection.Object);
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.GetAllBuyers();

            //Assert 
            //loop only first item and assert
            foreach (Buyer user in result)
            {
                Assert.NotNull(user);
                break;
            }
        }

        [Fact]
        public async Task TestFor_GetAllSeller()
        {
            //Arrange
            //Mock MoveNextAsync
            Mock<IAsyncCursor<Seller>> _userCursor = new Mock<IAsyncCursor<Seller>>();
            _userCursor.Setup(_ => _.Current).Returns(_sellerlist);
            _userCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            //Mock FindSync
            _sellermockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Seller>>(),
            It.IsAny<FindOptions<Seller, Seller>>(),
             It.IsAny<CancellationToken>())).Returns(_userCursor.Object);

            //Mock Seller
            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Seller).Name)).Returns(_sellermockCollection.Object);
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);

            //Act
            var result = await userRepo.GetAllSellers();

            //Assert 
            //loop only first item and assert
            foreach (Seller user in result)
            {
                Assert.NotNull(user);
                break;
            }
        }
        [Fact]
        public async Task TestFor_SearchProducts()
        {
            //Arrange
            //Mock MoveNextAsync
            Mock<IAsyncCursor<Products>> _userCursor = new Mock<IAsyncCursor<Products>>();
            _userCursor.Setup(_ => _.Current).Returns(_productslist);
            _userCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            //Mock FindSync
            _productsmockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Products>>(),
            It.IsAny<FindOptions<Products, Products>>(),
             It.IsAny<CancellationToken>())).Returns(_userCursor.Object);

            //Mock GetCollection
            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name)).Returns(_productsmockCollection.Object);
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.SearchProduct(_products.ProductName,_category.CategoryName, _subcategory.SubCategoryName);

            //Assert 
            //loop only first item and assert
            foreach (Products user in result)
            {
                Assert.NotNull(user);
                break;
            }
        }

        [Fact]
        public async void TestFor_BuyerRegistrations()
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
            var result = await userRepo.RegisterAsync(_buyer);
           
            //Assert
            Assert.True(result);
        
        }

        [Fact]
        public async void TestFor_SellerRegistrations()
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

            //Assert
            Assert.Equal(_seller.UserName, result.UserName);
        }

        [Fact]
        public async Task TestFor_AddProductsStocksAsync()
        {
            //Arrange
            //Mock MoveNextAsync
            Mock<IAsyncCursor<Products>> _userCursor = new Mock<IAsyncCursor<Products>>();
            _userCursor.Setup(_ => _.Current).Returns(_productslist);
            _userCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            //Mock FindSync
            _productsmockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Products>>(),
            It.IsAny<FindOptions<Products, Products>>(),
             It.IsAny<CancellationToken>())).Returns(_userCursor.Object);

            //Mock GetCollection
            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name)).Returns(_productsmockCollection.Object);
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var contex = new MongoDBContext(_mockOptions.Object);
            var sellerRepo = new SellerRepository(contex);
         
            var stock = 1;

            //Act
            await sellerRepo.AddProductsStock(_productslist, _seller, stock);
            var result = await sellerRepo.GetAllProducts();

            //Assert 
            foreach (Products user in result)
            {
                Assert.NotNull(user);
                break;
            }
        }

        [Fact]
        public async Task TestFor_GetBuyerById()
        {
            //Arrange
            //mocking
            _buyermockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Buyer>>(),
            It.IsAny<FindOptions<Buyer, Buyer>>(),
             It.IsAny<CancellationToken>()));

            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Buyer).Name));

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            await userRepo.RegisterAsync(_buyer);
            var result = await userRepo.GetBuyerByIdAsync(_buyer.BuyerId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestFor_GetSellerrById()
        {
            //Arrange
            //mocking
            _sellermockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Seller>>(),
            It.IsAny<FindOptions<Seller, Seller>>(),
             It.IsAny<CancellationToken>()));

            _mockContext.Setup(c => c.GetCollection<Seller>(typeof(Seller).Name));

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new SellerRepository(context);

            //Act
            await userRepo.Register(_seller);
            var result = await userRepo.GetSellersById(_seller.SellerId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void TestFor_AddProductsForCart()
        {
            //mocking
            _productsmockCollection.Setup(op => op.InsertOneAsync(_products, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name)).Returns(_productsmockCollection.Object);

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
           var isAdded= await userRepo.AddProductsToCart(_productslist);

            //Assert
            Assert.True(isAdded);
        }

        [Fact]
        public async void TestFor_GetAllProducts()
        {
            Mock<IAsyncCursor<Products>> _userCursor = new Mock<IAsyncCursor<Products>>();
            _userCursor.Setup(_ => _.Current).Returns(_productslist);
            _userCursor
                .SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            //Mock FindSync
            _productsmockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Products>>(),
            It.IsAny<FindOptions<Products, Products>>(),
             It.IsAny<CancellationToken>())).Returns(_userCursor.Object);

            //Mock GetCollection
            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name)).Returns(_productsmockCollection.Object);
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.GetAllProducts();

            //Assert 
            //loop only first item and assert
            foreach (Products user in result)
            {

                Assert.NotNull(user);
                break;
            }
        }

        [Fact]
        public async void TestFor_ViewProductsInCart()
        {
            //Arrange
            //mocking
            _productsmockCollection.Setup(op => op.FindSync(It.IsAny<FilterDefinition<Products>>(),
            It.IsAny<FindOptions<Products, Products>>(),
             It.IsAny<CancellationToken>()));

            _mockContext.Setup(c => c.GetCollection<Products>(typeof(Products).Name));

            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.GetItemfromCart(_buyer.BuyerId);

            foreach (Products user in result)
            {
                //Assert
                Assert.NotNull(user);
                break;
            }
        }
        [Fact]
        public async void TestFor_DeleteProductsFromCart()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.DeleteProductFromCart(_productslist,_buyer.BuyerId);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void TestFor_PlaceOrder()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.DeleteProductFromCart(_productslist, _buyer.BuyerId);
            //Assert
            Assert.True(result);
        }


        [Fact]
        public async void TestFor_ViewHistoryOfPurchace()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.ViewHistoryOfPurchace( _buyer.BuyerId);

            foreach (PurchasedHistory history in result)
            {
                //Assert
                Assert.NotNull(history);
                break;
            }
        }

        [Fact]
        public async void TestFor_validPaymentGate()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.PaymentGate(_products.ProductsId,_buyer.BuyerId);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void TestFor_validFilterProducts()
        {
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new BuyerRepository(context);

            //Act
            var result = await userRepo.FilterProduct(_products.ProductName, _category.CategoryName,_products.Price,_products.Manufacturer);
            foreach (Products history in result)
            {
                //Assert
                Assert.NotNull(history);
                break;
            }
        }


        [Fact]
        public async void TestFor_AddCategories()
        {
            //mocking
            _categorymockCollection.Setup(op => op.InsertOneAsync(_category, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<Category>(typeof(Category).Name)).Returns(_categorymockCollection.Object);

            //Craetion of new Db
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new AdminRepository(context);
            //Act
            var result = await userRepo.AddCategories(_category);
            //Assert
            Assert.Equal(result, _category);
        }


        [Fact]
        public async void TestFor_AddSubCategories()
        {
            //mocking
            _subcategorymockCollection.Setup(op => op.InsertOneAsync(_subcategory, null,
            default(CancellationToken))).Returns(Task.CompletedTask);
            _mockContext.Setup(c => c.GetCollection<SubCategory>(typeof(SubCategory).Name)).Returns(_subcategorymockCollection.Object);

        
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new AdminRepository(context);

            //Act
            var result = await userRepo.AddSubCategory(_subcategory);
            //Assert
            Assert.Equal(result, _subcategory);
        }


        [Fact]
        public async void TestFor_AddDiscounts()
        {
        var discounts  = new Discounts
            {
                productsId = _products.ProductsId,
                DiscountCode = "disOff10",
                Percentage = 10,
                StartDate =new DateTime(2020, 05, 15),
                EndDate= new DateTime(2020, 05, 20),
                Descriptions = "applicable only electrical items"
            };
                
            //Craetion of new Db
            _mockOptions.Setup(s => s.Value).Returns(settings);
            var context = new MongoDBContext(_mockOptions.Object);
            var userRepo = new AdminRepository(context);

            //Act
            var result = await userRepo.AddDiscounts(discounts);

            //Assert
            Assert.True(result);
        }

    }
}
