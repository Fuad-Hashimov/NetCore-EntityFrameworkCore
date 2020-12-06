using EntityFrameworkCore.Concrete.EntityFrameworkCore.ContextAplication;
using EntityFrameworkCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EntityFrameworkCore.Repository
{
    internal static class EFRepository
    {

        public static void GetAllProduct()
        {
            using var context = new AplicationContext();
            var products = context.Products.Select(I => new
            {
                I.Name,
                I.Price
            }).ToList();

            foreach (var item in products)
            {
                Console.WriteLine($"Name : {item.Name} Price : {item.Price}");
            }
             
        }

        public static void AddProduct()
        {
            using var context = new AplicationContext();
            var product = new Product() {Name = "Samsung 5" , Price=960};
            context.Products.Add(product);
            context.SaveChanges();
        }
        
        public static void AddProducts()
        {
            using var context = new AplicationContext();

            var products = new List<Product>()
            {
                new Product {Name="Nokia",Price=350},
                new Product {Name="Oppo",Price=1250},
                new Product {Name="Lg",Price=1350},
                new Product {Name="Samsung Note 9",Price=1600}
            };

            context.Products.AddRange(products);    
            context.SaveChanges();     
        }

        public static void GetProductById(int id)
        {
            using var context = new AplicationContext();
            var product = context.Products
                .Where(I => I.Id == id)
                .Select(I => new 
                {
                    I.Name,
                    I.Price
                }).FirstOrDefault();

            Console.WriteLine($"Id : {product.Name}  Name : {product.Price}");
        }

        public static void GetProductsByName(string name)
        {
            var nameSearch =name.Trim();
            using var context = new AplicationContext();
            var products = context.Products
                .Where(I => I.Name.ToLower().Contains(nameSearch))
                .Select(I => new
                {
                    I.Name,
                    I.Price
                })
                .ToList();
            foreach (var item in products)
            {
                Console.WriteLine($"Name : {item.Name} Price : {item.Price}");
            }
        }

        public static void GetProductBetweenTwoPrices(decimal minPrice,decimal maxPrice) 
        {
            if (minPrice <= 0 || maxPrice <=0)
            {
                Console.WriteLine("MinPrice Or MaxPrice is Zero");
            }
            try
            {
                using var context = new AplicationContext();

                var products = context.Products
                    .Where(I => I.Price > minPrice && I.Price < maxPrice)
                    .OrderBy(I => I.Price)
                    .Select(I => new
                    {
                        I.Name,
                        I.Price
                    }).ToList();

                foreach (var p in products)
                {
                    Console.WriteLine($"Name : {p.Name} Price : {p.Price}");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }

        public static void UpdateProduct()
        {

            using var context = new AplicationContext();
            var product = context.Products.Where(I => I.Id == 1).FirstOrDefault();
            if (product != null)
            {
                product.Price = 450m;
                context.Products.Update(product);
                context.SaveChanges();
                Console.WriteLine("Success");
            }



            //using var context = new AplicationContext();
            //var p = new Product() { Id = 1 };
            //context.Products.Attach(p);

            //p.Price = 150m;
            //context.SaveChanges();
            //Console.WriteLine("Success");




            // change tracking

            //using var context = new AplicationContext();
            //var p = context.Products.Where(I => I.Id == 1).FirstOrDefault();
            //if (p != null)
            //{
            //    p.Price *= 1.2m;
            //    context.SaveChanges();
            //    Console.WriteLine("Success");
            //}


        }

        public static void RemoveProduct()
        {
            using var context = new AplicationContext();
            var p = new Product() { Id = 20 };
            context.Entry(p).State = EntityState.Deleted;
            context.SaveChanges();


            //using var context = new AplicationContext();
            //var product = context.Products.Where(I => I.Id == 21).FirstOrDefault();
            //if (product != null)
            //{
            //    context.Products.Remove(product);
            //    context.SaveChanges();
            //    Console.WriteLine("Success");
            //}
        }

        public static void GetUsers()
        {
            using var context = new AplicationContext();
            var users = context.Users
                .Select(I => new
                {
                    I.Name,
                    I.Email
                })
                .ToList();
            foreach (var item in users)
            {
                Console.WriteLine($" Name : {item.Name} Email : {item.Email}");
            }
        }

        public static void InsertUser()
        {
            var users = new List<User>()
            {
                new User {Name="Con",Email="Con@gmail.com"},
                new User {Name="Ted",Email="Ted@gmail.com"},
                new User {Name="Tom",Email="Tom@gmail.com"},
                new User {Name="Sonya",Email="Sonya@gmail.com"},
                new User {Name="Kate",Email="Kate@gmail.com"},
            };

            using var context = new AplicationContext();

            context.Users.AddRange(users);
            context.SaveChanges();
            Console.WriteLine("Success");

        }

        public static void InsertAddress()
        {
            var address = new List<Address>()
            {
                new Address{FullName = "USA",Body="Vircina",Title="Home",UserId= 1},
                new Address{FullName = "Germany",Body="Vircina",Title="Work",UserId=3},
                new Address{FullName = "France",Body="Vircina",Title="Home",UserId=2},
                new Address{FullName = "Turkey",Body="Istanbul",Title="Work",UserId=5},
                new Address{FullName = "Russia",Body="Moskow",Title="Home",UserId=4}
            };

            using var context = new AplicationContext();
            context.Addresses.AddRange(address);
            context.SaveChanges();
            Console.WriteLine("Success");
        }

        public static void InsertAddressesUser()
        {
            using var context = new AplicationContext();
            var user = context.Users.FirstOrDefault(I => I.Name == "Kate");
            if (user != null)
            {
                user.Addresses = new List<Address>();

                user.Addresses.AddRange(new List<Address>(){
                    new Address { FullName = "Germany", Body = "Vircina", Title = "Work", UserId = 3 },
                    new Address { FullName = "France", Body = "Vircina", Title = "Home", UserId = 2 },
                    new Address { FullName = "Turkey", Body = "Istanbul", Title = "Work", UserId = 5 },
                    new Address { FullName = "Russia", Body = "Moskow", Title = "Home", UserId = 4 }
                });
                context.SaveChanges();
                Console.WriteLine("Success");
            }
        }

        public static void AddCustomer()
        {
            using var context = new AplicationContext();
            var customer = new Customer()
            {
                IdentityNumber = "123456",
                FirstName = "Roko",
                LastName = "Rokos",
                User = context.Users.FirstOrDefault(I => I.Id == 2)
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine("Success");
        }

        public static void AddUser_Customer()
        {
            using var context = new AplicationContext();
            var user = new User()
            {
                Name = "Test",
                Email = "Test@gmai.com",
                Customer = new Customer()
                {
                    IdentityNumber = "987654",
                    FirstName = "Test",
                    LastName = "Test"
                },
            };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("Success");
        }

        public static void AddProductCategory()
        {
            using var context = new AplicationContext();

            var products = new List<Product>()
            {
                new Product{Name="Samsung_1",Price=100},
                new Product{Name="Samsung_2",Price=200},
                new Product{Name="Samsung_3",Price=300},
                new Product{Name="Samsung_4",Price=400},
                new Product{Name="Samsung_5",Price=500}
            };
            //context.Products.AddRange(products);

            var categories = new List<Category>()
            {
                new Category{Name="Phone"},
                new Category{Name="PC"},
                new Category{ Name="TV"}
            };
            //context.AddRange(categories);

            int[] ids = new int[2] { 1, 2 };

            var p = context.Products.Find(1);

            p.Product_Catogories = ids.Select(cID => new Product_Catogory()
            {
                CategoryId = cID,
                ProductId = p.Id
            }).ToList();

            context.SaveChanges();
            Console.WriteLine("SUCCESS");
        }
    }
}
