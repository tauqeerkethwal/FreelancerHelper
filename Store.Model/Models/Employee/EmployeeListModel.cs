namespace Freelancer.Model.Models.Employee
{
    public class EmployeeListModel
    {
        public int SNo { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Tlf { get; set; }
        public string Email { get; set; }
        public decimal HourlyPay { get; set; }
        public bool DrivingLicence { get; set; }
        public bool Car { get; set; }
        public string DateCreated { get; set; }
        public string Type { get; set; }
        public bool? Active { get; set; }
        public bool del { get; set; }

    }
}
