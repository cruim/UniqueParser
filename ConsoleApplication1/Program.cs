using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class PartialComparer : IEqualityComparer<string>
    {
        public string GetComparablePart(string s)
        {
            return s.Split('@')[1];
        }
        public bool Equals(string x, string y)
        {
            return GetComparablePart(x).Equals(GetComparablePart(y));
        }

        public int GetHashCode(string obj)
        {
            return GetComparablePart(obj).GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
        {
            "xVWdAv:nsY31k@217.29.62.74:8000",
            "xVWdAv: nsY31k@217.29.63.217:8000",
            "xVWdAv: nsY31k@217.29.62.110:8000",
            "xVWdAv: nsY31k@217.29.63.217:8000",
            "xVWdAv: nsY31k@217.29.62.110:8000",
            "ywSICy:PgZuYf@185.147.128.14:8000"


        };

            
            var result = list.Distinct(new PartialComparer()).ToList();

            foreach (var v in result)
            {
                Console.WriteLine(v);
            }

            Console.ReadLine();
        }
    }
}
