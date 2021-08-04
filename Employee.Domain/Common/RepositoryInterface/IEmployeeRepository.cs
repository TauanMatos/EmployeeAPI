using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Common.RepositoryInterface
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> CheckIfUserExists(string firstName, string lastName, string email);
    }
}
