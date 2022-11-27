using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OneToManyEF
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Salary { get; set; }
       
        private Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
