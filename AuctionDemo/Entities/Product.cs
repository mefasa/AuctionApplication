using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionDemo.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [StringLength(300)]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Güncel Fiyat")]
        public double Price { get; set; }
        [DisplayName("Durum")]
        public bool IsApproved { get; set; }
        [DisplayName("Resim")]
        public string ImagePath { get; set; }
        public int CategoryId{ get; set; }
        public Category Category  { get; set; }
        public string UserId { get; set; } = "";
        public List<Offer> Offers { get; set; }
        public List<Comment> Comments { get; set; }

    } 
}