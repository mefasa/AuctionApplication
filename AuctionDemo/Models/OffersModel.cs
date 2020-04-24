using AuctionDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionDemo.Models
{
    public class OffersModel
    {
        public double Price { get; set; }
        public List<Offer> Offers { get; set; }
    }
}