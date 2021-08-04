using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace Application.ApplicationServices.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee?> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employeeDto, int id);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetByFirstNameAsync(string firstName);
        Task<IEnumerable<Employee>> GetByLastNameAsync(string lastName);
        Task<IEnumerable<Employee>> GetByEmailAsync(string email);
        Task<IEnumerable<Employee>> GetByNameAsync(string name);
        Task<Employee> GetById(int id);
    }
}
