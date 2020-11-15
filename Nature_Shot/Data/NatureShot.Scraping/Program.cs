using System;
using System.Threading.Tasks;
using AngleSharp;
using System.Linq;
using System.Text.RegularExpressions;
using NatureShot.Data;
using System.Collections.Generic;
using NatureShot.Data.Models;

namespace NatureShot.Scraping
{
    public class Program
    {
        public static async Task Main()
        {
            var db = new ApplicationDbContext();

            //var allTownInBulgaria = new List<string>();
            //await GetTowns(allTownInBulgaria);

            //var allMountainsWithPeaksInBulgaria = new List<string>();
            //await GetMountains(allMountainsWithPeaksInBulgaria);

            //var allRiversInBulgaria = new List<string>();
            //await GetRivers(allRiversInBulgaria);

            //var allCavesInBulgaria = new List<string>();
            //GetCaves(allCavesInBulgaria);

            //var allLakesInBulgaria = new List<string>();
            //GetLakes(allLakesInBulgaria);

            var country = new Country
            {
                Name = "Bulgaria",

            };
            db.Countries.Add(country);
            db.SaveChanges();

        }

        public static void GetLakes(List<string> allLakesInBulgaria)
        {
            allLakesInBulgaria.Add("Lake Atanasovsko");
            allLakesInBulgaria.Add("Lake Beloslav");
            allLakesInBulgaria.Add("Lake Burgas");
            allLakesInBulgaria.Add("Lake Durankulak");
            allLakesInBulgaria.Add("Lake Pomorie");
            allLakesInBulgaria.Add("Lake Shabla");
            allLakesInBulgaria.Add("Lake Varna");
            allLakesInBulgaria.Add("Aldomirovtsi Marsh");
            allLakesInBulgaria.Add("Alepu");
            allLakesInBulgaria.Add("Arkutino");
            allLakesInBulgaria.Add("Dragoman Marsh");
            allLakesInBulgaria.Add("Lake Rabisha");
            allLakesInBulgaria.Add("Smolyan lakes");
            allLakesInBulgaria.Add("Srebarna");
            allLakesInBulgaria.Add("Ustren lake");
            allLakesInBulgaria.Add("Banderishki Lakes");
            allLakesInBulgaria.Add("Bashliiski Lakes");
            allLakesInBulgaria.Add("Breznishki Lakes");
            allLakesInBulgaria.Add("Chairski Lakes");
            allLakesInBulgaria.Add("Dautovo Lake");
            allLakesInBulgaria.Add("Kremenski Lakes");
            allLakesInBulgaria.Add("Malokamenishki Lakes");
            allLakesInBulgaria.Add("Popovo Lake");
            allLakesInBulgaria.Add("Prevalski Lakes");
            allLakesInBulgaria.Add("Samodivski Lakes");
            allLakesInBulgaria.Add("Tipitski Lakes");
            allLakesInBulgaria.Add("Valyavishki Lakes");
            allLakesInBulgaria.Add("Vasilashki Lakes");
            allLakesInBulgaria.Add("Vlahini Lakes");
            allLakesInBulgaria.Add("Lake of Purity");
            allLakesInBulgaria.Add("Marichini Lakes");
            allLakesInBulgaria.Add("The Eye/Rila");
            allLakesInBulgaria.Add("The Fish Lake/Rila");
            allLakesInBulgaria.Add("The Kidney/Rila");
            allLakesInBulgaria.Add("The Lower Lake/Rila");
            allLakesInBulgaria.Add("The Tear/Rila");
            allLakesInBulgaria.Add("The Trefoil/Rila");
            allLakesInBulgaria.Add("The Twin/Rila");
            allLakesInBulgaria.Add("Urdini Lakes");
            allLakesInBulgaria.Add("Vapski Lakes");

        }

