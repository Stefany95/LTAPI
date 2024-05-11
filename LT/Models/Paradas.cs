namespace LT.Models
{
       public class SubStop
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }

    public class Paradas
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public List<SubStop> substops { get; set; }
    }

}
