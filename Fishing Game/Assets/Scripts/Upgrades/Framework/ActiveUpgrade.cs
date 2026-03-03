[System.Serializable]
public class ActiveUpgrade
{
    public Upgrade definition;
    public int stacks = 1;

    public ActiveUpgrade(Upgrade upgrade)
    {
        definition = upgrade;
        stacks = 1;
    }
}

