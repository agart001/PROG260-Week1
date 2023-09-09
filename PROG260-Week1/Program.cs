using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using static PROG260_Week1.Utility;

namespace PROG260_Week1
{
    internal class Program
    {
        /*
         The number of games
Which genre is the most frequent
Which map names have the most number of characters excluding spaces, and which game they belong to
A dictionary that uses the Id Property as a Key and Info object as a value, then display all the information using a loop
The map names that have the letter z in them
         */
        public static GameInfo GI = new GameInfo();
        static void Main(string[] args)
        {
            Spacer();
            Print($"GameInfo Count: {GI.MetaData.Count + 1}", true);

            List<string> genres = new List<string>();
            GI.MetaData.ForEach(game => genres.Add(game.Genre));
            
            Spacer();
            Print($"Most Frequent Genre: {ListMostFrequent<string>(genres)}", true);

            List<string> maps = new List<string>();
            GI.MetaData.ForEach(game => maps.AddRange(game.MapNames.ToList()));
            string mostcharsmap = ListMostChars<string>(maps);

            Spacer();
            Print($"Most Char Map/Game: {mostcharsmap} / {GI.MetaData.Find(game => game.MapNames.Contains(mostcharsmap)).Name}", true);


            Dictionary<int, Info> infodict = new Dictionary<int, Info>();
            GI.MetaData.ForEach(game => infodict.Add(game.Id, game));

            Spacer();
            Print("Info Dict Display", true);
            Spacer();

            foreach(Info value in infodict.Values)
            {
                DisplayInfo(value);
            }

            List<string> zmaps = maps.FindAll(map => map.Contains('z'));

            Print($"Maps that contain 'Z': {ListToString<string>(zmaps)} ", true);

            Spacer();

            //GI.MetaData.ForEach(game )

            //Print($"Longest Map Name and Game of Origin: ")
        }
    }

}