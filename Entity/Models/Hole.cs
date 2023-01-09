using Entity.Models;

namespace PegMe.Models
{
    public class Hole : BaseModel
    {
        public List<HoleLength> Lengths { get; set; }
        public int Par { get; set; }
        public int Index { get; set; }
        public int CourseId { get; set; }

    }
}