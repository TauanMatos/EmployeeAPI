using Domain.Common.RepositoryInterface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfUserExists(string firstName, string lastName, string email)
        {
            return await this._dbSet.AnyAsync(e => e.FirstName.Equals(firstName)
                                   && e.LastName.Equals(lastName)
                                   && e.Email.Equals(email));
        }
    }
}
