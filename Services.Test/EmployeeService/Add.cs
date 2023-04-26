using MsTest.Model;

namespace Services.Test.EmployeeService
{
    [TestClass]
    public class Add : BaseTest
    {
        [TestMethod]
        public void Add_Employee_Success()
        {
            _employeeRepository.Setup(x => x.AllEmployees()).Returns(_employees);

            var newEmployee = new Employee()
            {
                Id = 10,
                FirstName = "Shashikant",
                LastName = "Sejwar",
                Department = new Department() { Id = 1, Name = "Technoogy" },
                HireDate = DateTime.Now.AddMonths(-1),
                Salary = 1000
            };


            var (status, employee) =  _employeeService.Add(newEmployee);

            Assert.IsTrue(employee.Id== newEmployee.Id);
            Assert.AreEqual(newEmployee, newEmployee);
            Assert.AreEqual(status, "Success");
        }
    }

    
}
