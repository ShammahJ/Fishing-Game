[System.Serializable]
public class ActiveUpgrade
{
    public Upgrade definition;
    public int stacks;
    public object data;

    public ActiveUpgrade(Upgrade definition)
    {
        this.definition = definition;
        this.stacks = 1;
        this.data = null;
    }
}

