namespace AdditionalTask;

public abstract class Item : IComparable<Item>
{
    public string Name { get; }
    public double Weight { get; }
    public ItemRarity Rarity { get; }

    private Dictionary<ItemRarity, int> _rarities = new Dictionary<ItemRarity, int> {
        { ItemRarity.Common, 0 },
        { ItemRarity.Rare, 1},
        { ItemRarity.Epic, 2},
        { ItemRarity.Legendary, 3} };

    public Item(string name, double weight, ItemRarity rarity)
        {
            Name = name;
            Weight = weight;
            Rarity = rarity;
        }

    protected string GetRarity()
    {
        if (Rarity == ItemRarity.Common)
            return "Common";
        
        if (Rarity == ItemRarity.Rare)
            return "Rare";
        
        if (Rarity == ItemRarity.Epic)
            return "Epic";
        
        if (Rarity == ItemRarity.Legendary)
            return "Legendary";

        return "";
    }

    public abstract void Use(Hero hero);

    public int CompareTo(Item? other)
    {
        if (_rarities[Rarity] < _rarities[other.Rarity])
            return -1;
        
        if (_rarities[Rarity] > _rarities[other.Rarity])
            return 1;
        
        return 0;
    }
}