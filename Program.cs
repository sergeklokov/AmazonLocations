using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonLocations
{
    class Restaurant {
        public int x;
        public int y;
        public double dist;
    }

    //class CompareDist : IComparer
    //{
    //    public int Compare(object x, object y)
    //    {
    //        var r1 = (Restaurant)x;
    //        var r2 = (Restaurant)y;

    //        if (r1.dist > r2.dist)
    //            return 1;

    //        return 0;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            int[,] allLocations;
            int totalSteakhouses = 4;
            int numSteakhouses = 2;

            allLocations = new int[,]
               {
                   {1,2},
                   {3,4 },
                   {5,-3 },
                   {1,-1 }
               };

            var list = new List<Restaurant>();

            for (int i = 0; i < totalSteakhouses; i++)
            {
                //var maxDistance = 555;

                // Cust location is 0,0 so
                var distance = Math.Sqrt(
                        allLocations[i, 0] * allLocations[i, 0] 
                    +   allLocations[i, 1] * allLocations[i, 1]);

                Console.WriteLine("i={0}, [{1},{2}];  distance = {3}", i, allLocations[i, 0], allLocations[i, 1], distance);

                //if (distance <= maxDistance)
                //{
                    list.Add(new Restaurant { x = allLocations[i, 0], y = allLocations[i, 1], dist = distance });
                //}

            }

            var orderedListByDistance = list.OrderBy(r => r.dist);
            var restaurantsNear = orderedListByDistance.Take(numSteakhouses);

            foreach (var r in restaurantsNear)
            {
                Console.WriteLine("[{0},{1}];  distance = {2}", r.x, r.y, r.dist);
            }

            var res = new List<List<int>>();

            foreach (var item in restaurantsNear)
            {
                res.Add(new List<int> { item.x, item.y });
            }


            Console.ReadKey();



        }
    }
}
