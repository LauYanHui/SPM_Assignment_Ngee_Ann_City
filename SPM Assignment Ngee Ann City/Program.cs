﻿//SPM Assignment
using Microsoft.VisualBasic.FileIO;
using SPM_Assignment_Ngee_Ann_City;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

//grid creation
Grid createGrid()
{
    Console.Write("Enter grid size: ");
    int size = Convert.ToInt32(Console.ReadLine());
    Grid newGrid = new Grid(size);
    newGrid.PrintGrid();
    return newGrid;
}

/* Loop to add building
for (int i = 0; i < 1; i++)
{
    Console.Write("Enter type of building: ");
    char buildingType = char.Parse(Console.ReadLine());
    Console.Write("Enter row coordinate: ");
    char rowLetter = char.ToUpper(Console.ReadLine()[0]); // Adjust to 0-based indexing
    Console.Write("Enter column coordinate: ");
    int col = int.Parse(Console.ReadLine()) - 1; // Adjust to 0-based indexing

    newGrid.AddBuilding(buildingType, rowLetter, col);
    
    newGrid.PrintGrid();
}
*/
// introduce classes to the grid
void addBuilding(Grid newGrid)
{
    displayBuildingTypes();
    Console.Write("Enter the building type: ");
    int option = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter row coordinate: ");
    char rowLetter = char.ToUpper(Console.ReadLine()[0]); // Adjust to 0-based indexing
    Console.Write("Enter column coordinate: ");
    int col = int.Parse(Console.ReadLine()) - 1; // Adjust to 0-based indexing
    Building building = null;
    switch (option)
    {
        case 1:
            building = new Residential(rowLetter, col, newGrid);
            break;
        case 2:
            building = new Industry(rowLetter, col, newGrid);
            break;
        case 3:
            building = new Commercial(rowLetter, col, newGrid);
            break;
        case 4:
            building = new Park(rowLetter, col, newGrid);
            break;
        case 5:
            building = new Road(rowLetter, col, newGrid);
            break;
        default:
            Console.WriteLine("Invalid input.");
            return;
    }
    newGrid.AddBuilding(building.type, rowLetter, col,false);
    newGrid.PrintGrid();
}
void ImportSavedGameArcade(Grid grid)
{
    char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
    List<string> game_temp = new List<string>();
    List<List<String>> game_dataFinal = new List<List<String>>();
    using (StreamReader sr = new StreamReader("saved_game_data_arcade.csv"))
    {
        string? s = sr.ReadLine();
        if (s != null)
        {
            //Console.WriteLine(s);
            game_temp.Add(s);
        }
        while ((s = sr.ReadLine()) != null)
        {
            //Console.WriteLine(s);
            game_temp.Add(s);
        }
    }

    foreach (string s in game_temp)
    {
        List<string> game_data = new List<string>();
        string[] temp = new string[] { };
        temp = s.Split(",");
        int count = 0;
        foreach (string s1 in temp)
        {
            game_data.Add(s1);
            //Console.WriteLine(s1);
        }
        game_dataFinal.Add(game_data);
    }
    //Console.WriteLine(game_dataFinal[19].Count);

    for (int i = 0; i < game_dataFinal.Count; i++)
    {
        for (int j = 0; j < game_dataFinal[i].Count; j++)
        {
            string data = game_dataFinal[i][j];
            //Console.WriteLine(game_dataFinal[i][j]);
            if (data != " ")
            {
                char[] dataChar = data.ToCharArray();
                grid.AddBuilding(dataChar[0], letters[j], i,false);
                Console.WriteLine(String.Format("{0}    {1}    {2}", data, i.ToString(), j.ToString()));
            }
        }
    }


}



Grid grid = new Grid(20);
//ImportSavedGameArcade(grid);
//Grid grid = createGrid();
//addBuilding(newGrid);
/*
grid.AddBuilding('R', 'A', 0);
grid.AddBuilding('I', 'B', 1);
grid.AddBuilding('R', 'C', 2);
grid.AddBuilding('I', 'D', 3);
grid.AddBuilding('R', 'E', 4);
grid.AddBuilding('C', 'A', 1);
grid.AddBuilding('C', 'A', 2);
grid.AddBuilding('C', 'A', 3);
grid.AddBuilding('O', 'B', 0);
grid.AddBuilding('O', 'B', 2);
grid.AddBuilding('O', 'B', 3);
grid.AddBuilding('*', 'A', 4);
grid.AddBuilding('*', 'A', 5);
grid.AddBuilding('*', 'A', 6);
grid.AddBuilding('*', 'A', 7);*/
//grid.calculateAllPoints();
//grid.PrintGrid();

