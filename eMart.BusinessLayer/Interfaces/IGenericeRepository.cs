using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Interfaces
{
    public interface IGenericeRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
    }
}
