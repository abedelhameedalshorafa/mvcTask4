namespace CompanyTask4.Models
{
    public class taskItems
    {
        public taskItems()
        {
            this.Users = new HashSet<User>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public string ImportanceLevel { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