//newGrid.ExportGridToCSV();
/* To remove Building
Console.Write("Enter row coordinate: ");
char DrowLetter = char.ToUpper(Console.ReadLine()[0]); // Adjust to 0-based indexing
Console.Write("Enter column coordinate: ");
int Dcol = int.Parse(Console.ReadLine()) - 1; // Adjust to 0-based indexing
newGrid.RemoveBuilding(DrowLetter,Dcol);
newGrid.PrintGrid();
*/
void displayMenu()// display menu
{
    Console.WriteLine("[1] Start New Arcade Mode");
    Console.WriteLine("[2] Start New Free Play Mode");
    Console.WriteLine("[3] Load Saved Arcade Game");
    Console.WriteLine("[4] Load Saved Free Play Game");
    Console.WriteLine("[5] Display High Score");
    Console.WriteLine("[0] Exit Game");
}

void displayintro()
{
    Console.WriteLine("Ngee Ann city building game is a city-building game.");
    Console.WriteLine("You are the mayor of Ngee Ann City and the goal of the game is to build the happiest and most prosperous city possible");
    Console.WriteLine("There are 2 game modes, one Arcade mode with limited number of coins and grid, while the other is\r\nFree Play mode with unlimited number of coins and grid");
}


void displayrulesArcade()
{
    Console.WriteLine("Rules for Arcade mode\n");
    Console.WriteLine("In Arcade mode, this city-building game begins with 16 coins. In each turn, the player will construct\r\none of two randomly selected buildings in the 20x20 city. Each construction cost 1 coin. For the first\r\nbuilding, the player can build anywhere in the city. For subsequent constructions, the player can only\r\nbuild on squares that are connected to existing buildings. The other building that was not built is\r\ndiscarded.\n");
    Console.WriteLine("Each building scores in a different way. The objective of the game is to build a city that scores as\r\nmany points as possible.\n");
    Console.WriteLine("There are 5 types of buildings:\r\n• Residential (R): If it is next to an industry (I), then it scores 1 point only. Otherwise, it scores 1\r\npoint for each adjacent residential (R) or commercial (C), and 2 points for each adjacent park (O).\r\n• Industry (I): Scores 1 point per industry in the city. Each industry generates 1 coin per residential\r\nbuilding adjacent to it.\r\n• Commercial (C): Scores 1 point per commercial adjacent to it. Each commercial generates 1 coin\r\nper residential adjacent to it.\r\n• Park (O): Scores 1 point per park adjacent to it.\r\n• Road (*): Scores 1 point per connected road (*) in the same row.\n");

}
//displayrulesArcade();
void displayrulesFreeplay()
{
    Console.WriteLine("Rules for Free Play Mode\n");
    Console.WriteLine("In Free Play mode, this city-building game has unlimited number of coins and begins with a grid of\r\n5x5. In each turn, the player can construct any of the buildings in the city, on any cell in the city. Each\r\nconstruction cost 1 coin. Once a building is constructed along the border of the city, additional 5 more\r\nrows of cells are added to the perimeter of the city, i.e. the city will expand to 15x15 on the first time,\r\nand 25x25 on the second expansion\n");
    Console.WriteLine("A building is adjacent to another building if they are connected via the same road. The scoring of the\r\nbuilding is the same as that in Arcade mode.\n");
    Console.WriteLine("Profit and upkeep cost of the 5 types of buildings:\r\n• Residential (R): Each residential building generates 1 coin per turn. Each cluster of residential\r\nbuildings (must be immediately next to each other) requires 1 coin per turn to upkeep.\r\n• Industry (I): Each industry generates 2 coins per turn and cost 1 coin per turn to upkeep.\r\n• Commercial (C): Each commercial generates 3 coins per turn and cost 2 coins per turn to upkeep.\r\n• Park (O): Each park costs 1 coin to upkeep.\r\n• Road (*): Each unconnected road segment costs 1 coin to upkeep.\n");
}
//displayrulesFreeplay();

