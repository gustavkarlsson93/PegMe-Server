namespace PegMe.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course>? Courses { get; set; }
    }
}