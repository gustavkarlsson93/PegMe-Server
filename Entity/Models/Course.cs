namespace PegMe.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LengthOut { get; set; }
        public int LengthIn { get; set; }
        public int LengthTotal { get; set; }
        public List<Hole> Holes { get; set; }
    }
}