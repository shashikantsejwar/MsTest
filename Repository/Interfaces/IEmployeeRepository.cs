using MsTest.Model;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> AllEmployees();
        void Delete(Employee employee);
        Employee Update(Employee employee);
    }
}
