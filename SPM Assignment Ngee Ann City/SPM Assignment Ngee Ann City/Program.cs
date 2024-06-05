//SPM Assignment
char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
void displayMenu()// display menu
{
    Console.WriteLine("[1] Start New Arcade Mode");
    Console.WriteLine("[2] Start New Free Play Mode");
    Console.WriteLine("[3] Load Saved Game");
    Console.WriteLine("[4] Display High Score");
    Console.WriteLine("[0] Exit Game");
}


char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
Console.Write(" ");
Console.WriteLine("    " + string.Join("   ", letters)); // Print the letters with spaces and dashes
Console.Write(" ");
Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1)+ "+"); 

for (int i = 0; i < 20; i++)
{
    Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
    for (int j = 0; j < 20; j++)
    {
        Console.Write("   |"); // Print the spaces and vertical bars

    }
    Console.WriteLine();
    Console.Write(" ");
    Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1) + "+");
}
Console.WriteLine("///////////////////////////////////////////////////////////////////");
// Initialize a 2D list of characters
List<List<char>> grid = new List<List<char>>();
for (int i = 0; i < 20; i++)
{
    grid.Add(new List<char>(new char[20])); // Initialize each row with empty characters
}
Console.Write("Enter a coordinate: ");
string userInput = Console.ReadLine();
input(userInput);
void input(string input)
{
    string userInput = input;
    char rowLetter = userInput[0];
    int columnIndex = int.Parse(userInput.Substring(1)) - 1;

    
    int rowIndex = rowLetter - 'A';

    
    char desiredLetter = 'X';
    grid[rowIndex][columnIndex] = desiredLetter;

    
    Console.Write(" ");
    Console.WriteLine("    " + string.Join("   ", letters));
    Console.Write(" ");
    Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1) + "+");

    for (int i = 0; i < 20; i++)
    {
        Console.Write($"{i + 1,2} |");
        for (int j = 0; j < 20; j++)
        {
            char cellValue = grid[j][i];
            string formattedValue = cellValue == '\0' ? "   " : $" {cellValue} ";
            Console.Write(formattedValue + "|");
        }
        Console.WriteLine();
        Console.Write(" ");
        Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1) + "+");
    }
}


