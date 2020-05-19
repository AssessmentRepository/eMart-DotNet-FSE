using eMart.BusinessLayer.Interfaces;
using eMart.DataLayer;
using eMart.Entities;
using eMart.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly AppSettings _appSettings;

        public UserRepository(IMongoDBContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }


        public async Task<User> Login(User user)
        {
            try
            {
                FilterDefinition<User> filter = Builders<User>.Filter.And(Builders<User>.Filter.Eq(x => x.Email, user.Email), Builders<User>.Filter.Eq(x => x.Password, user.Password));
                var result =  await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

                if (result != null)
                {
                    var authUser = Authenticate(result);
                    authUser.Message = "Successful login.";
                    return authUser;
                }
                else
                {
                    user = new User();
                    user.Message = "Account not found.";
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Register(User user)
        {
            try
            {

                if (user?.Email != null)
                {
                    await _dbCollection.InsertOneAsync(user);
                    var getData = GetById(user.InternalId);
                   
                    if (getData != null)
                    {
                    return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private User Authenticate(User user)
        {
            try
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}