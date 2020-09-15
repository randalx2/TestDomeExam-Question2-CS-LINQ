using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueProduct_LINQ
{
    //Q2 Senior Web dev exam NML
    //Praneel Misthry VS Studio attempt

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UniqueProductLinq
    {
        public static IProduct FirstUniqueProduct(IEnumerable<IProduct> products)
        {
            //throw new InvalidOperationException("Waiting to be implemented.");

            var distinctList = products
                .GroupBy(x => x.Name)
                .Where(g => !g.Skip(1).Any())
                .Select(x => x.First())
                .ToList();

            if (distinctList == null || distinctList.Count <= 0)
            {
                //No distinct elements found
                return null;
            }

            //Return the first distinct element
            return distinctList.FirstOrDefault();
        }

        public static void Main(string[] args)
        {
            //Example case
            Console.WriteLine(
                FirstUniqueProduct(
                    new IProduct[]
                    {
                        new Product("Apple"),
                        new Product("Computer"),
                        new Product("Apple"),
                        new Product("Bag")
                    }
                ).Name
            );
        }
    }

    // Do not modify this interface
    public interface IProduct
    {
        string Name { get; }
    }

    // Do not modify this class
    public class Product : IProduct
    {
        public string Name { get; }

        public Product(string name)
        {
            Name = name;
        }
    }
}
