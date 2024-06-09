using System;

public abstract class Building
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract int Score();
}

public class House : Building
{
    public override int Score()
    {
        return 0; // replace with actual logic
    }
}

public class Factory : Building
{
    public override int Score()
    {
        return 0; // replace with actual logic
    }
}

public class Store : Building
{
    public override int Score()
    {
        return 0; // replace with actual logic
    }
}

public class Park : Building
{
    public override int Score()
    {
        return 0; // replace with actual logic
    }
}

public class Road : Building
{
    public override int Score()
    {
        return 0; // replace with actual logic
    }
}
