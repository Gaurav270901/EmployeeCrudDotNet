namespace EmployeesAssignment.Models.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Navigation property for EmployeeSkills
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        // Navigation property for Payroll
        public Payroll Payroll { get; set; }
    }
}
