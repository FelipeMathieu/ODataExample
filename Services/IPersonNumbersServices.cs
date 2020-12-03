using Models;
using System.Linq;

namespace Services
{
    public interface IPersonNumbersServices
    {
        IQueryable<PersonNumbers> GetAll();
    }
}
