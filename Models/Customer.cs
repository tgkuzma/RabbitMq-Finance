namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address BillingAddress { get; set; }
    }
}