void displayBuildingTypes()
{
    Console.WriteLine("[1] Residential building");
    Console.WriteLine("[2] Industrial building");
    Console.WriteLine("[3] Commercial building");
    Console.WriteLine("[4] Park");
    Console.WriteLine("[5] Road");
}
void arcadeModeMenu()
{
    Console.WriteLine("[1] Add Building. ");
    Console.WriteLine("[2] Remove Building. ");
    Console.WriteLine("[0] Save and leave game.");
}
void AddToLeaderboardCSV(List<User> user_array)
{
    using (StreamWriter sw = new StreamWriter("leaderboard.csv", false))
    {
        foreach(User user in user_array)
        {
            sw.WriteLine(user.Name + ',' + user.Points);
        }
    }
}
List<User> ReadLeaderboardCSV()
{
    List<User> user_list =new List<User>();
    using (StreamReader sr = new StreamReader("leaderboard.csv"))
    {
        string? s;
        while((s = sr.ReadLine())!= null)
        {
            string[] data = s.Split(",");
            user_list.Add(new User(data[0], Convert.ToInt32(data[1])));

        }
    }
        return user_list;
}
void DisplayLeaderboard(List<User> user_list)
{
    Console.WriteLine();
    Console.WriteLine("Leaderboard" );

    Console.WriteLine("--------------------------------");
    Console.WriteLine("\tName" + "           Points");
    Console.WriteLine("--------------------------------");
    int count = 1;
    foreach (User user in user_list)
    {
        Console.WriteLine(String.Format("{0}:\t{1,-15}{2}", count, user.Name, user.Points));
        count++;
    }
    Console.WriteLine("--------------------------------");
    Console.WriteLine();
}

Building GetRandomBuilding()
{
    Random random = new Random();
    int buildingType = random.Next(1, 6); // Generates a number between 1 and 5
    switch (buildingType)
    {
        case 1:
            return new Residential(' ', -1, null); // Placeholder values for now
        case 2:
            return new Industry(' ', -1, null);
        case 3:
            return new Commercial(' ', -1, null);
        case 4:
            return new Park(' ', -1, null);
        case 5:
            return new Road(' ', -1, null);
        default:
            throw new Exception("Invalid building type generated.");
    }
}


void AddBuilding(Grid newGrid)
{
    Building building1 = GetRandomBuilding();
    Building building2 = GetRandomBuilding();
    bool buildingAdded = false;

    while (!buildingAdded)
    {
        Console.WriteLine("Choose a building to construct:");
        Console.WriteLine($"[1] {building1.type}");
        Console.WriteLine($"[2] {building2.type}");
        Console.Write("Enter the building option: ");
        if (!int.TryParse(Console.ReadLine(), out int option) || (option != 1 && option != 2))
        {
            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            continue;
        }

        Building selectedBuilding = (option == 1) ? building1 : building2;

        newGrid.PrintGrid();

        char rowLetter;
        while (true)
        {
            Console.Write("Enter row coordinate (A-T): ");
            if (!char.TryParse(Console.ReadLine()?.ToUpper(), out rowLetter) || rowLetter < 'A' || rowLetter > 'T')
            {
                Console.WriteLine("Invalid input. Please enter a letter from A to T.");
            }
            else
            {
                break;
            }
        }

        int col = -1;
        while (col < 0 || col >= newGrid.Number)
        {
            Console.Write("Enter column coordinate (1-20): ");
            if (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > 20)
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
                col = -1; // Reset col to force re-entry in the next iteration
            }
            else
            {
                col--; // Convert 1-based index to 0-based index
            }
        }

        selectedBuilding.row = rowLetter;
        selectedBuilding.col = col;

        buildingAdded = newGrid.AddBuilding(selectedBuilding.type, rowLetter, col, false);
        if (!buildingAdded)
        {
            Console.WriteLine("Failed to add building. Please try again.");
        }
    }
    newGrid.PrintGrid();
}


