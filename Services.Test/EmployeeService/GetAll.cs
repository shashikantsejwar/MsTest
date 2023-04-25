using MsTest.Model;

namespace Services.Test.EmployeeService
{
    [TestClass]
    public class GetAll : BaseTest
    {
        [TestMethod]
        public void GetAll_Return_All_Records()
        {
            _employeeRepository.Setup(x => x.AllEmployees()).Returns(_employees);
            var (status, employee) = _employeeService.GetAll();

            Assert.AreEqual(employee.Count(), _employees.Count);
            Assert.AreEqual(status, "Success");
        }

        [TestMethod]
        public void GetAll_No_Records()
        {
            //Arrange
            _employeeRepository.Setup( x=> x.AllEmployees()).Returns(new List<Employee>());

            //Act
            var (status, employee) = _employeeService.GetAll();

            //Assert
            Assert.IsTrue(condition: !employee.Any());
            Assert.AreEqual(status, "No Employees Exist");
        }
    }
}