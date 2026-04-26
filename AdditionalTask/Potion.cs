namespace AdditionalTask;

public class Potion : Item
{
    private int _heal;
    
    public Potion(string name, double weight, ItemRarity rarity, int heal) : base(name, weight, rarity)
    {
        _heal = heal;
    }

    public override void Use(Hero hero)
    {
        if (hero.Hp + _heal >= hero.MaxHp)
            hero.Hp = hero.MaxHp;
        else
            hero.Hp += _heal;
        
        hero.Inventory.Remove(this);
    }
    
    public override string ToString()
    {
        return $"Name: {Name}\n" +
               "Class: Potion\n" +
               $"HP impact: {_heal}\n" +
               $"Weight: {Weight}\n" +
               $"Rarity: {GetRarity()}";
    }
}