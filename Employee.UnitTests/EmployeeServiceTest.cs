using Application.ApplicationServices;
using Application.ApplicationServices.Interfaces;
using Domain.Common.RepositoryInterface;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class EmployeeServiceTest
    {
        Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();
        IEmployeeService _service;
        public EmployeeServiceTest()
        {
            _service = new EmployeeService(_employeeRepository.Object);
        }

        [Fact]
        public async Task GetAllTest_Sucess()
        {
            //Setup
            var employeesResult = GetEmployees();
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees()));
            //Action
            var employees = await _service.GetAllAsync();

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData("john.doe@email.com", 1)]
        [InlineData("bob.person@email.com", 2)]
        public async Task GetByEmailTest_Sucess(string email, int result)
        {
            //Setup
            var employeesResult = GetEmployees().Where(e => e.Email.Equals(email));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees().Where(e => e.Email.Equals(email))));
            //Action
            var employees = await _service.GetByEmailAsync(email);

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            employees.Count().Should().Be(result);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData("Doe", 2)]
        [InlineData("Person", 1)]
        public async Task GetByName_Sucess(string name, int result)
        {
            //Setup
            var employeesResult = GetEmployees().Where(e => e.LastName.ToLower().Equals(name.ToLower()) || e.FirstName.ToLower().Equals(name.ToLower()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees().Where(e => e.LastName.ToLower().Equals(name.ToLower()) || e.FirstName.ToLower().Equals(name.ToLower()))));
            //Action
            var employees = await _service.GetByNameAsync(name);

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            employees.Count().Should().Be(result);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData("Bob", 2)]
        [InlineData("Tauan", 0)]
        public async Task GetByFirstName_Sucess(string name, int result)
        {
            //Setup
            var employeesResult = GetEmployees().Where(e => e.FirstName.ToLower().Equals(name.ToLower()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees().Where(e => e.FirstName.ToLower().Equals(name.ToLower()))));
            //Action
            var employees = await _service.GetByFirstNameAsync(name);

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            employees.Count().Should().Be(result);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData("Person", 1)]
        [InlineData("Tauan", 0)]
        public async Task GetByLastName_Sucess(string name, int result)
        {
            //Setup
            var employeesResult = GetEmployees().Where(e => e.LastName.ToLower().Equals(name.ToLower()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees().Where(e => e.LastName.ToLower().Equals(name.ToLower()))));
            //Action
            var employees = await _service.GetByLastNameAsync(name);

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            employees.Count().Should().Be(result);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetById_Sucess(int id)
        {
            //Setup
            var employeesResult = GetEmployees().Where(e => e.Id.Equals(id)).FirstOrDefault();
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()))
                               .Returns(Task.FromResult(GetEmployees().Where(e => e.Id.Equals(id))));
            //Action
            var employees = await _service.GetById(id);

            //Validate
            employees.Should().BeEquivalentTo(employeesResult);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                 It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                 It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployee_Success()
        {
            //Setup
            var employee = new Employee()
            {
                FirstName = "Tauan",
                LastName = "Matos",
                Email = "tauan.matos@email.com",
                Phone = "+1 555 555 555",
                EmployeeAddress = new EmployeeAddress()
                {
                    City = "Salvador",
                    Country = "Brazil",
                    PostCode = "10008",
                    State = "Bahia",
                    Street = "Tv SA",
                    StreetNumber = "1"
                }
            };

            _employeeRepository.Setup(x => x.InsertAsync(It.IsAny<Employee>())).Returns(Task.FromResult(employee));
            _employeeRepository.Setup(x => x.CheckIfUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(GetEmployees().Any(e => e.Email.Equals(employee.Email)
                                                            && e.FirstName.Equals(employee.FirstName)
                                                            && e.LastName.Equals(employee.LastName))));

            //Action
            var result = await _service.AddAsync(employee);

            //Validate
            result.Should().Be(employee);
            _employeeRepository.Verify(x => x.InsertAsync(It.IsAny<Employee>()), Times.Once);
            _employeeRepository.Verify(x => x.CheckIfUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task AddEmployee_Fail()
        {
            //Setup
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                Phone = "+1 555 555 555",
                EmployeeAddress = new EmployeeAddress()
                {
                    City = "New York",
                    Country = "United States",
                    PostCode = "10008",
                    State = "New York",
                    Street = "Times Square, Manhattan",
                    StreetNumber = "1"
                }
            };

            _employeeRepository.Setup(x => x.InsertAsync(It.IsAny<Employee>())).Returns(Task.FromResult(employee));
            _employeeRepository.Setup(x => x.CheckIfUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(GetEmployees().Any(e => e.Email.Equals(employee.Email)
                                                            && e.FirstName.Equals(employee.FirstName)
                                                            && e.LastName.Equals(employee.LastName))));

            //Action
            var result = await _service.AddAsync(employee);

            //Validate
            result.Should().Be(null);
            _employeeRepository.Verify(x => x.InsertAsync(It.IsAny<Employee>()), Times.Never);
            _employeeRepository.Verify(x => x.CheckIfUserExists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployee_Success()
        {
            //Setup
            var employee = new Employee()
            {
                Id = 1,
                FirstName = "Rick",
                LastName = "Doe",
                Email = "john.doe@email.com",
                Phone = "+1 555 555 555",
                EmployeeAddress = new EmployeeAddress()
                {
                    Id = 1,
                    City = "New York",
                    Country = "Brazil",
                    PostCode = "10008",
                    State = "New York",
                    Street = "Times Square, Manhattan",
                    StreetNumber = "1"
                }
            };

            _employeeRepository.Setup(x => x.UpdateAsync(It.IsAny<Employee>()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                             It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                             It.IsAny<Expression<Func<Employee, object>>[]>()))
                                           .Returns(Task.FromResult(GetEmployees().Where(e => e.Id.Equals(employee.Id))));

            //Action
            var result = await _service.UpdateAsync(employee, employee.Id);

            //Validate
            result.Should().Be(true);
            _employeeRepository.Verify(x => x.UpdateAsync(It.IsAny<Employee>()), Times.Once);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                     It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                     It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployee_Fail()
        {
            //Setup
            var employee = new Employee()
            {
                Id = 10,
                FirstName = "Rick",
                LastName = "Doe",
                Email = "john.doe@email.com",
                Phone = "+1 555 555 555",
                EmployeeAddress = new EmployeeAddress()
                {
                    Id = 1,
                    City = "New York",
                    Country = "Brazil",
                    PostCode = "10008",
                    State = "New York",
                    Street = "Times Square, Manhattan",
                    StreetNumber = "1"
                }
            };

            _employeeRepository.Setup(x => x.UpdateAsync(It.IsAny<Employee>()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                             It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                             It.IsAny<Expression<Func<Employee, object>>[]>()))
                                           .Returns(Task.FromResult(GetEmployees().Where(e => e.Id.Equals(employee.Id))));

            //Action
            var result = await _service.UpdateAsync(employee, employee.Id);

            //Validate
            result.Should().Be(false);
            _employeeRepository.Verify(x => x.UpdateAsync(It.IsAny<Employee>()), Times.Never);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                     It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                     It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteEmployee_Success(int id)
        {
            //Setup
            _employeeRepository.Setup(x => x.DeleteAsync(It.IsAny<Employee>()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                             It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                             It.IsAny<Expression<Func<Employee, object>>[]>()))
                                           .Returns(Task.FromResult(GetEmployees().Where(e => e.Id.Equals(id))));

            //Action
            var result = await _service.DeleteAsync(id);

            //Validate
            result.Should().Be(true);
            _employeeRepository.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Once);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                     It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                     It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }

        [Theory]
        [InlineData(10)]
        public async Task DeleteEmployee_Fail(int id)
        {
            //Setup
            _employeeRepository.Setup(x => x.DeleteAsync(It.IsAny<Employee>()));
            _employeeRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                                             It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                                             It.IsAny<Expression<Func<Employee, object>>[]>()))
                                           .Returns(Task.FromResult(GetEmployees().Where(e => e.Id.Equals(id))));

            //Action
            var result = await _service.DeleteAsync(id);

            //Validate
            result.Should().Be(false);
            _employeeRepository.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Never);
            _employeeRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
                                     It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>(),
                                     It.IsAny<Expression<Func<Employee, object>>[]>()), Times.Once);
        }


        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    Phone = "+1 555 555 555",
                    EmployeeAddress = new EmployeeAddress()
                    {
                        Id = 1,
                        City = "New York",
                        Country = "United States",
                        PostCode = "10008",
                        State = "New York",
                        Street = "Times Square, Manhattan",
                        StreetNumber = "1"
                    }
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Person",
                    Email = "bob.person@email.com",
                    Phone = "+1 444 444 444",
                    EmployeeAddress = new EmployeeAddress()
                    {
                        Id = 2,
                        City = "Los Angeles",
                        Country = "United States",
                        PostCode = "90210",
                        State = "California",
                        Street = "Long Beach",
                        StreetNumber = "2"
                    }
                },
                new Employee()
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "People",
                    Email = "bob.person@email.com",
                    Phone = "+1 444 444 444",
                    EmployeeAddress = new EmployeeAddress()
                    {
                        Id = 3,
                        City = "Los Angeles",
                        Country = "United States",
                        PostCode = "90210",
                        State = "California",
                        Street = "Long Beach",
                        StreetNumber = "2"
                    }
                },
                  new Employee()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@email.com",
                    Phone = "+1 999 999 999",
                    EmployeeAddress = new EmployeeAddress()
                    {
                        Id = 4,
                        City = "Honolulu",
                        Country = "United States",
                        PostCode = "21821",
                        State = "Hawaii",
                        Street = "North Shore",
                        StreetNumber = "3"
                    }
                }
            };
        }
    }
}
