public class Industry
{
    public char Type { get; set; } // Industry type
    public int Score { get; set; } // Initial score
    public int UpkeepCost { get; set; } // Upkeep cost per turn
    public int Profit { get; set; } // Coins generated per turn
    public int AdjacentResidential { get; set; } // Number of adjacent residential buildings

    public Industry()
    {
        Type = 'I'; // Initialize type
        Score = 0; // Initialize score
        UpkeepCost = 1; // Initialize upkeep cost
        Profit = 2; // Initialize profit
        AdjacentResidential = 0; // Initialize adjacent residential count
    }

    public int CalculateScore(List<Building> adjacentBuildings)
    {
        // Calculate score based on adjacent industries and residential buildings
        Score = adjacentBuildings.Count + AdjacentResidential;
        return Score;
    }

    public int GenerateCoins()
    {
        // Generate coins based on adjacent residential buildings
        return AdjacentResidential * Profit;
    }
}