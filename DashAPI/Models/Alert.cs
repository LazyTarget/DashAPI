using System;

namespace DashAPI.Models
{
    public class Alert
    {
        public AlertType AlertType { get; set; }
        public DateTime TimeOccured { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}