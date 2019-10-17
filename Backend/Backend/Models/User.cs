﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace Backend.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public DbSet<Reservation> longTermReservations { get; set; }
        public DbSet<Reservation> shortTermReservations { get; set; }
    }
}