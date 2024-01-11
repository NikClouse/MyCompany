namespace MyCompany.Models
{
    public class Organization //Организация
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string LegalAddress { get; set; }
        public string ActualAddress { get; set; }



    }
}
