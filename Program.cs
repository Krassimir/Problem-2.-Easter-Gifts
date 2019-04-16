using System;
using System.Collections.Generic;
using System.Linq;

namespace P02EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfGifts = new List<string>();
            listOfGifts = Console.ReadLine().Split().ToList();
            string commands;

            while ((commands = Console.ReadLine()) != "No Money")
            {
                if (commands == "No Money")
                {
                    break;
                }

                List<string> commandLine = commands.Split().ToList();
                if (commandLine.Contains("OutOfStock"))
                {
                    string gift = commandLine[1];                   
                    while (listOfGifts.Contains(gift))
                    {
                        int index = listOfGifts.FindIndex(x => x.Contains(gift));
                        listOfGifts[index] = listOfGifts[index].Replace(gift, "None");                       
                        if (index==-1)
                        {
                            break;
                        }
                    }                   
                }
                if (commandLine.Contains("Required")) 
                {
                    string newGift = commandLine[1];
                    int commandIndex = int.Parse(commandLine[2]);
                    
                    if ((listOfGifts.Count-1)>= commandIndex)
                    {
                        string oldgift = listOfGifts[commandIndex];
                        Console.WriteLine($"oldgift ->{oldgift}");
                        listOfGifts[commandIndex] = listOfGifts[commandIndex].Replace(oldgift, newGift);                        
                    }                    
                }
                if (commandLine.Contains("JustInCase"))
                {
                    string newGift = commandLine[1];
                    int index = listOfGifts.Count - 1;
                    string oldgift = listOfGifts[index];
                    listOfGifts[index] = listOfGifts[index].Replace(oldgift, newGift);                   
                }
            }
                        
            Console.WriteLine(string.Join(" ", listOfGifts.Where(x=>(!x.Equals("None")))));
        }

    }
}
