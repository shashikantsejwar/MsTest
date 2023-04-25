using MsTest.Model;

namespace Services.Test.EmployeeService
{
    [TestClass]
    public class GetById : BaseTest
    {
        [TestMethod]
        public void GetById_Employee_Found()
        {
            _employeeRepository.Setup(x => x.AllEmployees()).Returns(_employees);
            var (status, result) = _employeeService.GetById(1);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result, _employees.FirstOrDefault(x => x.Id == 1));
            Assert.AreEqual(status, "Success");

        }

        [TestMethod]
        public void GetById_Employee_Not_Exists()
        {
            _employeeRepository.Setup(x => x.AllEmployees()).Returns(_employees);
            var (status, result) = _employeeService.GetById(11);

            Assert.IsNull(result);
            Assert.AreEqual(status, "Not Found");
        }

        [TestMethod]
        public void GetById_AllEmployees_Empty()
        {
            _employeeRepository.Setup(x => x.AllEmployees()).Returns(new List<Employee>());
            var (status, result) = _employeeService.GetById(1);

            Assert.IsNull(result);
            Assert.AreEqual(status, "Not Found");
        }
    }
}
