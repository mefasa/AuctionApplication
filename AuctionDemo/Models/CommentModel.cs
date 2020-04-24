using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionDemo.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string ContentText { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
    }
}