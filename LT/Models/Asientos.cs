namespace LT.Models
{
    public class Asientos
    {
    
        public string seat { get; set; }
        public Position position { get; set; }
        public bool occupied { get; set; }
        public string type { get; set; }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
}
