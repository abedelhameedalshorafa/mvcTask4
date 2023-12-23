namespace CompanyTask4.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
