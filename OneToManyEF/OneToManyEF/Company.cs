namespace OneToManyEF
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;

        private List<Employee> Employees { get; set; }
    }
}
