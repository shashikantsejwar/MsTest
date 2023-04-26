using Moq;
using MsTest.Model;
using MsTest.Services.Interfaces;
using Repository.Interfaces;

namespace Services.Test.EmployeeService
{
    [TestClass]
    public class BaseTest
    {
        protected readonly Mock<IEmployeeRepository> _employeeRepository;
        protected readonly IEmployeeService _employeeService;
        protected List<Employee> _employees;
        protected readonly Mock<IHttpClientFactory> _httpClientFactory;

        public BaseTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _employeeService = new MsTest.Services.Services.EmployeeService(_httpClientFactory.Object, _employeeRepository.Object);
            SetupData();
        }

        private void SetupData()
        {
            // Alternatively we could have used Bogus to generate Fake Data
            Department Technology = new() { Id = 1, Name = "Technology" };
            Department Hr = new() { Id = 2, Name = "HR" };
            Department Sales = new() { Id = 3, Name = "Sales" };
            Department Marketing = new() { Id = 4, Name = "Marketing" };

            _employees = new List<Employee>()
            {
                new Employee { Id = 1, FirstName ="John", LastName = "Doe", Salary = 100000, Department = Technology,  HireDate = DateTime.Now.AddMonths(-5)},
                new Employee { Id = 2, FirstName ="Dean", LastName = "Smith", Salary = 120000, Department = Technology ,  HireDate = DateTime.Now.AddDays(-5)},
                new Employee { Id = 3, FirstName ="Jeff", LastName = "Stricklin", Salary = 130000, Department = Technology,  HireDate = DateTime.Now.AddMonths(-3)},
                new Employee { Id = 4, FirstName ="Brad", LastName = "Johnson", Salary = 50000, Department = Hr,  HireDate = DateTime.Now.AddMonths(-1)},
                new Employee { Id = 5, FirstName ="Manoj", LastName = "Tiwari", Salary = 200000, Department = Hr,  HireDate = DateTime.Now.AddDays(-12)},
                new Employee { Id = 6, FirstName ="Doug", LastName = "Johns", Salary = 125000, Department = Sales,  HireDate = DateTime.Now.AddMonths(-7)},
                new Employee { Id = 7, FirstName ="Scott", LastName = "Clark", Salary = 100000, Department = Sales,  HireDate = DateTime.Now.AddDays(-5)},
                new Employee { Id = 8, FirstName ="Michael", LastName = "Clark", Salary = 100000, Department = Marketing,  HireDate = DateTime.Now.AddMonths(-9)},
                new Employee { Id = 9, FirstName ="Johnson", LastName = "Doe", Salary = 100000, Department = Marketing,  HireDate = DateTime.Now.AddDays(-15)}
            };
        }
    }
}