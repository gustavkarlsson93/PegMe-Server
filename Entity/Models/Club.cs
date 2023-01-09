using Entity.Models;

namespace PegMe.Models
{
    public class Club : BaseModel
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}

