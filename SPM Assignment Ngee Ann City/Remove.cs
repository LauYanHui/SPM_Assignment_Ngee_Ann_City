public class BuildingManager
{
    private List<Building> buildings = new List<Building>();

    public void AddBuilding(Building building)
    {
        buildings.Add(building);
    }

    public void RemoveBuilding(Building building)
    {
        buildings.Remove(building);
    }

    public List<Building> GetBuildings()
    {
        return buildings;
    }
}
