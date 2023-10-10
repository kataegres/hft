using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace westeros
{
    static class Operations
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"************* {header} ************");
            foreach (var item in input) Console.WriteLine(item);
            Console.WriteLine($"************* {header} ************");
            Console.ReadLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("https://users.nik.uni-obuda.hu/prog3/_data/war_of_westeros.xml");
            Console.WriteLine(doc);
            Console.ReadLine();
            doc.Descendants("name").Select(x => x.Value).ToConsole("ALL");

            // 1
            var q1 = doc.
                Descendants("house").
                Select(node => node.Value).
                Distinct();
            Console.WriteLine($"TOTAL: {q1.Count()}");
            q1.ToConsole("Q1");

            // 2
            string str = "ambush";
            var q2 = from battleNode in doc.Descendants("battle")
                     where battleNode.Element("type")?.Value == str
                     select battleNode.Element("name")?.Value;
            q2.ToConsole("Q2");

            // 3
            var q3 = from battleNode in doc.Descendants("battle")
                     where battleNode.Element("outcome")?.Value == "defender" &&
                        (int)battleNode.Element("majorcapture") > 0
                     select battleNode.Element("name").Value;
            Console.WriteLine(q3.Count());
            q3.ToConsole("Q3");

            // 4
            var q4 = from battleNode in doc.Descendants("battle")
                     let whoWon = battleNode.Element("outcome").Value
                     let winnerHouses = battleNode.Element(whoWon).Elements("house").Select(x => x.Value)
                     where winnerHouses.Contains("Stark")
                     select new
                     {
                         BattleName = battleNode.Element("name").Value,
                         Outcome = whoWon,
                         Houses = String.Join("; ", winnerHouses)
                     };
            Console.WriteLine(q4.Count());
            q4.ToConsole("Q4");

            // 5
            var q5 = from battleNode in doc.Descendants("battle")
                     let attackerHouses = battleNode.Element("attacker").Elements("house").Count()
                     let defenderHouses = battleNode.Element("defender").Elements("house").Count()
                     let sumHouses1 = attackerHouses + defenderHouses
                     let sumHouses2 = battleNode.Descendants("house").Count()
                     let sumHouses3 = battleNode.Descendants("house").Select(x => x.Value).Distinct().Count()
                     where sumHouses3 > 2
                     orderby sumHouses3 descending
                     select new { BattleName = battleNode.Element("name").Value, NumHouses = sumHouses3, Region = battleNode.Element("region").Value };
            q5.ToConsole("Q5");

            // 6
            var q6 = from battleNode in doc.Descendants("battle")
                     group battleNode by battleNode.Element("region").Value into grp
                     let cnt = grp.Count()
                     orderby cnt descending
                     select new { Region = grp.Key, Count = cnt };
            q6.Take(3).ToConsole("Q6");
            var top3Counts = q6.Select(x => x.Count).Distinct().Take(3);
            q6.Where(grp => top3Counts.Contains(grp.Count)).ToConsole("Q6 - alter");

            // 7
            Console.WriteLine("Q7 = " + q6.FirstOrDefault());
            Console.ReadLine();

            // 8
            var q8 = from battle in q5
                     join region in q6.Take(3) on battle.Region equals region.Region
                     select new { battle, region };
            q8.ToConsole("Q8");

            // 9
            var q9 = from battleNode in doc.Descendants("battle")
                     let whoWon = battleNode.Element("outcome").Value
                     let winnerHouses = battleNode.Element(whoWon).Elements("house").Select(x => x.Value)
                     from house in winnerHouses
                     group house by house into grp
                     let winCount = grp.Count()
                     orderby winCount descending
                     select new { House = grp.Key, winCount };
            q9.ToConsole("Q9");

            // 10
            var q10 = from battleNode in doc.Descendants("battle")
                      let maxSize = doc.Descendants("size").Max(x => (int)x)
                      let currentSizes = battleNode.Descendants("size").Select(x => (int)x)
                      // let attackerSize = int.Parse(battleNode.Element("attacker").Element("size")?.Value ?? "0")
                      where currentSizes.Contains(maxSize)
                      select new
                      {
                          BattleName = battleNode.Element("name").Value,
                          Sizes = String.Join("; ", currentSizes),
                          MaxSize = maxSize
                      };
            q10.ToConsole("Q10");

            // 11
            var q11 = from attacker in doc.Descendants("attacker")
                      from commander in attacker.Descendants("commander")
                      group commander by commander.Value into grp
                      let attackCount = grp.Count()
                      where attackCount != 1
                      orderby attackCount descending, grp.Key
                      select new { AttackerCommanderName = grp.Key, Count = attackCount };
            q11.ToConsole("Q11");
        }
    }
}
