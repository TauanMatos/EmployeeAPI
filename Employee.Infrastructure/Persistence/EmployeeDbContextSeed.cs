using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class EmployeeDbContextSeed
    {
        public static async Task SeedSampleDataAsync(EmployeeDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                context.Employees.AddRange(GetEmployees());
                await context.SaveChangesAsync();
            }
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
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
                },
                new Employee()
                {
                    FirstName = "Bob",
                    LastName = "Person",
                    Email = "bob.person@email.com",
                    Phone = "+1 444 444 444",
                    EmployeeAddress = new EmployeeAddress()
                    {
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
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@email.com",
                    Phone = "+1 999 999 999",
                    EmployeeAddress = new EmployeeAddress()
                    {
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
