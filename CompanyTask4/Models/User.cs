namespace CompanyTask4.Models
{

    public enum Role
    {
        Manager,
        Employee
    }
    public class User
    {

        public User()
        {
            this.Tasks = new HashSet<taskItems>();
        }
        public int ID { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int NationalID { get; set; }
        public string Nationality { get; set; }
        public string MartialStatus { get; set; }
        public DateTime HireDate { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public int? DepartmentID { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<taskItems> Tasks { get; set; }
    }
}
