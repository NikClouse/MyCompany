namespace MyCompany.Models
{
    public class Sotrudnik
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

    }
}
