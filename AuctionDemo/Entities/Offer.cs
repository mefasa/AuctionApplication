using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionDemo.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public double? OfferValue { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }


    }
}