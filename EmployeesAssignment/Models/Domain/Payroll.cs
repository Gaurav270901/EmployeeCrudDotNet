namespace EmployeesAssignment.Models.Domain
{
    public class Payroll
    {
        public int PayrollId { get; set; }
        public decimal Basic { get; set; }
        public decimal TA { get; set; }
        public decimal DA { get; set; }
        public decimal Bonus { get; set; }
        public decimal GrossSalary => Basic + TA + DA + Bonus;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
