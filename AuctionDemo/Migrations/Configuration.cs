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
                    Description = "Elektronik e�yalar."
                },
                new Category()
                {
                    Id = 2,
                    Name = "Vas�ta",
                    Description = "Motorlu ta��tlar."
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
                    Description = "Samsung cep telefonu 3 senelik sadece ekranda ufak �izikler var.32 GB haf�za bulunmakta.16 MegaPiksel kameras� bulunmakta.Tertemiz a��k art�rmada!!",
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
                    Description = "Profesyonel kamera.Do�a manzara �ekimleri i�in tam ideal ucuz fiyattan a��k art�rmay� ba�lat�yoruz.Hi�bir s�k�nt�s� bulunmamaktad�r.Profesyonel veya hobi amac�yla kullan�ma uygundur",
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
                    Description = "Diz�st� bilgisayar.1 senelik garantisi devam etmekte Intel Core i5 7300 i�lemci,Nvidia GeForce GTX 1060 Ekran kart� 16 GB Ram bulunmaktad�r.Oyuncular i�in idealdir.Tam performans �al���r ve ayr�ca GTA 5 kald�r�yor :)",
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
                    Description = "Sedan aile arac�.Kalitesi sorgulanmaz bilen bilir Mercedesi. 15.000 km de tertemiz 2016 model cla 200.��erisinde k�f�r bile edilmemi�tir.Doya doya ailenizle binin diye uygun fiyattan a��k art�rmada!",
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
                    Description = "Ticari kamyon, Alman panzeri MAN'dan.Yalan de�il az yakmaz �ok da ka�maz fakat her y�k� �eker.Az kullan�ld� icradan ald�k o y�zden ucuz ak�llarda bi soru i�areti olmas�n l�tfen!",
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


            //sql string i ilk olarak update yap(sql2 i komutunu a��klama sat�r�na al.).
            //daha sonra run edip / account / register' da AdminFatih@wissen.com veya AdminAltug@wissen.com ad�nda kullan�c� olu�tur.
            //en son olarak sql2 string i a��klama sat�r�ndan ��kar�p update yap.

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
