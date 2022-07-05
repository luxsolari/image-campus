namespace Evaluacion_II.Items;

public abstract class Item
{
    private string? name;

    protected Item(string? name)
    {
        this.Name = name;
    }

    protected string? Name
    {
        get => name;
        set => name = value;
    }
}