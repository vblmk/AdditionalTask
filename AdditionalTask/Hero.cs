using System.Data;

namespace AdditionalTask;

public class Hero
{
    public string Name { get; }
    
    public int MaxHp { get; }
    
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int AddedAttack;
    public int AddedDefense;

    public Inventory<Item> Inventory;

    public Hero(string name, int attack, int defense, int maxHp, double weightLimit)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Hp = maxHp;
        MaxHp = maxHp;

        Inventory = new Inventory<Item>(weightLimit);
    }

    public void ShowInventory()
    {
        foreach (var item in Inventory)
        {
            Console.WriteLine(item + "\n");
        }
    }

    public void ShowCharacteristics()
    {
        Console.WriteLine($"HP: {Hp}\n" +
                          $"Attack: {Attack}\n" +
                          $"Defense: {Defense}");
    }
    
    public override string ToString()
    {
        return $"Name: {Name}" +
               $"HP: {Hp}\n" +
               $"Attack: {Attack}\n" +
               $"Defense: {Defense}";
    }
}