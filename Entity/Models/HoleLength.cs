using Entity.Models;

namespace PegMe.Models
{
    public class HoleLength : BaseModel
    {
        public string Tee { get; set; }
        public int Length { get; set; }
        public int HoleId { get; set; }
    }
}
