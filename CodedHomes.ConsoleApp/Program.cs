using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using CodedHomes.Data;

namespace CodedHomes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Initializing Database...");
                DataContext context = new DataContext();
                context.Database.Initialize(true);

                Console.WriteLine("Done...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
