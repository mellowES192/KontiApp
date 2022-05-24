namespace KontiApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? FIO { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Mail { get; set; }

        public int EmployeesTypeId { get; set; }

        public EmployeesType? EmployeesType { get; set; }

    }
}