void removeBuilding(Grid newgrid)
{
    List<Building> Blist = newgrid.getlist();
    if (Blist.Count == 0)
    {
        Console.WriteLine("There are no buildings.");
        return;
    }

    char row;
    int col;

    while (true)
    {
        Console.Write("Enter row (A to T): ");
        string inputRow = Console.ReadLine()?.ToUpper();

        // Validate row input
        if (inputRow == null || inputRow.Length != 1 || inputRow[0] < 'A' || inputRow[0] > 'T')
        {
            Console.WriteLine("Invalid input. Please enter a letter from A to T.");
            continue;
        }

        row = inputRow[0];
        break;
    }

    while (true)
    {
        Console.Write("Enter column (1 to 20): ");
        string inputCol = Console.ReadLine();

        // Validate column input
        if (!int.TryParse(inputCol, out col) || col < 1 || col > 20)
        {
            Console.WriteLine("Invalid input. Please enter a number from 1 to 20.");
            continue;
        }

        col--; // Adjust column to zero-based index
        break;
    }

    newgrid.RemoveBuilding(row, col);
    newgrid.PrintGrid();
}


void Arcademode(bool import)
{
    Console.WriteLine("START ARCADE MODE\n");
    displayrulesArcade();
    Grid AGrid;
    if (import == true)
    {
        AGrid = new Grid(20);
        AGrid.ImportSavedGameArcade(AGrid);
        AGrid.PrintGrid();
    }
    else
    {
        AGrid = new Grid(20);
    }

    int coins = 16;
    int points = 0;
    bool requestExit = false;
    while (coins > 0 && !requestExit)
    {
        arcadeModeMenu();
        while (true)
        {
            int option;
            try
            {
                Console.Write("Enter option: ");
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid option. Please try again");
                continue;
            }
            switch (option)
            {
                case 1:
                    AddBuilding(AGrid);
                    break;
                case 2:
                    removeBuilding(AGrid);
                    break;
                case 0:
                    AGrid.ExportGridToCSV();
                    requestExit = true;
                    break;
                default:
                    Console.WriteLine("ERROR OPTION");
                    break;
            }
            break;
        }
        if (!requestExit)
        {
            //AGrid.GenerateCoins(); // Update coins from buildings
            points = AGrid.calculateAllPoints();
            //AGrid.PrintGrid();
            Console.WriteLine("POINTS: " + points);
            coins = AGrid.GetCoins();
            //int totalcoins = coins + AGrid.GetCoins();
            Console.WriteLine("COINS: " + AGrid.GetCoins());
        }
    }
    if (requestExit)
    {
        Console.WriteLine("GAME SAVED AND EXITED");
        return;
    }
    else
    {
        Console.WriteLine("GAME ENDED");
        Console.WriteLine("Points: " + points);
        if (AGrid.GetCoins() <= 0 || AGrid.Buildings.Count >= 400)
        {
            List<User> user_list = ReadLeaderboardCSV();
            user_list.Sort();
            if (user_list.Count < 10)
            {
                Console.WriteLine("You have made it to the top 10.");
                string name;
                while (true)
                {
                    Console.Write("Please enter your name to enter: ");
                    name = Console.ReadLine();
                    if (!(string.IsNullOrEmpty(name)))
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a name" + "\n");
                }
                User new_user = new User(name, points);
                user_list.Add(new_user);
                user_list.Sort();
                AddToLeaderboardCSV(user_list);
            }
            else // user_list.count >= 11
            {
                if (user_list[9].Points < points)
                {
                    Console.WriteLine("You have made it to the top 10.");
                    string name;
                    while(true)
                    {
                        Console.Write("Please enter your name to enter: ");
                        name = Console.ReadLine();
                        if (!(string.IsNullOrEmpty(name)))
                        {
                            break;
                        }
                        Console.WriteLine("Please enter a name" + "\n");
                    }
                    
                    User new_user = new User(name, points);
                    user_list.Add(new_user);
                    user_list.Sort();
                    user_list.RemoveAt(10);
                    AddToLeaderboardCSV(user_list);
                }
            }

        }
    }

}
void game()
{
    bool exit = false;
    while (!exit)
    {
        displayMenu();
        int option; ;
        Console.Write("Enter a option: ");
        try
        {
            option = Convert.ToInt32(Console.ReadLine());
            
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid option. Please try again");
            Console.WriteLine();
            continue;
        }
        switch (option)
        {
            case 1:
                Arcademode(false);
                break;
            case 3:
                Arcademode(true);
                break;
            case 5:
                List<User> user_list = ReadLeaderboardCSV();
                DisplayLeaderboard(user_list);
                break;
            case 0:
                exit = true;
                break;
            default:
                Console.WriteLine("ERROR OPTION");
                break;
        }
    }
}
game();

