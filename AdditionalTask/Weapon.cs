namespace AdditionalTask;

public class Weapon : Item
{
    private int _attack;
    
    public Weapon(string name, double weight, ItemRarity rarity, int attack) : base(name, weight, rarity)
    {
        _attack = attack;
    }

    public override void Use(Hero hero)
    {
        hero.Attack -= hero.AddedAttack;
        hero.Attack += _attack;
        hero.AddedAttack = _attack;
    }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               "Class: Weapon\n" +
               $"Attack: {_attack}\n" +
               $"Weight: {Weight}\n" +
               $"Rarity: {GetRarity()}";
    }
}