namespace KontiApp.Models
{
    public class EmployeesType
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
