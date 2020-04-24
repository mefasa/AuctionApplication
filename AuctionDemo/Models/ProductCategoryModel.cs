using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AuctionDemo.Models
{
    public class ProductCategoryModel
    {
        public int ProductId { get; set; }
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }
        [DisplayName("Açıklama")]
        public string ProductDescription { get; set; }
        [DisplayName("Güncel Fiyat")]
        public double Price { get; set; }
        [DisplayName("Durum")]
        public bool IsApproved { get; set; }
        [DisplayName("Resim Kaynağı")]
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Kategori")]
        public string CategoryName { get; set; }
    }
}