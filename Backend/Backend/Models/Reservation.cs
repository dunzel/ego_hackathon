using System;

namespace Backend.Models
{
    public abstract class Reservation
    {
        public int ID { get; set; }
        public virtual User Issuer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finnish { get; set; }
    }
}