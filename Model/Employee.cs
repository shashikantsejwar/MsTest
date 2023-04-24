namespace MsTest.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }
    }
}
