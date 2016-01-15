using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodedHomes.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CodedHomes.Data.Configuration
{
    public class CustomDatabaseInitializer : 
        DropCreateDatabaseIfModelChanges<DataContext>
        //CreateDatabaseIfNotExists<DataContext>
    {
        /// <summary>
        /// seed the database!
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataContext context)
        {
            string[] descriptions = new string[10] { 
                "buen veciendario",
                "a truly beatiful home",
                "in a cul-de-dac on a quiet",
                "freeway accessible",
                "lots of storage",
                "well-kept by pre",
                "includes pool, spa",
                "the back fence needs",
                "includes a huge bonues",
                "close to local"
            };

            int count = 10;
            while ((count--) != 0)
            {
                Home home = new Home();
                home.StreetAddress = string.Format("12{0} Street St.", count);
                home.City = "anytown";
                home.ZipCode = 90210;
                home.Bedrooms = ((count % 2) == 1) ? 4 : 3;
                home.Bathrooms = (home.Bedrooms - 2);
                home.SquareFeet = 3700 + count;
                home.Price = 275000 + (count * 1000);
                home.ImageName = string.Format("home-{0}.jpg", ((count % 2) == 1));
                home.Description = descriptions[count];

                context.Homes.Add(home);
            }

            base.Seed(context);
        }
    }
}
