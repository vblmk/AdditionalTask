namespace AdditionalTask;

public class Armor : Item
{
    private int _defense;
    public Armor(string name, double weight, ItemRarity rarity, int def) : base(name, weight, rarity)
    {
        _defense = def;
    }

    public override void Use(Hero hero)
    {
        hero.Defense -= hero.AddedDefense;
        hero.Defense += _defense;
        hero.AddedDefense = _defense;
    }
    
    public override string ToString()
    {
        return $"Name: {Name}\n" +
               "Class: Armor\n" +
               $"Defense rate: {_defense}\n" +
               $"Weight: {Weight}\n" +
               $"Rarity: {GetRarity()}";
    }
}