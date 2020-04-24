using AuctionDemo.Context;
using AuctionDemo.Entities;
using AuctionDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace AuctionDemo.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        ApplicationDbContext Idb = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.Products.Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                ImagePath = i.ImagePath == null ? "1.jpg" : i.ImagePath,
                CategoryId = i.CategoryId
            }).ToList();
            return View(products);
        }



        public ActionResult Details(int id)
        {
            var product = db.Products.FirstOrDefault(e => e.Id == id);

            ProductModel productModel = new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath,
                IsApproved = product.IsApproved,
                CategoryId = product.CategoryId

            };
            productModel.Offers = new List<Offer>();
            var offers = db.Offers.Where(e => e.ProductId == product.Id).ToList();
            foreach (var item in offers)
            {
                productModel.Offers.Add(item);
            }
            productModel.Comments = new List<CommentModel>();
            var comments = db.Comments.Where(e => e.ProductId == product.Id).ToList();


            foreach (var item in comments)
            {
                var user = Idb.Users.FirstOrDefault(e => e.Id == item.UserId);
                string[] user2 = user.UserName.Split('@');
                string userName = user2[0];
                CommentModel commentModel = new CommentModel()
                {
                    Id = item.Id,
                    ContentText = item.ContentText,
                    ProductId = product.Id,
                    UserName = userName,


                };
                productModel.Comments.Add(commentModel);

            }
            return View(productModel);
        }
        [HttpPost]
        public ActionResult Details(int id, double? OfferValue, string ContentText)
        {
            var product = db.Products.FirstOrDefault(e => e.Id == id);

            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = Idb.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (currentUser==null)
            {
                if (OfferValue!=null)
                {
                    MessageBox.Show("Teklif verebilmek için üye olmanız gerekmektedir!");
                }
                else
                {
                    MessageBox.Show("Yorum yapabilmek için üye olmanız gerekmektedir!");
                }
                
                return RedirectToAction("/Details/" + id);
            }
            else
            {
                string[] user = currentUser.UserName.Split('@');
                string userName = user[0];

                if (!String.IsNullOrEmpty(ContentText))
                {

                    Comment comment = new Comment()
                    {
                        ContentText = ContentText,
                        ProductId = product.Id,
                        UserId = currentUserId
                    };
                    db.Comments.Add(comment);
                    product.Comments.Add(comment);
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("/Details/" + id);
                }
                if (OfferValue != null)
                {
                    var offers = db.Offers.Where(e => e.ProductId == product.Id).ToList();
                    if (offers.Count == 0)
                    {
                        if (OfferValue > product.Price)
                        {
                            Offer offer = new Offer()
                            {
                                ProductId = product.Id,
                                OfferValue = OfferValue,
                                UserId = currentUserId,
                                UserName = userName
                            };
                            db.Offers.Add(offer);
                            product.UserId = currentUserId;
                            product.Offers = new List<Offer>();
                            product.Offers.Add(offer);
                        }
                        else
                        {
                            //ViewData["OfferValueNotAccept"] = "Teklifiniz, başlangıç fiyatından yüksek olmalıdır!";
                            MessageBox.Show("Teklifiniz, Başlangıç fiyatından yüksek olmalıdır!");
                        }
                    }
                    else if (offers.Count > 0)
                    {
                        int count = 0;
                        foreach (var item in offers)
                        {
                            if (OfferValue > item.OfferValue)
                            {
                                count++;
                            }
                        }
                        if (count == offers.Count)
                        {
                            Offer offer = new Offer()
                            {
                                ProductId = product.Id,
                                OfferValue = OfferValue,
                                UserId = currentUserId,
                                UserName = userName
                            };
                            db.Offers.Add(offer);
                            product.UserId = currentUserId;
                            product.Offers.Add(offer);
                        }
                        else
                        {
                            MessageBox.Show("Teklifiniz Son Tekliften Yüksek Olmalıdır!");
                        }

                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Details/" + id);
            }
            
        }
    

        public ActionResult List(int? id,string q,string Price)
        {
            var products = db.Products.Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                ImagePath = i.ImagePath,
                CategoryId = i.CategoryId
            }).AsQueryable();
            if (id != null)
            {
                products = products.Where(i => i.CategoryId == id);
                if (!string.IsNullOrWhiteSpace(Price))
                {
                    if (Price == "range1")
                    {
                        products = products.Where(i => i.Price >= 0 && i.Price < 250);
                    }
                    else if (Price == "range2")
                    {
                        products = products.Where(i => i.Price >= 250 && i.Price < 500);
                    }
                    else if (Price == "range3")
                    {
                        products = products.Where(i => i.Price >= 500);
                    }
                }
                return View(products.ToList());
            }
            if (id == null)
            {
                if (!string.IsNullOrWhiteSpace(Price))
                {
                    if (Price == "range1")
                    {
                        products = products.Where(i => i.Price >= 0 && i.Price < 250);
                    }
                    else if (Price == "range2")
                    {
                        products = products.Where(i => i.Price >= 250 && i.Price < 500);
                    }
                    else if (Price == "range3")
                    {
                        products = products.Where(i => i.Price >= 500);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(q))
                {
                    products = products.Where(i => i.Name.Contains(q) || i.Description.Contains(q));
                }
                
            }
            
            //else if (!string.IsNullOrWhiteSpace(Price))
            //{
            //    if (Price == "range1")
            //    {
            //        products = products.Where(i => i.Price >= 0 && i.Price < 250);
            //    }
            //    else if (Price == "range2")
            //    {
            //        products = products.Where(i => i.Price >= 250 && i.Price < 500);
            //    }
            //    else if(Price == "range3")
            //    {
            //        products = products.Where(i => i.Price >= 500);
            //    }
            //}
            return View(products.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(db.Categories.ToList());
        }
        
    }
}