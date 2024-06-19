//SPM Assignment
using SPM_Assignment_Ngee_Ann_City;
using System;
using System.Drawing;

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
    newGrid.AddBuilding(building.type, rowLetter, col);
    newGrid.PrintGrid();
}

Grid grid = new Grid(20);
ImportSavedGameArcade(grid);
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
grid.PrintGrid();

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
    Console.WriteLine("[3] Load Saved Game");
    Console.WriteLine("[4] Display High Score");
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
}

void DisplayLeaderboard()
{
    Console.WriteLine("Leaderboard" + "\n");

    SortedDictionary<User, int> userDict = new SortedDictionary<User, int>();
    User user0 = new User("test12120", "password0", false, 0);
    User user1 = new User("test1", "password1", false, 20);
    User user2 = new User("test2", "password2", false, 90);
    User user3 = new User("test3", "password3", false, 100);
    User user4 = new User("test4", "password4", false, 50);
    User user5 = new User("test5", "password5", false, 60);
    User user6 = new User("test6", "password6", false, 70);
    User user7 = new User("test7", "password7", false, 75);
    User user8 = new User("test8", "password8", false, 10);
    User user9 = new User("test9", "password9", false, 30);



    userDict.Add(user0, user0.Points);
    userDict.Add(user1, user1.Points);
    userDict.Add(user2, user2.Points);
    userDict.Add(user3, user3.Points);
    userDict.Add(user4, user4.Points);
    userDict.Add(user5, user5.Points);
    userDict.Add(user6, user6.Points);
    userDict.Add(user7, user7.Points);
    userDict.Add(user8, user8.Points);
    userDict.Add(user9, user9.Points);

    Console.WriteLine("--------------------------------");
    Console.WriteLine("\tName" + "           Points");
    Console.WriteLine("--------------------------------");
    int count = 1;
    foreach (KeyValuePair<User, int> kvp in userDict)
    {
        Console.WriteLine(String.Format("{0}:\t{1,-15}{2}", count, kvp.Key.Name, kvp.Value));
        count++;
    }
    Console.WriteLine("--------------------------------");
}
//DisplayLeaderboard();

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

    Console.WriteLine("Choose a building to construct:");
    Console.WriteLine($"[1] {building1.type}");
    Console.WriteLine($"[2] {building2.type}");
    Console.Write("Enter the building option: ");
    int option = Convert.ToInt32(Console.ReadLine());

    Building selectedBuilding;
    if (option == 1)
    {
        selectedBuilding = building1;
    }
    else if (option == 2)
    {
        selectedBuilding = building2;
    }
    else
    {
        Console.WriteLine("Invalid input.");
        return;
    }
    newGrid.PrintGrid();
    Console.Write("Enter row coordinate: ");
    char rowLetter = char.ToUpper(Console.ReadLine()[0]);
    Console.Write("Enter column coordinate: ");
    int col = Convert.ToInt32(Console.ReadLine()) - 1;

    selectedBuilding.row = rowLetter;
    selectedBuilding.col = col;
    newGrid.AddBuilding(selectedBuilding.type, rowLetter, col);
    newGrid.PrintGrid();
}
void removeBuilding(Grid newgrid)
{
    Console.Write("Enter row: ");
    char row = Convert.ToChar(Console.ReadLine().ToUpper());
    Console.Write("Enter column: ");
    int col = Convert.ToInt32(Console.ReadLine()) - 1;
    newgrid.RemoveBuilding(row, col);
    newgrid.PrintGrid();
}


void Arcademode()
{
    Console.WriteLine("START ARCADE MODE\n");
    displayrulesArcade();
    int coins = 16;
    int points = 0;
    Grid AGrid = new Grid(20);
    while (coins > 0)
    {
        arcadeModeMenu();
        Console.Write("Enter option: ");
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                AddBuilding(AGrid);
                break;
            case 2:
                removeBuilding(AGrid);
                break;
            case 3:
                AGrid.ExportGridToCSV();
                break;
            default:
                Console.WriteLine("ERROR OPTION");
                break;
        }
        AGrid.GenerateCoins(); // Update coins from buildings
        points = AGrid.calculateAllPoints();
        //AGrid.PrintGrid();
        Console.WriteLine("POINTS: "+ points);
        Console.WriteLine("COINS: "+ AGrid.GetCoins());
    }
    
}
Arcademode();
