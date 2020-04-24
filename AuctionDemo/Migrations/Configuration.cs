namespace AuctionDemo.Migrations
{
    using AuctionDemo.Context;
    using AuctionDemo.Entities;
    using AuctionDemo.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionDemo.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionDemo.Context.DataContext context)
        {

            //context.Database.ExecuteSqlCommand("delete from Offers");
            //context.Database.ExecuteSqlCommand("delete from Comments");
            //context.Database.ExecuteSqlCommand("delete from Categories");
            //context.Database.ExecuteSqlCommand("delete from Products");



            List<Category> categoryList = new List<Category>()
            {
                 new Category()
                {
                    Id = 1,
                    Name = "Elektronik",
                    Description = "Elektronik eþyalar."
                },
                new Category()
                {
                    Id = 2,
                    Name = "Vasýta",
                    Description = "Motorlu taþýtlar."
                }

            };
            foreach (var category in categoryList)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();


            List<Product> productList = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Samsung",
                    Description = "Samsung cep telefonu 3 senelik sadece ekranda ufak çizikler var.32 GB hafýza bulunmakta.16 MegaPiksel kamerasý bulunmakta.Tertemiz açýk artýrmada!!",
                    Price = 350,
                    IsApproved = true,
                    ImagePath = "1.jpg",
                    CategoryId = 1,
                    Comments = new List<Comment>()

                },
                new Product()
                {
                    Id = 2,
                    Name = "Canon",
                    Description = "Profesyonel kamera.Doða manzara çekimleri için tam ideal ucuz fiyattan açýk artýrmayý baþlatýyoruz.Hiçbir sýkýntýsý bulunmamaktadýr.Profesyonel veya hobi amacýyla kullanýma uygundur",
                    Price = 550,
                    IsApproved = true,
                    ImagePath = "5.jpg",
                    CategoryId = 1,
                    Comments = new List<Comment>()
                },
                new Product()
                {
                    Id = 3,
                    Name = "Asus",
                    Description = "Dizüstü bilgisayar.1 senelik garantisi devam etmekte Intel Core i5 7300 iþlemci,Nvidia GeForce GTX 1060 Ekran kartý 16 GB Ram bulunmaktadýr.Oyuncular için idealdir.Tam performans çalýþýr ve ayrýca GTA 5 kaldýrýyor :)",
                    Price = 3.500,
                    IsApproved = true,
                    ImagePath = "3.jpg",
                    CategoryId = 1,
                    Comments = new List<Comment>()
                },
                new Product()
                {
                    Id = 4,
                    Name = "Mercedes",
                    Description = "Sedan aile aracý.Kalitesi sorgulanmaz bilen bilir Mercedesi. 15.000 km de tertemiz 2016 model cla 200.Ýçerisinde küfür bile edilmemiþtir.Doya doya ailenizle binin diye uygun fiyattan açýk artýrmada!",
                    Price = 150.000,
                    IsApproved = true,
                    ImagePath = "2.jpg",
                    CategoryId = 2,
                    Comments = new List<Comment>()
                },
                new Product()
                {
                    Id = 5,
                    Name = "Man",
                    Description = "Ticari kamyon, Alman panzeri MAN'dan.Yalan deðil az yakmaz çok da kaçmaz fakat her yükü çeker.Az kullanýldý icradan aldýk o yüzden ucuz akýllarda bi soru iþareti olmasýn lütfen!",
                    Price = 200.000,
                    IsApproved = true,
                    ImagePath = "4.jpg",
                    CategoryId = 2,
                    Comments = new List<Comment>()
                }


            };
            foreach (var product in productList)
            {
                context.Products.Add(product);
            }


            //sql string i ilk olarak update yap(sql2 i komutunu açýklama satýrýna al.).
            //daha sonra run edip / account / register' da AdminFatih@wissen.com veya AdminAltug@wissen.com adýnda kullanýcý oluþtur.
            //en son olarak sql2 string i açýklama satýrýndan çýkarýp update yap.

            //string sql = "";
            //sql += "declare @sayi int ";
            //sql += "select @sayi = COUNT(*) from AspNetRoles where Name = 'Admin' ";
            //sql += "if @sayi = 0 ";
            //sql += "begin ";
            //sql += "insert into AspNetRoles (Id, Name) values ('1', 'Admin') ";
            //sql += "end";

            //context.Database.ExecuteSqlCommand(sql);



            string sql2 = "insert into AspNetUserRoles(UserId, RoleId) select Id,'1' from AspNetUsers where Email = 'AdminAltug@wissen.com'";

            context.Database.ExecuteSqlCommand(sql2);




            context.SaveChanges();



        }
    }
}
