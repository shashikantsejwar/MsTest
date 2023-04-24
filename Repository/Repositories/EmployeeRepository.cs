using MsTest.Model;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        List<Employee> Employees { get; set; }
        public EmployeeRepository() => SetupData();

        private void SetupData()
        {

            Department Technology = new() { Id = 1, Name = "Technology" };
            Department Hr = new() { Id = 2, Name = "HR" };
            Department Sales = new() { Id = 3, Name = "Sales" };
            Department Marketing = new() { Id = 4, Name = "Marketing" };

            Employees = new List<Employee>()
            {
                new Employee { Id = 1, FirstName ="John", LastName = "Doe", Salary = 100000, Department = Technology,  HireDate = DateTime.Now.AddMonths(-5)},
                new Employee { Id = 2, FirstName ="Dean", LastName = "Smith", Salary = 120000, Department = Technology ,  HireDate = DateTime.Now.AddDays(-5)},
                new Employee { Id = 3, FirstName ="Jeff", LastName = "Stricklin", Salary = 130000, Department = Technology,  HireDate = DateTime.Now.AddMonths(-3)},
                new Employee { Id = 4, FirstName ="Brad", LastName = "Johnson", Salary = 50000, Department = Hr,  HireDate = DateTime.Now.AddMonths(-1)},
                new Employee { Id = 5, FirstName ="Manoj", LastName = "Tiwari", Salary = 200000, Department = Hr,  HireDate = DateTime.Now.AddDays(-12)},
                new Employee { Id = 6, FirstName ="Doug", LastName = "Johns", Salary = 125000, Department = Sales,  HireDate = DateTime.Now.AddMonths(-7)},
                new Employee { Id = 7, FirstName ="Scott", LastName = "Clark", Salary = 100000, Department = Sales,  HireDate = DateTime.Now.AddDays(-5)},
                new Employee { Id = 9, FirstName ="Michael", LastName = "Clark", Salary = 100000, Department = Marketing,  HireDate = DateTime.Now.AddMonths(-9)},
                new Employee { Id = 9, FirstName ="Johnson", LastName = "Doe", Salary = 100000, Department = Marketing,  HireDate = DateTime.Now.AddDays(-15)}
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> AllEmployees()
        {
            return Employees;
        }

        public void Delete(Employee employee)
        {
            Employees.Remove(employee);
        }

        public Employee Update(Employee employee)
        {
            var savedEmployee = Employees.Find(x => x.Id == employee.Id);
            if (savedEmployee != null)
            {
                savedEmployee.FirstName = employee.FirstName;
                savedEmployee.LastName = employee.LastName;
                savedEmployee.Salary = employee.Salary;
                savedEmployee.Department = employee.Department;
                savedEmployee.HireDate = employee.HireDate;
            }
            
            return savedEmployee;
        }
    }
}
