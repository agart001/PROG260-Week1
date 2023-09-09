using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG260_Week1
{
    internal static class Utility
    {
        public static void Print(string input, bool newline)
        {
            Console.Write(input);

            if (newline) Console.WriteLine();
        }

        public static void Spacer() => Print("----------------------------------", true);

        public static string ListToString<S>(List<S> list)
        {
            string liststring = "";
            foreach (S s in list)
            {
                liststring += $"{s} ";
            }

            return liststring;
        }

        public static int GetLetterCount(dynamic input)
        {
            char[] chars = input.ToCharArray();
            return chars.Where(c => c != ' ').Count();
        }


        public static S ListMostFrequent<S>(List<S> list)
        {
            List<S> unique = list.Distinct().ToList();

            int[] counts = new int[unique.Count];
            int index = 0;

            foreach (S el in unique)
            {
                counts[index] = list.FindAll(g => g.Equals(el)).Count;
                index++;
            }

            return unique[Array.IndexOf(counts, counts.Max())];;
        }

        public static S ListMostChars<S>(List<S> list)
        {
            int[] charcounts = new int[list.Count];

            int index = 0;
            foreach (S el in list)
            {
                charcounts[index] = GetLetterCount(el);
                index++;
            }
            return list[Array.IndexOf(charcounts, charcounts.Max())]; ;
        }

        public static void DisplayInfo(Info info)
        {
            Print($"Name: {info.Name}", true);
            Print($"Genre: {info.Genre}", true);

            Print("Maps:", false);
            int index = 0;
            foreach(string map in info.MapNames)
            {
                Print($" {map}", false);
                if(index == info.MapNames.Length-1) Print(Environment.NewLine, false);
                index++;
            }

            Spacer();
        }


    }
}
