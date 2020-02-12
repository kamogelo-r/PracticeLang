using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLang
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> pets = new Dictionary<string, int>(); // used for lookups

            //if keys are the same, only the 2nd version is shown (the 1st is reassigned)
            pets.Add("dog", 3);
            pets.Add("cat", 1);
            pets.Add("hamster", 2);
            
            string[,] codes = new string[,]
            {
                {"AA","BB" },
                {"CC","DD" }
            };

            for (int i = 0; i < codes.GetUpperBound(1); i++)
            {
                Console.WriteLine(codes[i,0]);
                Console.WriteLine(codes[i, 1]);
            }

            try
            {
                ContainsItem(pets);

                TryGetValueItem(pets);

                Pairs(pets);

                ListOfKeys(pets);

                AccessPairVsKeys(pets);

                LinqDictionary();

                AddMyRange();
            }
            catch (KeyNotFoundException ex)
            {
                throw ex;
            }
            
            Console.Read();
        }

        private static void ContainsItem(Dictionary<string, int> pets)
        {
            if (pets.ContainsKey("hamster")) // contains 
                Console.WriteLine(pets["hamster"]); // identify it by the key, but the value will be outputted
        }

        private static int TryGetValueItem(Dictionary<string, int> pets)
        {
            int test;
            if (pets.TryGetValue("cat", out test)) // trygetvalue
                Console.WriteLine(test);

            return test;
        }

        private static void Pairs(Dictionary<string, int> pets)
        {
            Console.WriteLine("\nDictionary Items:");
            foreach (KeyValuePair<string, int> item in pets) // keyvaluepairs
            {
                Console.WriteLine(item.Key, item.Value);
            }
        }

        private static void ListOfKeys(Dictionary<string, int> pets)
        {
            List<string> keyList = new List<string>(pets.Keys); // list of keys

            keyList.Sort();

            Console.WriteLine("\nList of Keys:");
            foreach (var item in keyList)
            {
                Console.WriteLine(item);
            }
        }

        private static void AccessPairVsKeys(Dictionary<string, int> pets) // always access pairs first rather than extracting values
        {
            int sum = 0;
            const int maxTime = 1000000;

            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < maxTime; i++)
            {
                foreach (var item in pets)
                {
                    sum += item.Value;
                }
            }
            stopwatch.Stop();

            var stopwatch2 = Stopwatch.StartNew();
            for (int i = 0; i < maxTime; i++)
            {
                foreach (var item in pets.Keys)
                {
                    sum += pets[item]; // or item.Key
                }
            }
            stopwatch2.Stop();

            Console.WriteLine("\nTime Elapsed:");
            Console.WriteLine("Dictionary: {0}", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Keys: {0}", stopwatch2.Elapsed.TotalMilliseconds);
        }

        private static void LinqDictionary()
        {
            string[] arr = new string[] { "One", "Two", "Three" };

            Array.Sort(arr);

            var dictionaryList = arr.ToDictionary(x => x, x => true);

            Console.WriteLine("\nArray to Dictionary Items:");
            foreach (var item in dictionaryList)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
        
        private static void AddMyRange()
        {
            List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5 };

            int[] numbersArray = new int[] { 6, 7, 8 };

            numbersList.AddRange(numbersArray);

            Console.WriteLine("\nAdd Range:");
            foreach (var item in numbersList)
            {
                Console.WriteLine(item);
            }

            //for (int i = 0; i > numbersList.Count; i++) // arrays = length (-1 = start from back)
            //{
            //    Console.WriteLine(i);
            //}

            Console.WriteLine("\nCopied List:");
            List<int> copiedList = new List<int>(numbersList);
            Console.WriteLine(copiedList.Count);
        }

        private static void CommaSeparatedCollections()
        {
            #region Comma separated list and array
            //Console.WriteLine("-------"); 
            //List<int> nums = new List<int>() { 1, 2, 3 };
            //string line = string.Join(",", nums.ToArray());
            //Console.WriteLine(line);
            //Console.WriteLine("***");
            //int[] arr = new int[] { 5, 6, 7 };
            //string commas = string.Join(",", arr);
            //Console.WriteLine(commas);
            //Console.WriteLine("***");

            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("-------"); 
            #endregion
        }
    }
}
