using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public abstract class Reservation
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public virtual User Issuer { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finnish { get; set; }
    }
}