﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class Produkt_Razor
    {
        private string name;
        public int ProductID { get; set; }
        public string Name
        {
            get;
            set;
        }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}