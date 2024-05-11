namespace LT.Models
{
    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class DepartureArrival
    {
        public string date { get; set; }
        public string time { get; set; }
    }

    public class Price
    {
        public double seatPrice { get; set; }
        public double taxPrice { get; set; }
        public double price { get; set; }
    }

    public class Connection
    {
        public Location node { get; set; }
        public WaitingInformation waitingInformation { get; set; }
        public Company company { get; set; }
        public string seatClass { get; set; }
        public int availableSeats { get; set; }
        public bool withBPE { get; set; }
    }

    public class WaitingInformation
    {
        public DepartureArrival arrival { get; set; }
        public DepartureArrival departure { get; set; }
    }

    public class BusInfo
    {
        public string id { get; set; }
        public Company company { get; set; }
        public Location from { get; set; }
        public Location to { get; set; }
        public int availableSeats { get; set; }
        public bool withBPE { get; set; }
        public DepartureArrival departure { get; set; }
        public DepartureArrival arrival { get; set; }
        public int travelDuration { get; set; }
        public double travelDistance { get; set; }
        public string seatClass { get; set; }
        public Price price { get; set; }
        public double insurance { get; set; }
        public bool allowCanceling { get; set; }
        public string travelCancellationLimitDate { get; set; }
        public double travelCancellationFee { get; set; }
        public bool manualConfirmation { get; set; }
        public Connection connection { get; set; }
    }
}
