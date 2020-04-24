using AuctionDemo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionDemo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [StringLength(200)]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Başlangıç Fiyat")]
        public double Price { get; set; }
        public string ImagePath { get; set; }
        [DisplayName("Yayın Durumu")]
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Güncel Teklif")]
        public double? OfferValue { get; set; }
        public string UserId { get; set; } = "";
        public List<Offer> Offers { get; set; }
        public List<CommentModel> Comments { get; set; }
        

    }
}