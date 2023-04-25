using MsTest.Model;
using MsTest.Model.Models;

namespace MsTest.Services.Interfaces
{
    public interface IEmployeeService
    {
        public (string status, Employee? employee) GetById(int id);
        public (string status, IEnumerable<Employee> employees) GetAll();

        public Employee Add(Employee employee);
        public Employee Update(Employee employee);
        public void Delete(int employeeId);

        public (string status, decimal averageValue) GetAverageSalaryByDeparmentName(string name);

        public (string status, IEnumerable<DepartmentCount> departmentCount) GetEmployeeCountByDepartment();

        public Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
