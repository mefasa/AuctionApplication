using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionDemo.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string ContentText { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
    }
}