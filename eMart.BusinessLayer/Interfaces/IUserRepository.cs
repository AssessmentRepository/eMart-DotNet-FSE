using eMart.Entities.Entities;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Interfaces
{
    public interface IUserRepository : IGenericeRepository<User>
    {
        Task<bool> Register(User user);
        Task<User> Login(User credentials);
    }
}