        public static void GetCaves(List<string> allCavesInBulgaria)
        {
            allCavesInBulgaria.Add("Bacho Kiro");
            allCavesInBulgaria.Add("Devetashka");
            allCavesInBulgaria.Add(@"Devil's Throat");
            allCavesInBulgaria.Add("Duhlata");
            allCavesInBulgaria.Add("Kolkina Dupka");
            allCavesInBulgaria.Add("Kozarnika");
            allCavesInBulgaria.Add("Ledenika");
            allCavesInBulgaria.Add("Magura");
            allCavesInBulgaria.Add("Orlova Chuka");
            allCavesInBulgaria.Add("Prohodna");
            allCavesInBulgaria.Add("Raychova Dupka");
            allCavesInBulgaria.Add("Razhishka");
            allCavesInBulgaria.Add("Saeva dupka");
            allCavesInBulgaria.Add("Snezhanka");
            allCavesInBulgaria.Add("Temnata Dupka");
            allCavesInBulgaria.Add("Uhlovitsa");
            allCavesInBulgaria.Add("Venetsa");
            allCavesInBulgaria.Add("Yagodinska");
        }
        public static async Task GetTowns(List<string> allTownInBulgaria)
        {
            var url = new Url("https://en.wikipedia.org/wiki/List_of_cities_and_towns_in_Bulgaria");
            var config = Configuration.Default.WithDefaultLoader();
            var doc = await BrowsingContext.New(config).OpenAsync(url);

            var mainTowns = doc.QuerySelectorAll("td > b > a");
            var secondaryTowns = doc.QuerySelectorAll("td > a");
            //Do something with document like the following
            foreach (var element in mainTowns)
            {
                if (IsCorrect(element.TextContent))
                {
                    allTownInBulgaria.Add(element.TextContent);
                }
            }

            foreach (var element in secondaryTowns)
            {
                if (!element.TextContent.Contains("Province") && Regex.Match(element.TextContent, "[A-z]").Success)
                {
                    if (IsCorrect(element.TextContent))
                    {
                        allTownInBulgaria.Add(element.TextContent);
                    }
                }
            }

            url = new Url("https://en.wikipedia.org/wiki/List_of_villages_in_Bulgaria");
            doc = await BrowsingContext.New(config).OpenAsync(url);

            var listOfProvinces = doc.QuerySelector(".mw-parser-output ul").QuerySelectorAll("li > a");
            var urls = new List<string>();
            foreach (var element in listOfProvinces)
            {
                urls.Add("https://en.wikipedia.org" + element.GetAttribute("href"));
            }

            foreach (var address in urls)
            {
                url = new Url(address);
                doc = await BrowsingContext.New(config).OpenAsync(url);

                if (address == "https://en.wikipedia.org/wiki/List_of_villages_in_Sliven_Province")
                {
                    var villages = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("table > tbody > tr > td > ul > li > a");
                    var secondVillageList = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("ul > li > a");
                    foreach (var village in villages)
                    {
                        if (IsCorrect(village.TextContent))
                        {
                            allTownInBulgaria.Add(village.TextContent);
                        }
                    }

                    foreach (var village in secondVillageList)
                    {
                        if (IsCorrect(village.TextContent))
                        {
                            allTownInBulgaria.Add(village.TextContent);
                        }
                    }
                }
                else
                {
                    var villages = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("div > ul > li > a");
                    foreach (var village in villages)
                    {
                        if (IsCorrect(village.TextContent))
                        {
                            allTownInBulgaria.Add(village.TextContent);
                        }
                    }
                }
            }

            foreach (var element in allTownInBulgaria)
            {
                Console.WriteLine(element);
            }
        }

        public static async Task GetMountains(List<string> allMountainsInBulgaria)
        {
            var url = new Url("https://en.wikipedia.org/wiki/List_of_mountains_in_Bulgaria");
            var config = Configuration.Default.WithDefaultLoader();
            var doc = await BrowsingContext.New(config).OpenAsync(url);

            var mountains = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("table > tbody > tr > td > ul > li > a");
            var mountainsSecond = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("table > tbody > tr > td > ul > li > a");

            foreach (var mountain in mountains)
            {
                allMountainsInBulgaria.Add(mountain.TextContent);
            }

            foreach (var mountain in mountainsSecond)
            {
                allMountainsInBulgaria.Add(mountain.TextContent);
            }
        }

        public static async Task GetRivers(List<string> allRiversInBulgaria)
        {
            var url = new Url("https://en.wikipedia.org/wiki/List_of_rivers_of_Bulgaria");
            var config = Configuration.Default.WithDefaultLoader();
            var doc = await BrowsingContext.New(config).OpenAsync(url);

            var rivers = doc.QuerySelector(".mw-parser-output").QuerySelectorAll("ul > li > a");
            foreach (var river in rivers)
            {
                Console.WriteLine(river.TextContent);
                allRiversInBulgaria.Add(river.TextContent);
            }
        }

        public static bool IsCorrect(string input)
        {
            var forbidden = new List<string>
            {
                "List of villages in Bulgaria",
                "5 See also",
                "4 Tvarditsa Municipality",
                "3 Sliven Municipality",
                "2 Nova Zagora Municipality",
                "1 Kotel Municipality"
            };

            if (forbidden.Contains(input))
            {
                return false;
            }

            return Regex.Match(input, "[A-z, ()]+").Success;
        }
    }
}
