using System;
using System.Collections.Generic;
using System.Text;

namespace KettedikPA
{
    class UI
    {
        FileManager fm = new FileManager();
        public UI()
        {

        }
        public void StartModule()
        {
            bool menu = true;
            while (menu)
            {
                Handle_menu();
                try
                {

                    menu = Choose();
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Error_message("Wrong format. Only numbers are accepted.",e.ToString()+ " \nBack to Main Menu.\n");
                    continue;
                }
            }
        }
        public void Handle_menu()
        {
            string[] options = new string[] { "List of Games", "View Own games",
                "Modify Game", "Finish Game", "Delete Own Game" };

            Print_menu("\tMain menu\n", options, "Exit program");
        }
        private bool Choose()
        {
            string option = Console.ReadLine();
            Console.Clear();
            int numberOut;
            bool success = Int32.TryParse(option, out numberOut);
            if (success)
            {
                if (numberOut == 1)
                {
                    bool listing = true;
                    while (listing)
                    {
                        string[] listOfPurchase = new string[] { "Purchase Game" };
                        Console.Clear();
                        Print_menu("\tList of Games\n", listOfPurchase, "Back To Menu");
                        int firstNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        NiceCLIWriter();
                        if (firstNumber == 1)
                        {
                            Console.Write("Input the title of the game: ");
                            string nameOfGame = Console.ReadLine();
                            Console.WriteLine();
                            bool suchGame = false;
                            Console.Clear();

                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._name.ToLower() == nameOfGame.ToLower() && fm._listOfGames[i]._owned != true)
                                {
                                    suchGame = true;
                                    fm._listOfGames[i]._owned = true;
                                    Console.WriteLine("SUCCesfully purchased " + fm._listOfGames[i]._name);
                                    System.Threading.Thread.Sleep(1200);
                                    Console.Clear();
                                }
                                else if (fm._listOfGames[i]._name.ToLower() == nameOfGame.ToLower() && fm._listOfGames[i]._owned == true)
                                {
                                    suchGame = true;
                                    Console.WriteLine("You might already have purchased this game.");
                                }
                            }
                            
                            if (suchGame != true)
                            {
                                Console.WriteLine("There's no game like " + nameOfGame);
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                            }
                            Console.WriteLine();
                            listing = true;
                        }
                        else if (firstNumber == 0)
                        {
                            Console.Clear();
                            listing = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There is no such option.\n");
                            continue;
                        }
                    }
                }
                else if (numberOut == 2)
                {
                    bool owning = true;
                    while (owning)
                    {
                        string[] listOfPurchase = new string[] { "List out Own Games", "Details of One Game" };
                        Print_menu("\tOwned Games\n", listOfPurchase, "Back To Menu");
                        int secondNumber = Convert.ToInt32(Console.ReadLine());
                        if (secondNumber == 1)
                        {

                            Console.Clear();
                            int owned = 0;
                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._owned == true)
                                {
                                    owned++;
                                }
                            }
                            if (owned != 0)
                            {

                                for (int i = 0; i < fm._listOfGames.Count; i++)
                                {
                                    if (fm._listOfGames[i]._owned == true)
                                    {
                                        Console.WriteLine($"{fm._listOfGames[i]._name}");
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You don't own any games yet."); 
                                System.Threading.Thread.Sleep(1200);
                                Console.Clear();
                            }
                            Console.WriteLine();
                        }
                        else if (secondNumber == 2)
                        {
                            bool ownAnyGames = false;
                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._owned == true)
                                {
                                    ownAnyGames = true;
                                }
                            }
                            if (ownAnyGames)
                            {
                                Console.Write("Choose a game: ");
                                string nameOfGame = Console.ReadLine();
                                Console.WriteLine();
                                bool suchGame = false;
                                Console.Clear();

                                for (int i = 0; i < fm._listOfGames.Count; i++)
                                {
                                    if (fm._listOfGames[i]._name.ToLower() == nameOfGame.ToLower() && fm._listOfGames[i]._owned == true)
                                    {
                                        suchGame = true;
                                        Console.WriteLine($"Name:{fm._listOfGames[i]._name}\nRelease year:{fm._listOfGames[i]._releaseYear}\n" +
                                            $"Price:{fm._listOfGames[i]._price}\nFinished:{fm._listOfGames[i]._finished}\n");
                                    }
                                }
                                if (suchGame != true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("There's no game like " + nameOfGame + ", or you don't own it yet. ");
                                    System.Threading.Thread.Sleep(3000);
                                    Console.Clear();

                                }
                                owning = true;
                            }
                            else if (!ownAnyGames)
                            {
                                Console.Clear();

                                Console.Write("You gotta purchase some games first!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();


                            }

                        }
                        else if (secondNumber == 0)
                        {
                            Console.Clear();
                            owning = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There is no such option.");
                            System.Threading.Thread.Sleep(2500);
                            Console.Clear();
                            continue;
                        }
                    }
                }
                else if (numberOut == 3)
                {

                    bool modifying = true;
                    while (modifying)
                    {
                        bool ownAnyGames = false;
                        for (int i = 0; i < fm._listOfGames.Count; i++)
                        {
                            if (fm._listOfGames[i]._owned == true)
                            {
                                ownAnyGames = true;
                            }
                        }
                        if (!ownAnyGames)
                        {
                            Console.WriteLine("You don't own any games to modify.");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            modifying = false;
                        }
                        else if (ownAnyGames)
                        {
                            Console.WriteLine("Choose a game you would like to modify:");
                            string nameOfOwnedGame = Console.ReadLine();
                            bool notAGame = true;
                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._name.ToLower() == nameOfOwnedGame.ToLower())
                                {
                                    notAGame = false;
                                }
                            }
                            if (!notAGame)
                            {


                                for (int i = 0; i < fm._listOfGames.Count; i++)
                                {
                                    if (fm._listOfGames[i]._name.ToLower() == nameOfOwnedGame.ToLower() && !fm._listOfGames[i]._owned)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You don't own this game so you can't modify it.");
                                        System.Threading.Thread.Sleep(2500);
                                        Console.Clear();
                                        modifying = false;
                                    }

                                    else
                                    {

                                        if (nameOfOwnedGame.ToLower() == fm._listOfGames[i]._name.ToLower())
                                        {
                                            Console.WriteLine("Attribute to change of this game? (Name / Release Year / Price / Owned / Finished)");
                                            string attr = Console.ReadLine();
                                            if (attr.ToLower() == "name")
                                            {
                                                Console.Write("The new name of the game: ");
                                                string newName = Console.ReadLine();
                                                Console.WriteLine($"{fm._listOfGames[i]._name}'s new name is {newName}.");
                                                fm._listOfGames[i]._name = newName;
                                                modifying = false;
                                            }
                                            else if (attr.ToLower() == "release year" || attr.ToLower() == "year")
                                            {
                                                Console.Write("The new release year of the game: ");
                                                string inputYear = Console.ReadLine();
                                                int newYear;
                                                bool parsableYear = Int32.TryParse(inputYear, out newYear);
                                                if (parsableYear)
                                                {
                                                    Console.WriteLine($"{fm._listOfGames[i]._name}'s release year is {newYear}.");
                                                    fm._listOfGames[i]._releaseYear = newYear;
                                                    modifying = false;

                                                }
                                                else
                                                {
                                                    Console.WriteLine("The input must be an integer.");
                                                    modifying = false;

                                                }
                                            }
                                            else if (attr.ToLower() == "price")
                                            {
                                                Console.Write("The new price of the game: ");
                                                string inputPrice = Console.ReadLine();
                                                int newPrice;
                                                bool parsablePrice = Int32.TryParse(inputPrice, out newPrice);
                                                if (parsablePrice)
                                                {
                                                    Console.WriteLine($"{fm._listOfGames[i]._name}'s price is {newPrice}.");
                                                    fm._listOfGames[i]._price = newPrice;
                                                    modifying = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The input must be an integer.");
                                                    modifying = false;

                                                }
                                            }
                                            else if (attr.ToLower() == "owned")
                                            {
                                                Console.Write("The new state of the game: ");
                                                string inputOwned = Console.ReadLine();
                                                bool newOwned;
                                                bool parsableOwned = Boolean.TryParse(inputOwned, out newOwned);
                                                if (parsableOwned)
                                                {
                                                    Console.WriteLine($"{fm._listOfGames[i]._name}'s price is {newOwned}.");
                                                    fm._listOfGames[i]._owned = newOwned;
                                                    modifying = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The input must be a boolean variable.");
                                                    modifying = false;

                                                }
                                            }
                                            else if (attr.ToLower() == "finished")
                                            {
                                                Console.Write("The new state of the game: ");
                                                string inputFinish = Console.ReadLine();
                                                bool newFinish;
                                                bool parsableFinish = Boolean.TryParse(inputFinish, out newFinish);
                                                if (parsableFinish)
                                                {
                                                    Console.WriteLine($"{fm._listOfGames[i]._name}'s price is {newFinish}.");
                                                    fm._listOfGames[i]._owned = newFinish;
                                                    modifying = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The input must be a boolean variable.");
                                                    modifying = false;

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("There is no such option like " + attr);
                                                modifying = false;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("There is no game like "+nameOfOwnedGame+".");
                                System.Threading.Thread.Sleep(2500);
                                Console.Clear();
                                modifying = false;

                            }
                        }
                    }
                }
                else if (numberOut == 4)
                {
                    bool finishing = true;
                    while (finishing)
                    {
                        bool ownAnyGames = false;
                        for (int i = 0; i < fm._listOfGames.Count; i++)
                        {
                            if (fm._listOfGames[i]._owned == true)
                            {
                                ownAnyGames = true;
                            }
                        }
                        if (!ownAnyGames)
                        {
                            Console.WriteLine("You don't own any games to modify it's finish statement.");
                            System.Threading.Thread.Sleep(3500);
                            Console.Clear();

                            finishing = false;
                        }
                        else
                        {
                            Console.Write("Input the title of the game you wish to mark as completed: ");
                            string inputTitle = Console.ReadLine();
                            bool foundTitle = false;
                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._name.ToLower() == inputTitle.ToLower() && fm._listOfGames[i]._finished == false && fm._listOfGames[i]._owned == true)
                                {
                                    foundTitle = true;
                                    fm._listOfGames[i]._finished = true;
                                    Console.WriteLine("You have successfully finished " + fm._listOfGames[i]._name);
                                    System.Threading.Thread.Sleep(1200);
                                    Console.Clear();
                                    finishing = false;
                                }
                            }


                            if (!foundTitle)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no such game you own called " + inputTitle + ".\n");
                                finishing = false;
                            }
                        }
                    }
                }
                else if (numberOut == 5)
                {
                    bool deleting = true;
                    while (deleting)
                    {
                        bool ownAnyGames = false;
                        for (int i = 0; i < fm._listOfGames.Count; i++)
                        {
                            if (fm._listOfGames[i]._owned == true)
                            {
                                ownAnyGames = true;
                            }
                        }
                        if (!ownAnyGames)
                        {
                            Console.WriteLine("You don't own any games to delete.");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            deleting = false;
                        }
                        else
                        {
                            Console.Write("Input the title of the game you wish to delete: ");
                            string inputTitle = Console.ReadLine();
                            bool foundTitle = false;
                            for (int i = 0; i < fm._listOfGames.Count; i++)
                            {
                                if (fm._listOfGames[i]._name.ToLower() == inputTitle.ToLower() && fm._listOfGames[i]._owned == true)
                                {
                                    foundTitle = true;
                                    fm._listOfGames[i]._owned=false;
                                    Console.WriteLine("You have successfully deleted " + fm._listOfGames[i]._name+".");
                                    System.Threading.Thread.Sleep(1200);
                                    Console.Clear();
                                    deleting = false;
                                }
                            }

                            if (!foundTitle)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no such game you own called " + inputTitle + ".\n");
                                deleting = false;
                            }
                        }
                    }
                }
                else if (numberOut == 0)
                {
                    Console.Write("Saving current state");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        System.Threading.Thread.Sleep(700);

                    }
                    fm.Save();
                    Console.WriteLine("\n\nSuccessfully saved.");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    return false;
                }

                else
                {
                    Console.WriteLine("There is no such option.\n");
                }
            }
            else
            {
                Console.WriteLine();
                
            }
            return true;
        }
        
        
        public void Print_menu(string title, string[] list_options, string exit_message)
        {
            Console.WriteLine(title);
            for (int i = 0; i < list_options.Length; i++)
            {
                Console.WriteLine($"({(i + 1)}) {list_options[i]}");
            }
            Console.WriteLine("(0) " + exit_message);
        }
        public void Error_message(string m,string e)
        {
            Console.WriteLine($"{m}.$ {e}");
        }
        public void NiceCLIWriter()
        {
            int lengthOfName = 0;
            int lengthOfPrice = 0;
            int lengthOfRYear = "Release Year".Length;
            int lengthOfOwned = "Owned".Length;
            int lengthOfFin = "Finished".Length;

            int j = 0;
            while (j != fm._listOfGames.Count) 
            {

                if (fm._listOfGames[j]._name.Length > lengthOfName)
                { 
                    lengthOfName = fm._listOfGames[j]._name.Length; 
                }
                else if (fm._listOfGames[j]._price.ToString().Length > lengthOfPrice)
                {
                    lengthOfPrice = fm._listOfGames[j]._price.ToString().Length;
                }
                else if (fm._listOfGames[j]._releaseYear.ToString().Length > lengthOfRYear)
                {
                    lengthOfRYear = fm._listOfGames[j]._releaseYear.ToString().Length;
                }
                else if (fm._listOfGames[j]._owned.ToString().Length > lengthOfOwned)
                {
                    lengthOfOwned = fm._listOfGames[j]._owned.ToString().Length;
                }
                else if (fm._listOfGames[j]._finished.ToString().Length > lengthOfFin)
                {
                    lengthOfFin = fm._listOfGames[j]._finished.ToString().Length;
                }

                j++;
            }
            Console.WriteLine($"|{{0,{lengthOfName + 1}}}|" +
                $"{{1,{lengthOfRYear+1}}}|{{2,{lengthOfPrice+1}}}|" +
                $"{{3,{lengthOfOwned+1}}}",
                "Title","Release Year","Price","Owned");
            foreach (Game game in fm._listOfGames)
            {
                Console.WriteLine($"|{{0,{lengthOfName + 1}}}|" +
                    $"{{1,{lengthOfRYear+1}}}|{{2,{lengthOfPrice+1}}}|" +
                    $"{{3,{lengthOfOwned+1}}}",
                    game._name,game._releaseYear,game._price,game._owned.ToString()); 
            }
            Console.WriteLine();
        }
    }
}
