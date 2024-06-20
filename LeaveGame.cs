using System;

public void LeaveGame()
{
    Console.WriteLine("Are you sure you want to leave the game? (y/n)");
    string input = Console.ReadLine();

    if (input.ToLower() == "y")
    {
        Console.WriteLine("Goodbye! Thanks for playing.");
        Environment.Exit(0); // Exits the game
    }
    else
    {
        Console.WriteLine("Cancelled. You can continue playing.");
    }
}

public void DisplayMainMenu()
{
    Console.WriteLine("Main Menu:");
    Console.WriteLine("1. Start New Game");
    Console.WriteLine("2. Load Saved Game");
    Console.WriteLine("3. Display High Scores");
    Console.WriteLine("4. Leave Game");
    Console.WriteLine("Enter your choice (1-4):");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            StartNewGame();
            break;
        case "2":
            LoadSavedGame();
            break;
        case "3":
            DisplayHighScores();
            break;
        case "4":
            LeaveGame();
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            DisplayMainMenu();
            break;
    }
}