public class Commercial
{
    public char Type { get; set; } // Commercial type
    public int Score { get; set; } // Initial score
    public int UpkeepCost { get; set; } // Upkeep cost per turn
    public int Profit { get; set; } // Coins generated per turn
    public int AdjacentCommercial { get; set; } // Number of adjacent commercial buildings
    public int AdjacentResidential { get; set; } // Number of adjacent residential buildings

    public Commercial()
    {
        Type = 'C'; // Initialize type
        Score = 0; // Initialize score
        UpkeepCost = 2; // Initialize upkeep cost
        Profit = 3; // Initialize profit
        AdjacentCommercial = 0; // Initialize adjacent commercial count
        AdjacentResidential = 0; // Initialize adjacent residential count
    }

    public int CalculateScore(List<Building> adjacentBuildings)
    {
        // Calculate score based on adjacent commercial and residential buildings
        Score = AdjacentCommercial + AdjacentResidential;
        return Score;
    }

    public int GenerateCoins()
    {
        // Generate coins based on adjacent residential buildings
        return AdjacentResidential * Profit;
    }
}