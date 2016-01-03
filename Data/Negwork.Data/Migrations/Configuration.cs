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
                    },
                    new Article()
                    {
                        Author = pesho,
                        DatePublished = new DateTime(2015, 05, 20),
                        Title = "Let's talk about cats.",
                        Description = "Cats are similar in anatomy to the other felids, with a strong, flexible body, quick reflexes, sharp retractable claws, and teeth adapted to killing small prey. Cat senses fit a crepuscular and predatory ecological niche. Cats can hear sounds too faint or too high in frequency for human ears, such as those made by mice and other small animals. They can see in near darkness. Like most other mammals, cats have poorer color vision and a better sense of smell than humans.<br /><br />Despite being solitary hunters, cats are a social species and cat communication includes the use of a variety of vocalizations (mewing, purring, trilling, hissing, growling, and grunting), as well as cat pheromones and types of cat-specific body language.<br /><br />Cats have a high breeding rate. Under controlled breeding, they can be bred and shown as registered pedigree pets, a hobby known as cat fancy. Failure to control the breeding of pet cats by neutering and the abandonment of former household pets has resulted in large numbers of feral cats worldwide, requiring population control. This has contributed, along with habitat destruction and other factors, to the extinction of many bird species. Cats have been known to extirpate a bird species within specific regions and may have contributed to the extinction of isolated island populations. Cats are thought to be primarily, though not solely, responsible for the extinction of 33 species of birds, and the presence of feral and free ranging cats makes some locations unsuitable for attempted species reestablishment in otherwise suitable locations.",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Content = "Awww cats are so cute.", CreationDate = new DateTime(2015, 09, 01), User = gosho }
                        },
                        Ratings = new List<Rating>()
                        {
                            new Rating() { User = gosho, Value = 4 },
                            new Rating() { User = admin, Value = 5 }
                        },
                        AllRatings = 9,
                        NumberOfRatings = 3
                    },
                    new Article()
                    {
                        Author = pesho,
                        DatePublished = new DateTime(2015, 07, 04),
                        Title = "Life in the wild",
                        Description = "The lion (Panthera leo) is one of the five big cats in the genus Panthera and a member of the family Felidae. The commonly used term African lion collectively denotes the several subspecies found in Africa. With some males exceeding 250 kg (550 lb) in weight, it is the second-largest living cat after the tiger. Wild lions currently exist in sub-Saharan Africa and in Asia (where an endangered remnant population resides in Gir Forest National Park in India) while other types of lions have disappeared from North Africa and Southwest Asia in historic times. Until the late Pleistocene, about 10,000 years ago, the lion was the most widespread large land mammal after humans. They were found in most of Africa, across Eurasia from western Europe to India, and in the Americas from the Yukon to Peru. The lion is a vulnerable species, having seen a major population decline in its African range of 30–50% per two decades during the second half of the twentieth century. Lion populations are untenable outside designated reserves and national parks. Although the cause of the decline is not fully understood, habitat loss and conflicts with humans are currently the greatest causes of concern. Within Africa, the West African lion population is particularly endangered.<br /><br />In the wild, males seldom live longer than 10 to 14 years, as injuries sustained from continual fighting with rival males greatly reduce their longevity. In captivity they can live more than 20 years. They typically inhabit savanna and grassland, although they may take to bush and forest. Lions are unusually social compared to other cats. A pride of lions consists of related females and offspring and a small number of adult males. Groups of female lions typically hunt together, preying mostly on large ungulates. Lions are apex and keystone predators, although they are also expert scavengers obtaining over 50 percent of their food by scavenging as opportunity allows. While lions do not typically hunt humans, some have. Sleeping mainly during the day, lions are active primarily at night (nocturnal), although sometimes at twilight(crepuscular).",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Content = "Woah this is a bit scary.", CreationDate = new DateTime(2015, 07, 05), User = admin }
                        },
                        Ratings = new List<Rating>()
                        {
                            new Rating() { User = gosho, Value = 5 }
                        },
                        AllRatings = 5,
                        NumberOfRatings = 1
                    },
                    new Article()
                    {
                        Author = gosho,
                        DatePublished = new DateTime(2016, 01, 01),
                        Title = "Aye-aye - the living terror",
                        Description = "The aye-aye (Daubentonia madagascariensis) is a lemur, a strepsirrhine primate native to Madagascar that combines rodent-like teeth that perpetually grow and a special thin middle finger.<br /><br />It is the world's largest nocturnal primate, and is characterized by its unusual method of finding food; it taps on trees to find grubs, then gnaws holes in the wood using its forward slanting incisors to create a small hole in which it inserts its narrow middle finger to pull the grubs out. This foraging method is called percussive foraging which takes up 5-41% of foraging time. The only other animal species known to find food in this way is the striped possum. From an ecological point of view the aye-aye fills the niche of a woodpecker, as it is capable of penetrating wood to extract the invertebrates within.<br /><br />The aye-aye is the only extant member of the genus Daubentonia and family Daubentoniidae. It is currently classified as Endangered by the IUCN; and a second species, Daubentonia robusta, appears to have become extinct at some point within the last 1000 years.",
                        Comments = new List<Comment>()
                        {
                            new Comment() { Content = "This shit is ugly yo. :xx", CreationDate = new DateTime(2016, 01, 02), User = pesho },
                            new Comment() { Content = "Yea I couldn't agree more...", CreationDate = new DateTime(2016, 01, 03), User = admin }
                        },
                        AllRatings = 0,
                        NumberOfRatings = 0
                    }
                }
            };

            context.Categories.AddOrUpdate(c => c.Name,
                animalsCategory);

            context.SaveChanges();
        }
    }
}
