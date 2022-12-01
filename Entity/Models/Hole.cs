namespace PegMe.Models
{
    public class Hole
    {
        public int id { get; set; }
        public List<HoleLength> Lengths { get; set; }
        public int Par { get; set; }
        public int Index { get; set; }

    }
}