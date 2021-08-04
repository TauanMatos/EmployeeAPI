using Application.ApplicationServices.Interfaces;
using Domain.Common.RepositoryInterface;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace Application.ApplicationServices
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Method to add employee to the database
        /// The check if user exists was made using an Index on the database model.
        /// Since InMemory database does not validate index, this business validation was added
        /// </summary>
        /// <param name="employee"></param>
        public async Task<Employee?> AddAsync(Employee employee)
        {
            if (await _employeeRepository.CheckIfUserExists(employee.FirstName, employee.LastName, employee.Email))
                return null;

            return await _employeeRepository.InsertAsync(employee);
        }

        /// <summary>
        /// Method to delete employee from database
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetById(id);

            if (entity is null)
                return false;

            await _employeeRepository.DeleteAsync(entity);
            return true;
        }

        /// <summary>
        /// Method to retrieve all employees from the database
        /// </summary>
        /// <returns>List of employees</returns>
        public async Task<IEnumerable<Employee>> GetAllAsync() => await _employeeRepository.Get(includeProperties: e => e.EmployeeAddress);

        /// <summary>
        /// Method to retrieve employees from database using the employee email
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>List of employees</returns>
        public async Task<IEnumerable<Employee>> GetByEmailAsync(string email) => await _employeeRepository.Get(e => e.Email.Equals(email), includeProperties: e => e.EmployeeAddress);

        /// <summary>
        /// Method to retrieve employees from database using the employee first name
        /// </summary>
        /// <param name="firsName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetByFirstNameAsync(string firsName) => await _employeeRepository.Get(e => e.FirstName.ToLower().Equals(firsName.ToLower()), includeProperties: e => e.EmployeeAddress);

        /// <summary>
        /// Method to retrieve employees from database using the employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetById(int id) => (await _employeeRepository.Get(e => e.Id.Equals(id), includeProperties: e => e.EmployeeAddress)).FirstOrDefault();

        /// <summary>
        /// Method to retrieve employees from database using the employee last name
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetByLastNameAsync(string lastName) => await _employeeRepository.Get(e => e.LastName.ToLower().Equals(lastName.ToLower()), includeProperties: e => e.EmployeeAddress);


        /// <summary>
        /// Method to retrieve employees from database using that the input matches first or last name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetByNameAsync(string name) => await _employeeRepository.Get(e => e.FirstName.ToLower().Equals(name.ToLower()) || e.LastName.ToLower().Equals(name.ToLower()), includeProperties: e => e.EmployeeAddress);


        /// <summary>
        /// Method to update employee at the database
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Employee employee, int id)
        {
            var entity = await GetById(id);

            if (entity is null)
                return false;

            employee.Id = entity.Id;
            employee.EmployeeAddress.Id = entity.EmployeeAddress.Id;
            await _employeeRepository.UpdateAsync(employee);

            return true;
        }
    }
}
