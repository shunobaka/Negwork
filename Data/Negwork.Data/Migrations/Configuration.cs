namespace Negwork.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using Microsoft.AspNet.Identity;
    using System;
    using Common;
    using System.Collections.Generic;
    public sealed class Configuration : DbMigrationsConfiguration<NegworkDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NegworkDbContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            //
            //   context.People.AddOrUpdate(
            //     p => p.FullName,
            //     new Person { FullName = "Andrew Peters" },
            //     new Person { FullName = "Brice Lambson" },
            //     new Person { FullName = "Rowan Miller" }
            //   );

            var admin = new User()
            {
                Email = "admin@negwork.com",
                PasswordHash = new PasswordHasher().HashPassword("admin"),
                FirstName = "Pesho",
                LastName = "Goshov",
                AdditionalInfo = "I am the admin so you better watch out./r/n Don't mess with me.",
                DateOfBirth = new DateTime(1990, 12, 31),
                Gender = Gender.Male,
                UserName = "admin",
                ProfileImage = "http://www.customerparadigm.com/images/social-media/facebook-as-an-admin.jpg"
            };

            var pesho = new User()
            {
                Email = "pesho@negwork.com",
                PasswordHash = new PasswordHasher().HashPassword("111111"),
                FirstName = "Pesho",
                LastName = "Peshov",
                AdditionalInfo = "I am just a randomly seeded user so that the application doesn't feel so empty./r/nI like turtles.",
                DateOfBirth = new DateTime(1995, 04, 15),
                Gender = Gender.Male,
                UserName = "pesho",
                ProfileImage = "http://i49.vbox7.com/o/938/93850c8f0.jpg"
            };

            var gosho = new User()
            {
                Email = "gosho@negwork.com",
                PasswordHash = new PasswordHasher().HashPassword("111111"),
                FirstName = "Gosho",
                LastName = "Stamatov",
                AdditionalInfo = "I'm pretty shy so nothing to see here",
                DateOfBirth = new DateTime(1997, 01, 23),
                Gender = Gender.Male,
                UserName = "gosho",
                ProfileImage = "https://i.ytimg.com/vi/ZCiVuUczzgY/hqdefault.jpg"
            };

            context.Users.AddOrUpdate(u => u.UserName, admin, pesho, gosho);
            context.SaveChanges();

            var animalsCategory = new Category()
            {
                Name = "Animals",
                Image = "http://dreamatico.com/data_images/animals/animals-4.jpg",
                Articles = new List<Article>()
                    {
                        new Article()
                        {
                            Author = admin,
                            DatePublished = new DateTime(2014, 02, 23),
                            Title = "Dogs - all you need to know (or not).",
                            Description = "The domestic dog (Canis lupus familiaris or Canis familiaris) is a domesticated canid which has been selectively bred for millennia for various behaviors, sensory capabilities, and physical attributes.<br /><br />Although initially thought to have originated as a manmade variant of an extant canid species (variously supposed as being the dhole, golden jackal, or gray wolf), extensive genetic studies undertaken during the 2010s indicate that dogs diverged from an extinct wolf-like canid in Eurasia 40,000 years ago. Being the oldest domesticated animals with one study claiming for the past 33, 000 years, their long association with people has allowed dogs to be uniquely attuned to human behavior, as well as thrive on a starch - rich diet which would be inadequate for other canid species.<br /><br />Dogs perform many roles for people, such as hunting, herding, pulling loads, protection, assisting police and military, companionship, and, more recently, aiding handicapped individuals.This impact on human society has given them the nickname \"man's best friend\" in the Western world.In some cultures, however, dogs are a source of meat.",
                            Comments = new List<Comment>()
                            {
                                new Comment() { Content = "This is my first article so I really hope you guys like it.", CreationDate = new DateTime(2014, 02, 23), User = admin },
                                new Comment() { Content = "This is a very good article!", CreationDate = new DateTime(2014, 03, 20), User = pesho },
                                new Comment() { Content = "I think he stole this from Wikipedia", CreationDate = new DateTime(2015, 04, 12), User = gosho }
                            },
                            Ratings = new List<Rating>()
                            {
                                new Rating() { User = pesho, Value = 5 },
                                new Rating() { User = gosho, Value = 2 }
                            },
                            AllRatings = 7,
                            NumberOfRatings = 2
                        }
                    }
            };

            context.Categories.AddOrUpdate(c => c.Name,
                animalsCategory);
        }
    }
}
